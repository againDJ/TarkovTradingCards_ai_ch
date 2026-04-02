using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Extensions;
using SPTarkov.Server.Core.Generators;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Eft.Common;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Utils;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Generates random reward items for special crate rewards (scav case results, cultist circle results).
/// </summary>
public sealed class RandomRewardService
{
	private readonly ISptLogger<RandomRewardService> _logger;
	private readonly ScavCaseRewardGenerator _scavCaseRewardGenerator;
	private readonly DatabaseService _databaseService;
	private readonly ProfileHelper _profileHelper;
	private readonly ItemHelper _itemHelper;
	private readonly PresetHelper _presetHelper;
	private readonly RandomUtil _randomUtil;
	private readonly ItemFilterService _itemFilterService;
	private readonly SeasonalEventService _seasonalEventService;
	private readonly HideoutConfig _hideoutConfig;
	private readonly State _state;

	public RandomRewardService(
		ISptLogger<RandomRewardService> logger,
		ScavCaseRewardGenerator scavCaseRewardGenerator,
		DatabaseService databaseService,
		ProfileHelper profileHelper,
		ItemHelper itemHelper,
		PresetHelper presetHelper,
		RandomUtil randomUtil,
		ItemFilterService itemFilterService,
		SeasonalEventService seasonalEventService,
		ConfigServer configServer,
		State state)
	{
		_logger = logger;
		_scavCaseRewardGenerator = scavCaseRewardGenerator;
		_databaseService = databaseService;
		_profileHelper = profileHelper;
		_itemHelper = itemHelper;
		_presetHelper = presetHelper;
		_randomUtil = randomUtil;
		_itemFilterService = itemFilterService;
		_seasonalEventService = seasonalEventService;
		_hideoutConfig = configServer.GetConfig<HideoutConfig>();
		_state = state;
	}

	// Recipe IDs for each scav case type
	private static readonly Dictionary<RandomRewardType, string> ScavCaseRecipes = new()
	{
		[RandomRewardType.ScavCase2500] = "62710974e71632321e5afd5f",
		[RandomRewardType.ScavCase15000] = "62710a8c403346379e3de9be",
		[RandomRewardType.ScavCase95000] = "62710a69adfbd4354d79c58e",
		[RandomRewardType.ScavCaseMoonshine] = "6271093e621b0a76055cd61e",
		[RandomRewardType.ScavCaseIntel] = "62710a0e436dcc0b9c55f4ec",
	};

	/// <summary>
	/// Generate random scav case rewards for the given type.
	/// </summary>
	public List<Item> GenerateScavCaseReward(RandomRewardType type = RandomRewardType.ScavCaseIntel)
	{
		if (!ScavCaseRecipes.TryGetValue(type, out var recipeId))
		{
			_logger.Error($"[TTC][RandomReward] Unknown scav case type: {type}");
			return new List<Item>();
		}

		try
		{
			var rewardItemGroups = _scavCaseRewardGenerator.Generate(recipeId);
			var allItems = new List<Item>();

			foreach (var itemGroup in rewardItemGroups)
			{
				if (itemGroup == null || itemGroup.Count == 0) continue;
				foreach (var item in itemGroup)
					allItems.Add(item);
			}

			_logger.Info($"[TTC][RandomReward] Generated {allItems.Count} scav case ({type}) reward items");
			return allItems;
		}
		catch (Exception ex)
		{
			_logger.Error($"[TTC][RandomReward] Failed to generate scav case rewards: {ex.Message}");
			return new List<Item>();
		}
	}

	// Parent class IDs for random pool generation
	private static readonly string[] MedBaseClasses = {
		"5448f39d4bdc2d0a728b4568", // Medkit
		"5448f3a14bdc2d27728b4569", // Drug
		"5448f3a64bdc2d60728b456a"  // Stimulator
	};
	private static readonly string KeyMechanicalClass = "5c99f98d86f7745c314214b3";

	private List<MongoId>? _medPool;
	private List<MongoId>? _keyPool;

	/// <summary>
	/// Generate random med/key rewards by picking count items from the pool (with duplicates possible).
	/// </summary>
	public List<Item> GenerateRandomPoolReward(RandomRewardType type, int count)
	{
		try
		{
			var pool = type == RandomRewardType.RandomMeds ? GetMedPool() : GetKeyPool();
			if (pool.Count == 0)
			{
				_logger.Warning($"[TTC][RandomReward] Empty pool for {type}");
				return new List<Item>();
			}

			var items = new List<Item>();
			for (int i = 0; i < count; i++)
			{
				var tpl = _randomUtil.GetArrayValue(pool);
				items.Add(new Item
				{
					Id = new MongoId(),
					Template = tpl,
					Upd = new Upd { StackObjectsCount = 1, SpawnedInSession = true }
				});
			}

			_logger.Info($"[TTC][RandomReward] Generated {count} random {type} items");
			return items;
		}
		catch (Exception ex)
		{
			_logger.Error($"[TTC][RandomReward] Failed to generate {type} rewards: {ex.Message}");
			return new List<Item>();
		}
	}

	private List<MongoId> GetMedPool()
	{
		if (_medPool != null) return _medPool;
		_medPool = BuildBaseClassPool(MedBaseClasses);
		return _medPool;
	}

	private List<MongoId> GetKeyPool()
	{
		if (_keyPool != null) return _keyPool;
		_keyPool = BuildBaseClassPool(new[] { KeyMechanicalClass });
		return _keyPool;
	}

	private List<MongoId> BuildBaseClassPool(string[] baseClassIds)
	{
		var items = _databaseService.GetItems();
		var pool = new List<MongoId>();

		foreach (var kvp in items)
		{
			var template = kvp.Value;
			if (template.Type != "Item") continue;
			if (template.Properties?.QuestItem == true) continue;
			if (template.Properties?.IsUnbuyable == true) continue;

			foreach (var baseClass in baseClassIds)
			{
				if (_itemHelper.IsOfBaseclass(kvp.Key, baseClass))
				{
					pool.Add(kvp.Key);
					break;
				}
			}
		}

		return pool;
	}

	/// <summary>
	/// Generate random cultist circle rewards within a rouble budget.
	/// Reproduces CircleOfCultistService logic including quest/hideout item rewards.
	/// </summary>
	public List<Item> GenerateCultistCircleReward(MongoId sessionId, double budgetRoubles = 1_000_000)
	{
		try
		{
			var circleConfig = _hideoutConfig.CultistCircle;
			var pmcData = _profileHelper.GetPmcProfile(sessionId);
			var rewardPool = BuildCultistRewardPool(circleConfig, pmcData);

			if (rewardPool.Count == 0)
			{
				_logger.Warning("[TTC][RandomReward] Cultist reward pool is empty");
				return new List<Item>();
			}

			// Apply reward multiplier (random within config range)
			var multiplier = _randomUtil.GetDouble(
				circleConfig.RewardPriceMultiplierMinMax.Min,
				circleConfig.RewardPriceMultiplierMinMax.Max);
			var rewardBudget = budgetRoubles * multiplier;

			var allItems = new List<Item>();
			int totalValue = 0;
			int rewardCount = 0;
			int attempts = 0;
			int maxRewards = circleConfig.MaxRewardItemCount;
			int maxAttempts = circleConfig.MaxAttemptsToPickRewardsWithinBudget;

			while (totalValue < rewardBudget && rewardPool.Count > 0 && rewardCount < maxRewards)
			{
				if (attempts > maxAttempts) break;

				var randomTpl = _randomUtil.GetArrayValue(rewardPool);

				// Check if item needs a preset (weapons/armor)
				if (_itemHelper.ArmorItemHasRemovableOrSoftInsertSlots(randomTpl) ||
					_itemHelper.IsOfBaseclass(randomTpl, BaseClasses.WEAPON))
				{
					var preset = _presetHelper.GetDefaultPreset(randomTpl);
					if (preset == null)
					{
						attempts++;
						continue;
					}

					var presetItems = preset.Items.ReplaceIDs().ToList();
					presetItems.RemapRootItemId();
					_itemHelper.SetFoundInRaid(presetItems);
					allItems.AddRange(presetItems);
				}
				else
				{
					var newItem = new Item
					{
						Id = new MongoId(),
						Template = randomTpl,
						Upd = new Upd { StackObjectsCount = 1, SpawnedInSession = true }
					};
					allItems.Add(newItem);
				}

				var price = _itemHelper.GetItemPrice(randomTpl);
				totalValue += (int)(price ?? 0);
				rewardCount++;
				attempts = 0;
			}

			_logger.Info($"[TTC][RandomReward] Generated {rewardCount} cultist circle reward items (budget: {rewardBudget:N0}, spent: {totalValue:N0})");
			return allItems;
		}
		catch (Exception ex)
		{
			_logger.Error($"[TTC][RandomReward] Failed to generate cultist circle rewards: {ex.Message}");
			return new List<Item>();
		}
	}

	/// <summary>
	/// Build a pool of item template IDs eligible for cultist circle rewards.
	/// Includes quest hand-in items and hideout upgrade requirements from the player's profile.
	/// </summary>
	private List<MongoId> BuildCultistRewardPool(CultistCircleSettings circleConfig, PmcData? pmcData)
	{
		var items = _databaseService.GetItems();
		var blacklist = new HashSet<MongoId>();

		blacklist.UnionWith(_seasonalEventService.GetInactiveSeasonalEventItems());
		blacklist.UnionWith(_itemFilterService.GetItemRewardBlacklist());
		blacklist.UnionWith(_itemFilterService.GetBlacklistedItems());
		blacklist.UnionWith(circleConfig.RewardItemBlacklist);

		var baseTypeBlacklist = _itemFilterService.GetItemRewardBaseTypeBlacklist();
		foreach (var kvp in items)
		{
			if (_itemHelper.IsOfBaseclasses(kvp.Key, baseTypeBlacklist))
				blacklist.Add(kvp.Key);
		}

		var pool = new HashSet<MongoId>();

		// Add quest hand-in items from active quests
		if (pmcData?.Quests != null)
		{
			var questDb = _databaseService.GetTables().Templates?.Quests;
			if (questDb != null)
			{
				foreach (var quest in pmcData.Quests.Where(q => q.Status == QuestStatusEnum.Started))
				{
					if (!questDb.TryGetValue(quest.QId, out var questData)) continue;
					var finishConditions = questData.Conditions?.AvailableForFinish;
					if (finishConditions == null) continue;

					foreach (var cond in finishConditions.Where(c => c.ConditionType == "HandoverItem"))
					{
						foreach (var tpl in cond.Target.List)
						{
							if (!blacklist.Contains(tpl) && _itemHelper.IsValidItem(tpl))
								pool.Add(tpl);
						}
					}
				}
			}
		}

		// Add hideout upgrade requirements (next level items)
		if (pmcData?.Hideout?.Areas != null)
		{
			var hideoutDb = _databaseService.GetHideout();
			foreach (var playerArea in pmcData.Hideout.Areas)
			{
				var dbArea = hideoutDb.Areas?.FirstOrDefault(a => a.Type == playerArea.Type);
				if (dbArea?.Stages == null) continue;

				var nextLevel = (playerArea.Level + 1).ToString();
				if (!dbArea.Stages.TryGetValue(nextLevel, out var stage)) continue;

				foreach (var req in stage.Requirements.Where(r => r.Type == "Item"))
				{
					if (req.TemplateId != null && !blacklist.Contains(req.TemplateId) && _itemHelper.IsValidItem(req.TemplateId))
						pool.Add(req.TemplateId);
				}
			}
		}

		// Fill with random high-value items
		foreach (var kvp in items)
		{
			var tpl = kvp.Key;
			var templateItem = kvp.Value;

			if (blacklist.Contains(tpl)) continue;
			if (templateItem.Properties == null) continue;
			if (templateItem.Type != "Item") continue;
			if (templateItem.Properties.QuestItem == true) continue;
			if (templateItem.Properties.IsUnbuyable == true) continue;

			var price = _itemHelper.GetItemPrice(tpl);
			if (price == null || price <= 0) continue;

			pool.Add(tpl);
		}

		// Add config's additional reward pool
		if (circleConfig.AdditionalRewardItemPool?.Count > 0)
		{
			foreach (var item in circleConfig.AdditionalRewardItemPool)
			{
				if (!blacklist.Contains(item))
					pool.Add(item);
			}
		}

		return pool.ToList();
	}

	// Booster pack rarity weights: 40% C, 30% U, 20% R, 8% E, 1.5% L, 0.5% S
	private static readonly (string rarity, double weight)[] BoosterRarityWeights =
	{
		("Common", 40.0),
		("Uncommon", 30.0),
		("Rare", 20.0),
		("Epic", 8.0),
		("Legendary", 1.5),
		("Secret", 0.5)
	};

	private Dictionary<string, List<string>>? _cardsByRarity;

	/// <summary>
	/// Generate a booster pack: 5 weighted-random cards + 1 Empty Booster Pack.
	/// Cards are NOT found in raid.
	/// </summary>
	public List<Item> GenerateBoosterPackReward(string emptyBoosterId)
	{
		try
		{
			if (_cardsByRarity == null)
			{
				_cardsByRarity = new Dictionary<string, List<string>>();
				foreach (var card in _state.Cards)
				{
					if (!_cardsByRarity.ContainsKey(card.rarity))
						_cardsByRarity[card.rarity] = new List<string>();
					_cardsByRarity[card.rarity].Add(card.id);
				}
			}

			var items = new List<Item>();
			var random = new Random();

			for (int i = 0; i < 5; i++)
			{
				// Roll rarity
				var roll = random.NextDouble() * 100.0;
				double cumulative = 0;
				string selectedRarity = "Common";
				foreach (var (rarity, weight) in BoosterRarityWeights)
				{
					cumulative += weight;
					if (roll < cumulative)
					{
						selectedRarity = rarity;
						break;
					}
				}

				// Pick random card of that rarity
				if (_cardsByRarity.TryGetValue(selectedRarity, out var pool) && pool.Count > 0)
				{
					var cardId = pool[random.Next(pool.Count)];
					items.Add(new Item
					{
						Id = new MongoId(Guid.NewGuid().ToString("N")[..24]),
						Template = new MongoId(cardId),
						Upd = new Upd { StackObjectsCount = 1 }
					});
				}
			}

			// Add 1x Empty Booster Pack
			if (!string.IsNullOrWhiteSpace(emptyBoosterId))
			{
				items.Add(new Item
				{
					Id = new MongoId(Guid.NewGuid().ToString("N")[..24]),
					Template = new MongoId(emptyBoosterId),
					Upd = new Upd { StackObjectsCount = 1 }
				});
			}

			_logger.Info($"[TTC][BoosterPack] Generated 5 random cards + 1 empty booster");
			return items;
		}
		catch (Exception ex)
		{
			_logger.Error($"[TTC][BoosterPack] Failed: {ex.Message}");
			return new List<Item>();
		}
	}
}
