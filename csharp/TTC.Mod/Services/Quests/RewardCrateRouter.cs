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
	ISptLogger<RewardCrateRouter> logger
) : StaticRouter(jsonUtil, [
	new RouteAction<ItemEventRouterRequest>(
		"/client/game/profile/items/moving",
		(url, requestData, sessionId, output) =>
			ProcessOutput(sessionId, output, registry, profileHelper, inventoryHelper, mailSend, databaseService, logger)
	)
])
{
	private static ValueTask<string> ProcessOutput(
		MongoId sessionId, string? output,
		RewardCrateRegistry registry,
		ProfileHelper profileHelper,
		InventoryHelper inventoryHelper,
		MailSendService mailSend,
		DatabaseService databaseService,
		ISptLogger<RewardCrateRouter> logger)
	{
		if (string.IsNullOrEmpty(output))
			return ValueTask.FromResult(output ?? string.Empty);

		try
		{
			// Quick check: if no crates are registered, skip entirely
			if (!registry.HasAnyCrates)
				return ValueTask.FromResult(output);

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

			foreach (var key in profileKeys)
			{
				if (!profileChanges.TryGetProperty(key, out var profileEntry)) continue;
				if (!profileEntry.TryGetProperty("items", out var items)) continue;
				if (!items.TryGetProperty("new", out var newItems)) continue;
				if (newItems.ValueKind != JsonValueKind.Array) continue;

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

			if (cratesToProcess.Count == 0)
				return ValueTask.FromResult(output);

			logger.Info($"[TTC][RewardCrate] Detected {cratesToProcess.Count} crate(s) in response, intercepting...");

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

				// Look up what items this crate should give
				var rewards = registry.GetContents(tpl);
				if (rewards == null || rewards.Count == 0) continue;

				// Build mail items
				var mailItems = BuildMailItems(rewards, databaseService);

				// Send from Kolya
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
}
