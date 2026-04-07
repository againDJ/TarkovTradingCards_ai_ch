using System.Text.Json;
using System.Text.Json.Nodes;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Eft.ItemEvent;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Models.Spt.Server;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Utils;
using SPTarkov.Server.Core.Models.Eft.Quests;
using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Intercepts trader purchases to detect TTC reward crate buys.
/// When a reward crate is purchased, removes it from inventory and sends
/// the predetermined reward items via mail from Kolya (sealed-case style).
/// SPT response structure: { "data": { "profileChanges": { "sessionId": { "items": { "new": [...] } } } } }
/// </summary>
public sealed class RewardCrateRouter(
	JsonUtil jsonUtil,
	RewardCrateRegistry registry,
	ProfileHelper profileHelper,
	InventoryHelper inventoryHelper,
	MailSendService mailSend,
	DatabaseService databaseService,
	RandomRewardService randomRewardService,
	ISptLogger<RewardCrateRouter> logger
) : StaticRouter(jsonUtil, [
	new RouteAction<ItemEventRouterRequest>(
		"/client/game/profile/items/moving",
		(url, requestData, sessionId, output) =>
			ProcessOutput(sessionId, output, requestData, registry, profileHelper, inventoryHelper, mailSend, databaseService, randomRewardService, logger)
	)
])
{
	private static readonly string IntroQuestId = QuestIds.QuestId("ttc_quest_introduction");

	// Cache of crate item IDs in player inventory → their template IDs
	// Updated before each request processing so we can identify sold crates
	private static readonly Dictionary<string, string> _crateInventoryCache = new();

	private static ValueTask<string> ProcessOutput(
		MongoId sessionId, string? output,
		ItemEventRouterRequest? requestData,
		RewardCrateRegistry registry,
		ProfileHelper profileHelper,
		InventoryHelper inventoryHelper,
		MailSendService mailSend,
		DatabaseService databaseService,
		RandomRewardService randomRewardService,
		ISptLogger<RewardCrateRouter> logger)
	{
		if (string.IsNullOrEmpty(output))
			return ValueTask.FromResult(output ?? string.Empty);

		try
		{
			// Check for intro quest completion → send 5 random cards via mail
			CheckIntroQuestCompletion(requestData, sessionId, registry, mailSend, randomRewardService, logger);

			// Quick check: if no crates are registered, skip entirely
			if (!registry.HasAnyCrates)
				return ValueTask.FromResult(output);

			// Refresh crate inventory cache — add any NEW crate items (don't clear, only add)
			RefreshCrateCache(profileHelper, sessionId, registry);

			using var doc = JsonDocument.Parse(output);
			var root = doc.RootElement;

			// SPT wraps responses: { "data": { "profileChanges": { ... } } }
			// Navigate through the wrapper
			JsonElement profileChanges;
			if (root.TryGetProperty("data", out var data)
				&& data.TryGetProperty("profileChanges", out profileChanges))
			{
				// wrapped format
			}
			else if (root.TryGetProperty("profileChanges", out profileChanges))
			{
				// unwrapped format (fallback)
			}
			else
			{
				return ValueTask.FromResult(output);
			}

			if (profileChanges.ValueKind != JsonValueKind.Object)
				return ValueTask.FromResult(output);

			// Look for crate items in the session's new items
			var sessionIdStr = sessionId.ToString();
			var cratesToProcess = new List<(string id, string tpl)>();

			// Try session-specific key first, then iterate all keys
			var profileKeys = new List<string>();
			if (profileChanges.TryGetProperty(sessionIdStr, out _))
				profileKeys.Add(sessionIdStr);
			else
			{
				foreach (var prop in profileChanges.EnumerateObject())
					profileKeys.Add(prop.Name);
			}

			var soldCrates = new List<string>(); // tpl only (already removed from inventory)

			// Check requestData for sell actions containing crate items
			if (requestData?.Data != null)
			{
				foreach (var action in requestData.Data)
				{
					if (action is SPTarkov.Server.Core.Models.Eft.Trade.ProcessSellTradeRequestData sellReq)
					{
						// Look up sold items in the cache (populated from PREVIOUS request)
						foreach (var soldItem in sellReq.Items)
						{
							if (_crateInventoryCache.TryGetValue(soldItem.Id, out var tpl))
							{
								soldCrates.Add(tpl);
								_crateInventoryCache.Remove(soldItem.Id);
								logger.Debug($"[TTC][RewardCrate] Sold crate {soldItem.Id}: {tpl}");
							}
						}
					}
				}
			}

			foreach (var key in profileKeys)
			{
				if (!profileChanges.TryGetProperty(key, out var profileEntry)) continue;
				if (!profileEntry.TryGetProperty("items", out var items)) continue;

				// Check new items (purchased crates)
				if (items.TryGetProperty("new", out var newItems) && newItems.ValueKind == JsonValueKind.Array)
				{
					foreach (var item in newItems.EnumerateArray())
					{
						if (!item.TryGetProperty("_tpl", out var tplProp)) continue;
						var tpl = tplProp.GetString();
						if (tpl == null || !registry.IsCrate(tpl)) continue;

						if (!item.TryGetProperty("_id", out var idProp)) continue;
						var id = idProp.GetString();
						if (id == null) continue;

						cratesToProcess.Add((id, tpl));
					}
				}

			}

			if (cratesToProcess.Count == 0 && soldCrates.Count == 0)
				return ValueTask.FromResult(output);

			// Process sold crates first (no JSON modification needed — already removed by sell)
			foreach (var tpl in soldCrates)
			{
				ProcessCrateReward(tpl, sessionId, registry, mailSend, randomRewardService, databaseService, logger);
			}

			if (cratesToProcess.Count == 0)
				return ValueTask.FromResult(output);

			logger.Info($"[TTC][RewardCrate] Detected {cratesToProcess.Count} purchased crate(s), intercepting...");

			// Parse as mutable JsonNode for modification
			var node = JsonNode.Parse(output);
			if (node == null)
				return ValueTask.FromResult(output);

			// Navigate to profileChanges in the mutable tree (handle both wrapped and unwrapped)
			var profileChangesNode = node["data"]?["profileChanges"]?.AsObject()
				?? node["profileChanges"]?.AsObject();
			if (profileChangesNode == null)
				return ValueTask.FromResult(output);

			var pmcData = profileHelper.GetPmcProfile(sessionId);

			foreach (var (id, tpl) in cratesToProcess)
			{
				// Remove the crate from new items
				foreach (var profileProp in profileChangesNode)
				{
					var newItemsNode = profileProp.Value?["items"]?["new"]?.AsArray();
					if (newItemsNode == null) continue;

					for (int i = newItemsNode.Count - 1; i >= 0; i--)
					{
						var itemId = newItemsNode[i]?["_id"]?.GetValue<string>();
						if (itemId == id)
						{
							newItemsNode.RemoveAt(i);
							break;
						}
					}
				}

				// Remove the crate from server-side inventory
				if (pmcData != null)
					inventoryHelper.RemoveItem(pmcData, new MongoId(id), sessionId, null);

				// Check if this is a random reward crate
				var randomType = registry.GetRandomType(tpl);
				if (randomType != null)
				{
					var rollCount = registry.GetRandomCount(tpl);

					if (randomType.Value is RandomRewardType.BoosterPack)
					{
						var boosterItems = randomRewardService.GenerateBoosterPackReward(
							registry.GetBoosterEmptyId() ?? "");
						if (boosterItems.Count > 0)
						{
							mailSend.SendDirectNpcMessageToPlayer(
								sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
								"Here's your booster pack, friend! Five cards fresh from my collection. Keep them — you'll want them for barters later.",
								boosterItems);
							logger.Info($"[TTC][BoosterPack] Sent {boosterItems.Count} items (5 cards + empty booster) via mail");
						}
						continue;
					}

					if (randomType.Value is RandomRewardType.RandomMeds or RandomRewardType.RandomKeys)
					{
						// Pool-based: pick rollCount items, send in one mail
						var randomItems = randomRewardService.GenerateRandomPoolReward(randomType.Value, rollCount);
						if (randomItems.Count > 0)
						{
							mailSend.SendDirectNpcMessageToPlayer(
								sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
								randomType.Value == RandomRewardType.RandomKeys
									? "Found some keys in a dead scav's pockets. Maybe one of them opens something good."
									: "Raided a medical supply cache. Here's what was inside.",
								randomItems);
							logger.Info($"[TTC][RewardCrate] Sent {randomItems.Count} random {randomType.Value} items via mail for crate {tpl[..8]}...");
						}
					}
					else
					{
						// ScavCase/CultistCircle: each roll is a separate generation + mail
						for (int roll = 0; roll < rollCount; roll++)
						{
							var randomItems = randomType.Value switch
							{
								RandomRewardType.ScavCase2500 or RandomRewardType.ScavCase15000 or
								RandomRewardType.ScavCase95000 or RandomRewardType.ScavCaseMoonshine or
								RandomRewardType.ScavCaseIntel => randomRewardService.GenerateScavCaseReward(randomType.Value),
								RandomRewardType.CultistCircle => randomRewardService.GenerateCultistCircleReward(sessionId),
								_ => new List<Item>()
							};

							if (randomItems.Count > 0)
							{
								mailSend.SendDirectNpcMessageToPlayer(
									sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
									randomType.Value == RandomRewardType.CultistCircle
										? "The circle has spoken. Accept its offerings."
										: "My scav network came through. Here's what they found.",
									randomItems);
								logger.Info($"[TTC][RewardCrate] Sent {randomItems.Count} random items ({randomType.Value}, roll {roll + 1}/{rollCount}) via mail for crate {tpl[..8]}...");
							}
						}
					}
					continue;
				}

				// Fixed reward crate
				var rewards = registry.GetContents(tpl);
				if (rewards == null || rewards.Count == 0) continue;

				var mailItems = BuildMailItems(rewards, databaseService);

				mailSend.SendDirectNpcMessageToPlayer(
					sessionId,
					QuestIds.KolyaTraderId,
					MessageType.MessageWithItems,
					"Here are your barter rewards, friend. Use them wisely.",
					mailItems
				);

				logger.Info($"[TTC][RewardCrate] Sent {mailItems.Count} items via mail for crate {tpl[..8]}...");
			}

			return ValueTask.FromResult(node.ToJsonString(new JsonSerializerOptions { WriteIndented = false }));
		}
		catch (Exception ex)
		{
			logger.Error($"[TTC][RewardCrate] Error: {ex.Message}\n{ex.StackTrace}");
			return ValueTask.FromResult(output ?? string.Empty);
		}
	}

	private static List<Item> BuildMailItems(List<BarterRewardItem> rewards, DatabaseService databaseService)
	{
		var items = new List<Item>();
		var tables = databaseService.GetTables();

		foreach (var reward in rewards)
		{
			var count = Math.Max(1, reward.Count);
			var maxStack = GetMaxStackSize(tables, reward.TemplateId);

			if (maxStack > 1 && count > 1)
			{
				// Stackable item: create stacks up to maxStack
				var remaining = count;
				while (remaining > 0)
				{
					var stackSize = Math.Min(remaining, maxStack);
					items.Add(new Item
					{
						Id = new MongoId(Guid.NewGuid().ToString("N")[..24]),
						Template = new MongoId(reward.TemplateId),
						Upd = new Upd { StackObjectsCount = stackSize }
					});
					remaining -= stackSize;
				}
			}
			else
			{
				// Non-stackable or single item: create individual items
				for (int i = 0; i < count; i++)
				{
					var parentId = new MongoId(Guid.NewGuid().ToString("N")[..24]);
					items.Add(new Item
					{
						Id = parentId,
						Template = new MongoId(reward.TemplateId),
						Upd = new Upd { StackObjectsCount = 1 }
					});

					if (reward.Parts != null)
						AddPartsRecursive(items, parentId, reward.Parts);
				}
			}
		}
		return items;
	}

	private static int GetMaxStackSize(DatabaseTables? tables, string templateId)
	{
		if (tables?.Templates?.Items?.TryGetValue(templateId, out var template) == true)
			return template.Properties?.StackMaxSize ?? 1;
		return 1;
	}

	private static void AddPartsRecursive(List<Item> items, MongoId parentId, List<PresetPart> parts)
	{
		foreach (var part in parts)
		{
			var partId = new MongoId(Guid.NewGuid().ToString("N")[..24]);
			items.Add(new Item
			{
				Id = partId,
				Template = new MongoId(part.TemplateId),
				ParentId = parentId,
				SlotId = part.SlotId
			});

			if (part.Parts != null)
				AddPartsRecursive(items, partId, part.Parts);
		}
	}

	/// <summary>
	/// Detect intro quest completion by checking if the request contains a QuestComplete action
	/// for the TTC introduction quest. If so, send 5 random cards via mail as a welcome booster.
	/// </summary>
	private static void CheckIntroQuestCompletion(
		ItemEventRouterRequest? requestData,
		MongoId sessionId,
		RewardCrateRegistry registry,
		MailSendService mailSend,
		RandomRewardService randomRewardService,
		ISptLogger<RewardCrateRouter> logger)
	{
		if (requestData?.Data == null) return;

		foreach (var action in requestData.Data)
		{
			if (action is not CompleteQuestRequestData completeReq) continue;
			if (completeReq.QuestId.ToString() != IntroQuestId) continue;

			// Intro quest completed! Send 5 random cards + 1 empty booster via mail
			var emptyBoosterId = registry.GetBoosterEmptyId() ?? "";
			var boosterItems = randomRewardService.GenerateBoosterPackReward(emptyBoosterId);

			if (boosterItems.Count > 0)
			{
				mailSend.SendDirectNpcMessageToPlayer(
					sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
					"Here's your welcome booster, friend! Five cards fresh from my collection. Keep them — you'll want them for barters later.",
					boosterItems);
				logger.Info($"[TTC][BoosterPack] Sent {boosterItems.Count} welcome cards via mail on intro quest completion");
			}
			break;
		}
	}

	private static void RefreshCrateCache(ProfileHelper profileHelper, MongoId sessionId, RewardCrateRegistry registry)
	{
		try
		{
			var pmcProfile = profileHelper.GetPmcProfile(sessionId);
			if (pmcProfile?.Inventory?.Items == null) return;

			// Only ADD new entries, don't clear — sold items are removed explicitly when processed
			foreach (var item in pmcProfile.Inventory.Items)
			{
				var tpl = item.Template.ToString();
				if (registry.IsCrate(tpl))
					_crateInventoryCache.TryAdd(item.Id.ToString(), tpl);
			}
		}
		catch { }
	}

	/// <summary>
	/// Process a crate reward (used for both purchased and sold crates).
	/// Generates the appropriate reward items and sends them via mail.
	/// </summary>
	private static void ProcessCrateReward(
		string tpl, MongoId sessionId,
		RewardCrateRegistry registry,
		MailSendService mailSend,
		RandomRewardService randomRewardService,
		DatabaseService databaseService,
		ISptLogger<RewardCrateRouter> logger)
	{
		var randomType = registry.GetRandomType(tpl);
		if (randomType != null)
		{
			var rollCount = registry.GetRandomCount(tpl);

			if (randomType.Value is RandomRewardType.BoosterPack)
			{
				var boosterItems = randomRewardService.GenerateBoosterPackReward(
					registry.GetBoosterEmptyId() ?? "");
				if (boosterItems.Count > 0)
					mailSend.SendDirectNpcMessageToPlayer(
						sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
						"Here's your booster pack, friend! Five cards fresh from my collection. Keep them — you'll want them for barters later.",
						boosterItems);
			}
			else if (randomType.Value is RandomRewardType.RandomMeds or RandomRewardType.RandomKeys)
			{
				var randomItems = randomRewardService.GenerateRandomPoolReward(randomType.Value, rollCount);
				if (randomItems.Count > 0)
					mailSend.SendDirectNpcMessageToPlayer(
						sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
						randomType.Value == RandomRewardType.RandomKeys
							? "Found some keys in a dead scav's pockets. Maybe one of them opens something good."
							: "Raided a medical supply cache. Here's what was inside.",
						randomItems);
			}
			else
			{
				for (int roll = 0; roll < rollCount; roll++)
				{
					var randomItems = randomType.Value switch
					{
						RandomRewardType.ScavCase2500 or RandomRewardType.ScavCase15000 or
						RandomRewardType.ScavCase95000 or RandomRewardType.ScavCaseMoonshine or
						RandomRewardType.ScavCaseIntel => randomRewardService.GenerateScavCaseReward(randomType.Value),
						RandomRewardType.CultistCircle => randomRewardService.GenerateCultistCircleReward(sessionId),
						_ => new List<Item>()
					};

					if (randomItems.Count > 0)
						mailSend.SendDirectNpcMessageToPlayer(
							sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
							randomType.Value == RandomRewardType.CultistCircle
								? "The circle has spoken. Accept its offerings."
								: "My scav network came through. Here's what they found.",
							randomItems);
				}
			}

			logger.Info($"[TTC][RewardCrate] Processed sold crate {tpl[..8]}... ({randomType.Value})");
			return;
		}

		// Fixed reward crate
		var rewards = registry.GetContents(tpl);
		if (rewards == null || rewards.Count == 0) return;

		var mailItems = BuildMailItems(rewards, databaseService);
		mailSend.SendDirectNpcMessageToPlayer(
			sessionId, QuestIds.KolyaTraderId, MessageType.MessageWithItems,
			"Here are your barter rewards, friend. Use them wisely.",
			mailItems);
		logger.Info($"[TTC][RewardCrate] Processed sold fixed crate {tpl[..8]}...");
	}
}
