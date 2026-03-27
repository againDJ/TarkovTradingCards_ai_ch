using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Server;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Models;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Creates quest-gated barter deals at Kolya: trade a card for useful items.
/// Single-item barters: direct card→item trade.
/// Multi-item barters: card→reward crate (intercepted by RewardCrateRouter, items sent via mail).
/// Also sets up rouble purchases for binders and Empty Booster gated by their quests.
/// </summary>
public sealed class QuestAssortService
{
	private readonly ISptLogger<QuestAssortService> _logger;
	private readonly DatabaseService _db;
	private readonly State _state;
	private readonly RewardCrateRegistry _crateRegistry;

	public QuestAssortService(ISptLogger<QuestAssortService> logger, DatabaseService db, State state, RewardCrateRegistry crateRegistry)
	{
		_logger = logger;
		_db = db;
		_state = state;
		_crateRegistry = crateRegistry;
	}

	private static readonly string RoubleTpl = "5449016a4bdc2d6f028b456f";

	/// <summary>
	/// For each quest with a BarterUnlock, create an assort entry at Kolya:
	/// the player gives a card, receives useful items. Gated by quest completion.
	/// Also sets up rouble purchases for binders and Empty Booster gated by their quests.
	/// </summary>
	public int SetupAll(List<QuestDefinition> allDefinitions, string emptyBoosterId)
	{
		var tables = _db.GetTables();
		if (!tables.Traders.TryGetValue(QuestIds.KolyaTraderId, out var trader) || trader?.Assort == null)
		{
			_logger.Error("[TTC][QuestAssort] Kolya trader not found");
			return 0;
		}

		var questAssortSuccess = trader.QuestAssort?["success"];
		if (questAssortSuccess == null)
		{
			_logger.Error("[TTC][QuestAssort] QuestAssort success dictionary missing");
			return 0;
		}

		int count = 0;

		// Card→item barters gated by card quest completion
		foreach (var def in allDefinitions)
		{
			if (def.BarterUnlock == null) continue;

			var questId = QuestIds.QuestId(def.Seed);
			var barter = def.BarterUnlock;
			var isMultiItem = NeedsRewardCrate(barter);

			if (isMultiItem)
			{
				// Multi-item barter: sell a reward crate (intercepted by RewardCrateRouter)
				var crateTemplateId = QuestIds.CrateTemplateId(def.Seed);
				_crateRegistry.Register(crateTemplateId, barter.Items);

				var assortItemId = AddBarterAssortItem(
					trader.Assort, crateTemplateId, 1, barter.CardTemplateId, 1);

				if (assortItemId is MongoId id)
				{
					questAssortSuccess[id] = new MongoId(questId);
					// Show the reward crate in the AssortmentUnlock UI
					AddAssortmentUnlockReward(tables, questId, def.Seed, crateTemplateId, 1, 0);
					count++;
				}
			}
			else
			{
				// Single-item barter: direct card→item trade
				var item = barter.Items[0];
				var assortItemId = AddBarterAssortItem(
					trader.Assort, item.TemplateId, item.Count, barter.CardTemplateId, 1);

				if (assortItemId is MongoId id)
				{
					questAssortSuccess[id] = new MongoId(questId);
					AddAssortmentUnlockReward(tables, questId, def.Seed, item.TemplateId, item.Count, 0);
					count++;
				}
			}
		}

		// Binder purchases (roubles) gated by binder quest completion
		foreach (var def in allDefinitions)
		{
			// Binder quests have ItemRewards with a binder template and no BarterUnlock
			if (def.BarterUnlock != null) continue;
			if (def.Handover != null) continue; // skip collection quests

			foreach (var reward in def.ItemRewards)
			{
				var binder = _state.Binders?.FirstOrDefault(b => b.id == reward.TemplateId);
				if (binder == null || binder.price <= 0) continue;

				var questId = QuestIds.QuestId(def.Seed);
				var assortItemId = AddRoublePurchaseItem(trader.Assort, binder.id, binder.price, 1);
				if (assortItemId is MongoId id)
				{
					questAssortSuccess[id] = new MongoId(questId);
					AddAssortmentUnlockReward(tables, questId, def.Seed, binder.id, 1, 0);
					count++;
				}
			}
		}

		// Collection barters: trade all cards for the quest reward item, gated by collection quest completion
		foreach (var def in allDefinitions)
		{
			if (def.Handover == null) continue;
			if (def.ItemRewards.Count == 0) continue;

			var questId = QuestIds.QuestId(def.Seed);
			var rewardItem = def.ItemRewards[0];
			var isMultiReward = def.ItemRewards.Count > 1 || rewardItem.Count > 1;

			if (isMultiReward)
			{
				var crateTemplateId = QuestIds.CrateTemplateId(def.Seed);
				var rewardItems = def.ItemRewards.Select(r => new BarterRewardItem { TemplateId = r.TemplateId, Count = r.Count }).ToList();
				_crateRegistry.Register(crateTemplateId, rewardItems);

				var assortItemId = AddCollectionBarterAssortItem(
					trader.Assort, crateTemplateId, 1, def.Handover.CardIds, 1);

				if (assortItemId is MongoId id)
				{
					questAssortSuccess[id] = new MongoId(questId);
					AddAssortmentUnlockReward(tables, questId, def.Seed, crateTemplateId, 1, 0);
					count++;
				}
			}
			else
			{
				var assortItemId = AddCollectionBarterAssortItem(
					trader.Assort, rewardItem.TemplateId, rewardItem.Count, def.Handover.CardIds, 1);

				if (assortItemId is MongoId id)
				{
					questAssortSuccess[id] = new MongoId(questId);
					AddAssortmentUnlockReward(tables, questId, def.Seed, rewardItem.TemplateId, rewardItem.Count, 0);
					count++;
				}
			}
		}

		// Empty Booster purchase (roubles) gated by introduction quest
		if (!string.IsNullOrWhiteSpace(emptyBoosterId))
		{
			var boosterPrice = _state.EmptyBooster?.price ?? 5000;
			if (boosterPrice > 0)
			{
				var introQuestId = QuestIds.QuestId("ttc_quest_introduction");
				var assortItemId = AddRoublePurchaseItem(trader.Assort, emptyBoosterId, boosterPrice, 1);
				if (assortItemId is MongoId boosterId)
				{
					questAssortSuccess[boosterId] = new MongoId(introQuestId);
					AddAssortmentUnlockReward(tables, introQuestId, "ttc_quest_introduction", emptyBoosterId, 1, 0);
					count++;
				}
			}
		}

		return count;
	}

	/// <summary>
	/// Add an assort item purchasable with roubles (for binders and Empty Booster).
	/// </summary>
	private MongoId? AddRoublePurchaseItem(TraderAssort assort, string templateId, int price, int loyaltyLevel)
	{
		if (assort.Items is not List<Item> items
			|| assort.BarterScheme is not Dictionary<MongoId, List<List<BarterScheme>>> bs
			|| assort.LoyalLevelItems is not Dictionary<MongoId, int> lli)
			return null;

		var newIdStr = Guid.NewGuid().ToString("N")[..24];
		var newId = new MongoId(newIdStr);

		items.Add(new Item
		{
			Id = newId,
			Template = new MongoId(templateId),
			ParentId = "hideout",
			SlotId = "hideout",
			Upd = new Upd
			{
				UnlimitedCount = true,
				StackObjectsCount = int.MaxValue
			}
		});

		bs[newId] = new() { new() { new BarterScheme { Template = new MongoId(RoubleTpl), Count = price } } };
		lli[newId] = loyaltyLevel;

		return newId;
	}

	/// <summary>
	/// Add an assort item that the player receives, with BarterScheme requiring a card as payment.
	/// </summary>
	private MongoId? AddBarterAssortItem(TraderAssort assort, string rewardTemplateId, int rewardCount, string cardTemplateId, int loyaltyLevel)
	{
		if (assort.Items is not List<Item> items
			|| assort.BarterScheme is not Dictionary<MongoId, List<List<BarterScheme>>> bs
			|| assort.LoyalLevelItems is not Dictionary<MongoId, int> lli)
			return null;

		var newIdStr = Guid.NewGuid().ToString("N")[..24];
		var newId = new MongoId(newIdStr);

		// The item the player RECEIVES
		items.Add(new Item
		{
			Id = newId,
			Template = new MongoId(rewardTemplateId),
			ParentId = "hideout",
			SlotId = "hideout",
			Upd = new Upd
			{
				UnlimitedCount = true,
				StackObjectsCount = rewardCount > 1 ? rewardCount : int.MaxValue
			}
		});

		// The COST: 1x card
		bs[newId] = new()
		{
			new()
			{
				new BarterScheme
				{
					Template = new MongoId(cardTemplateId),
					Count = 1
				}
			}
		};

		lli[newId] = loyaltyLevel;

		return newId;
	}

	/// <summary>
	/// Add an assort item that the player receives, with BarterScheme requiring multiple cards as payment (collection barter).
	/// </summary>
	private MongoId? AddCollectionBarterAssortItem(TraderAssort assort, string rewardTemplateId, int rewardCount, List<string> cardTemplateIds, int loyaltyLevel)
	{
		if (assort.Items is not List<Item> items
			|| assort.BarterScheme is not Dictionary<MongoId, List<List<BarterScheme>>> bs
			|| assort.LoyalLevelItems is not Dictionary<MongoId, int> lli)
			return null;

		var newIdStr = Guid.NewGuid().ToString("N")[..24];
		var newId = new MongoId(newIdStr);

		items.Add(new Item
		{
			Id = newId,
			Template = new MongoId(rewardTemplateId),
			ParentId = "hideout",
			SlotId = "hideout",
			Upd = new Upd
			{
				UnlimitedCount = true,
				StackObjectsCount = rewardCount > 1 ? rewardCount : int.MaxValue
			}
		});

		// Cost: one of each card
		var barterCost = cardTemplateIds.Select(cardTpl => new BarterScheme
		{
			Template = new MongoId(cardTpl),
			Count = 1
		}).ToList();

		bs[newId] = new() { barterCost };
		lli[newId] = loyaltyLevel;

		return newId;
	}

	/// <summary>
	/// A barter needs a reward crate if it has multiple distinct items or any item with Count > 1.
	/// </summary>
	private static bool NeedsRewardCrate(BarterUnlock barter)
		=> barter.Items.Count > 1 || barter.Items.Any(i => i.Count > 1);

	/// <summary>
	/// Injects an AssortmentUnlock reward into the quest so the UI shows
	/// "You will be able to purchase this item from Kolya (1LL) as a reward".
	/// </summary>
	private void AddAssortmentUnlockReward(DatabaseTables tables, string questId, string questSeed, string templateId, int count, int barterIdx)
	{
		if (!tables.Templates.Quests.TryGetValue(questId, out var quest))
			return;

		var successRewards = quest.Rewards?.GetValueOrDefault("Success");
		if (successRewards == null) return;

		var rewardIdx = successRewards.Count;
		var rewardId = new MongoId(QuestIds.RewardId(questSeed, rewardIdx + 50 + barterIdx * 2));
		var itemId = new MongoId(QuestIds.RewardId(questSeed, rewardIdx + 51 + barterIdx * 2));

		successRewards.Add(new Reward
		{
			Id = rewardId,
			Type = RewardType.AssortmentUnlock,
			Index = rewardIdx,
			Target = itemId,
			TraderId = QuestIds.KolyaTraderId,
			LoyaltyLevel = 1,
			Items = new List<Item>
			{
				new Item
				{
					Id = itemId,
					Template = new MongoId(templateId),
					Upd = count > 1 ? new Upd { StackObjectsCount = count } : null
				}
			}
		});
	}
}
