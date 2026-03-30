using System.Globalization;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Utils;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Utils.Json;
using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Builds TTC quest definitions for registration via CustomQuestService.
/// </summary>
public sealed class QuestFactory
{
	private static readonly string RoubleTpl = "5449016a4bdc2d6f028b456f";
	private readonly DatabaseService _db;
	private readonly Dictionary<string, List<string>> _parentClassCache = new();
	private HashSet<string>? _ttcItemIds;

	public QuestFactory(DatabaseService db)
	{
		_db = db;
	}

	/// <summary>
	/// Set TTC custom item IDs to exclude from HandoverItem category resolution.
	/// </summary>
	public void SetTtcItemIds(IEnumerable<string> ids)
	{
		_ttcItemIds = new HashSet<string>(ids);
	}

	/// <summary>
	/// Resolve HandoverItem targets: if a target is a parent class ID (not a real item),
	/// expand it to all child template IDs of that class. Results are cached.
	/// Excludes TTC custom items (cards, binders, crates) from resolved lists.
	/// </summary>
	private List<string> ResolveHandoverTargets(List<string> targets)
	{
		var resolved = new List<string>();

		foreach (var target in targets)
		{
			// Check cache first
			if (_parentClassCache.TryGetValue(target, out var cached))
			{
				resolved.AddRange(cached);
				continue;
			}

			var items = _db.GetItems();

			// Check if this target is itself an item template
			if (items.ContainsKey(target) && items[target].Type == "Item")
			{
				resolved.Add(target);
			}
			else
			{
				// It's a parent class ID — find all children, excluding TTC custom items
				var children = items
					.Where(kvp => kvp.Value.Parent.ToString() == target && kvp.Value.Type == "Item")
					.Select(kvp => kvp.Key.ToString())
					.Where(id => _ttcItemIds == null || !_ttcItemIds.Contains(id))
					.ToList();

				if (children.Count > 0)
				{
					_parentClassCache[target] = children;
					resolved.AddRange(children);
				}
				else
				{
					resolved.Add(target);
				}
			}
		}

		return resolved;
	}

	/// <summary>
	/// Build the introduction quest — no objectives, instant complete, rewards Empty Booster.
	/// </summary>
	public NewQuestDetails BuildIntroQuest(string emptyBoosterId)
	{
		var questSeed = "ttc_quest_introduction";
		var questId = QuestIds.QuestId(questSeed);
		var traderId = new MongoId(QuestIds.KolyaTraderId);

		int rewardIdx = 0;
		var rewards = new List<Reward>();

		rewards.Add(new Reward
		{
			Id = new MongoId(QuestIds.RewardId(questSeed, rewardIdx++)),
			Type = RewardType.Experience,
			Value = 500,
			Index = rewardIdx
		});

		if (!string.IsNullOrWhiteSpace(emptyBoosterId))
		{
			var boosterRewardId = new MongoId(QuestIds.RewardId(questSeed, rewardIdx++));
			var boosterItemId = new MongoId(QuestIds.RewardId(questSeed, rewardIdx++));
			rewards.Add(new Reward
			{
				Id = boosterRewardId,
				Type = RewardType.Item,
				Value = 1,
				Index = rewardIdx,
				Target = boosterItemId,
				Items = new List<Item>
				{
					new Item
					{
						Id = boosterItemId,
						Template = new MongoId(emptyBoosterId),
						Upd = new Upd { StackObjectsCount = 1 }
					}
				}
			});
		}

		var quest = BuildShell(questId, questSeed, traderId);
		quest.Rewards["Success"] = rewards;

		var locales = new Dictionary<string, string>
		{
			[$"{questId} name"] = "Welcome to the Collection",
			[$"{questId} description"] = "Ah, a new face! Come in, come in. I'm Kolya \u2014 Nikolai Vetrov, if we're being formal. Before all this chaos, I was an archivist for TerraGroup. Now? I document everything I see through these cards. Every boss, every bullet, every absurd death in this forsaken city. I've started a little collection project, and I could use someone with your... field experience. Take this booster pack \u2014 consider it a welcome gift. Open it up, see what you find. If you're interested in more, I've got work for you. Each collection tells a story, and I need help completing them all.",
			[$"{questId} note"] = "Meet Kolya and receive your first booster pack.",
			[$"{questId} successMessageText"] = "Welcome aboard, collector. This is just the beginning.",
			[$"{questId} startedMessageText"] = "Take a look around, friend. I've got plenty of work for someone like you.",
			[$"{questId} acceptPlayerMessage"] = "Sounds interesting. I'm in.",
			[$"{questId} declinePlayerMessage"] = "Maybe another time.",
			[$"{questId} completePlayerMessage"] = "Thanks for the welcome gift, Kolya."
		};

		return new NewQuestDetails
		{
			NewQuest = quest,
			Locales = new Dictionary<string, Dictionary<string, string>> { ["en"] = locales }
		};
	}

	/// <summary>
	/// Build the informational quest for returning players — no objectives, no reward.
	/// </summary>
	public NewQuestDetails BuildInfoQuest()
	{
		var questSeed = "ttc_quest_info_returning";
		var questId = QuestIds.QuestId(questSeed);
		var traderId = new MongoId(QuestIds.KolyaTraderId);

		var quest = BuildShell(questId, questSeed, traderId);

		var locales = new Dictionary<string, string>
		{
			[$"{questId} name"] = "A Note for Returning Collectors",
			[$"{questId} description"] = "Hey, I see you've already got some cards and binders from before I set up shop here. A word of advice \u2014 if you want the full experience of earning each card through my quests, consider selling your existing cards and binders to me. My quests are designed as a progression system: each completed quest unlocks a barter deal for that specific card. If you already have the cards, you'll miss out on the thrill of the hunt. Of course, if you'd rather keep what you have, that's fine too \u2014 you can still do the quests and trade duplicates. Your call, friend.",
			[$"{questId} note"] = "Information for players who already have TTC cards from a previous version.",
			[$"{questId} successMessageText"] = "Good to know you've read it. Now let's get to work.",
			[$"{questId} startedMessageText"] = "Just a heads up for returning collectors.",
			[$"{questId} acceptPlayerMessage"] = "Got it, thanks for the heads up.",
			[$"{questId} declinePlayerMessage"] = "I'll read this later.",
			[$"{questId} completePlayerMessage"] = "Understood, Kolya."
		};

		return new NewQuestDetails
		{
			NewQuest = quest,
			Locales = new Dictionary<string, Dictionary<string, string>> { ["en"] = locales }
		};
	}

	/// <summary>
	/// Build a quest from a QuestDefinition. Handles QE objectives, handover, prerequisites, and rewards.
	/// </summary>
	public NewQuestDetails BuildFromDefinition(QuestDefinition def)
	{
		var questId = QuestIds.QuestId(def.Seed);
		var traderId = new MongoId(QuestIds.KolyaTraderId);
		var quest = BuildShell(questId, def.Seed, traderId, def.Location ?? "any");

		// --- AvailableForStart: prerequisite quest ---
		if (def.PrerequisiteSeed != null)
		{
			var prevQuestId = QuestIds.QuestId(def.PrerequisiteSeed);
			quest.Conditions.AvailableForStart.Add(new QuestCondition
			{
				Id = new MongoId(QuestIds.StartConditionId(def.Seed, 0)),
				ConditionType = "Quest",
				Type = "Quest",
				Status = new HashSet<QuestStatusEnum> { QuestStatusEnum.Success },
				Target = new ListOrT<string>(new List<string> { prevQuestId }, prevQuestId),
				DynamicLocale = true
			});
		}

		// --- AvailableForFinish ---
		int condIdx = 0;
		var locales = new Dictionary<string, string>();

		// HandoverItem conditions
		if (def.Handover != null)
		{
			// Create one condition per card to enforce distinct items
			foreach (var cardId in def.Handover.CardIds)
			{
				var condId = QuestIds.ConditionId(def.Seed, condIdx++);
				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "HandoverItem",
					Type = "HandoverItem",
					Target = new ListOrT<string>(new List<string> { cardId }, null!),
					Value = 1,
					OnlyFoundInRaid = def.Handover.FoundInRaid,
					IsNecessary = true,
					DynamicLocale = false
				});
				var cardName = def.Handover.CardNames?.GetValueOrDefault(cardId);
				locales[condId] = cardName != null ? $"Hand over: {cardName}" : def.Handover.Description;
			}
		}

		// Objectives (CounterCreator conditions)
		foreach (var obj in def.Objectives)
		{
			var condId = QuestIds.ConditionId(def.Seed, condIdx++);

			if (obj.HealthEffectType != null)
			{
				// Vanilla HealthEffect condition (dehydration, pain, tremor, etc.)
				var healthCounterConditions = new List<QuestConditionCounterCondition>
				{
					new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 100)),
						ConditionType = "HealthEffect",
						Target = new ListOrT<string>(new List<string>(), ""),
						BodyPartsWithEffects = new List<EnemyHealthEffect>
						{
							new EnemyHealthEffect
							{
								BodyParts = new List<string> { obj.HealthEffectBodyPart ?? "Stomach" },
								Effects = new List<string> { obj.HealthEffectType }
							}
						}
					}
				};

				if (obj.HealthEffectLocations is { Count: > 0 })
				{
					healthCounterConditions.Add(new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 150)),
						ConditionType = "Location",
						Target = new ListOrT<string>(obj.HealthEffectLocations, null!)
					});
				}

				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "CounterCreator",
					Type = "Completion",
					Value = obj.Value,
					CompleteInSeconds = obj.HealthEffectDuration ?? 0,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string>(), ""),
					Counter = new QuestConditionCounter
					{
						Id = QuestIds.ConditionId(def.Seed, condIdx + 200),
						Conditions = healthCounterConditions
					}
				});
			}
			else if (obj.HideoutAreaType != null)
			{
				// Vanilla HideoutArea condition (top-level, not CounterCreator)
				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "HideoutArea",
					Type = "HideoutArea",
					Value = obj.HideoutAreaLevel ?? 1,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string>(), ""),
					AreaType = (SPTarkov.Server.Core.Models.Enums.Hideout.HideoutAreas)obj.HideoutAreaType.Value,
					CompareMethod = ">="
				});
			}
			else if (obj.HandoverTargets != null)
			{
				// Generic HandoverItem condition (hand over items by template or category)
				// Resolve parent class IDs to actual template IDs
				var resolvedTargets = ResolveHandoverTargets(obj.HandoverTargets);
				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "HandoverItem",
					Type = "HandoverItem",
					Target = new ListOrT<string>(resolvedTargets, null!),
					Value = obj.Value,
					OnlyFoundInRaid = false,
					IsNecessary = true,
					DynamicLocale = false
				});
			}
			else if (obj.TraderLoyaltyId != null)
			{
				// Vanilla TraderLoyalty condition (top-level, not CounterCreator)
				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "TraderLoyalty",
					Type = "TraderLoyalty",
					Value = obj.TraderLoyaltyLevel ?? 1,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string> { obj.TraderLoyaltyId }, obj.TraderLoyaltyId),
					CompareMethod = ">="
				});
			}
			else if (obj.VisitZoneId != null)
			{
				// Vanilla VisitPlace condition
				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "CounterCreator",
					Type = "Exploration",
					Value = obj.Value,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string>(), ""),
					Counter = new QuestConditionCounter
					{
						Id = QuestIds.ConditionId(def.Seed, condIdx + 200),
						Conditions = new List<QuestConditionCounterCondition>
						{
							new QuestConditionCounterCondition
							{
								Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 100)),
								ConditionType = "VisitPlace",
								Target = new ListOrT<string>(new List<string> { obj.VisitZoneId }, obj.VisitZoneId),
							}
						}
					}
				});
			}
			else if (obj.SurviveLocations != null)
			{
				// Vanilla Survive & Extract (ExitStatus + Location)
				var counterConditions = new List<QuestConditionCounterCondition>
				{
					new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 100)),
						ConditionType = "ExitStatus",
						Target = new ListOrT<string>(new List<string>(), ""),
						Status = new List<string> { "Survived", "Runner", "Transit" }
					},
					new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 150)),
						ConditionType = "Location",
						Target = new ListOrT<string>(obj.SurviveLocations, null!)
					}
				};

				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "CounterCreator",
					Type = "Completion",
					Value = obj.Value,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string>(), ""),
					Counter = new QuestConditionCounter
					{
						Id = QuestIds.ConditionId(def.Seed, condIdx + 200),
						Conditions = counterConditions
					}
				});
			}
			else if (obj.ExitNameId != null)
			{
				// Vanilla ExitName (extract through specific exit)
				var counterConditions = new List<QuestConditionCounterCondition>
				{
					new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 100)),
						ConditionType = "ExitName",
						Target = new ListOrT<string>(new List<string>(), ""),
						ExitName = obj.ExitNameId
					},
					new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 110)),
						ConditionType = "ExitStatus",
						Target = new ListOrT<string>(new List<string>(), ""),
						Status = new List<string> { "Survived", "Runner", "Transit" }
					}
				};

				if (obj.ExitLocations is { Count: > 0 })
				{
					counterConditions.Add(new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 150)),
						ConditionType = "Location",
						Target = new ListOrT<string>(obj.ExitLocations, null!)
					});
				}

				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "CounterCreator",
					Type = "Completion",
					Value = obj.Value,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string>(), ""),
					Counter = new QuestConditionCounter
					{
						Id = QuestIds.ConditionId(def.Seed, condIdx + 200),
						Conditions = counterConditions
					}
				});
			}
			else if (obj.KillTarget != null)
			{
				// Vanilla Kills condition
				var counterConditions = new List<QuestConditionCounterCondition>();

				var killCondition = new QuestConditionCounterCondition
				{
					Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 100)),
					ConditionType = "Kills",
					Target = new ListOrT<string>(new List<string> { obj.KillTarget }, obj.KillTarget),
					Distance = new CounterConditionDistance
					{
						CompareMethod = obj.KillDistanceCompare ?? ">=",
						Value = obj.KillDistanceValue ?? 0
					}
				};
				if (obj.KillBodyParts is { Count: > 0 })
					killCondition.BodyPart = obj.KillBodyParts;
				if (obj.KillSavageRole is { Count: > 0 })
					killCondition.SavageRole = obj.KillSavageRole;
				if (obj.KillWeapons is { Count: > 0 })
					killCondition.Weapon = obj.KillWeapons.ToHashSet();
				if (obj.KillWeaponModsInclusive is { Count: > 0 })
					killCondition.WeaponModsInclusive = obj.KillWeaponModsInclusive.Select(l => l.ToList()).ToList();
				if (obj.KillWeaponModsExclusive is { Count: > 0 })
					killCondition.WeaponModsExclusive = obj.KillWeaponModsExclusive.Select(l => l.ToList()).ToList();
				if (obj.KillWeaponCaliber is { Count: > 0 })
					killCondition.WeaponCaliber = obj.KillWeaponCaliber;
				if (obj.KillDaytimeFrom != null || obj.KillDaytimeTo != null)
					killCondition.Daytime = new DaytimeCounter { From = obj.KillDaytimeFrom ?? 0, To = obj.KillDaytimeTo ?? 0 };
				if (obj.KillResetOnSessionEnd)
					killCondition.ResetOnSessionEnd = true;
				counterConditions.Add(killCondition);

				if (obj.KillLocations is { Count: > 0 })
				{
					counterConditions.Add(new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 150)),
						ConditionType = "Location",
						Target = new ListOrT<string>(obj.KillLocations, null!)
					});
				}

				if (obj.KillEquipmentGroups is { Count: > 0 })
				{
					int equipIdx = 0;
					foreach (var equipGroup in obj.KillEquipmentGroups)
					{
						counterConditions.Add(new QuestConditionCounterCondition
						{
							Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 160 + equipIdx)),
							ConditionType = "Equipment",
							Target = new ListOrT<string>(new List<string>(), ""),
							EquipmentInclusive = equipGroup.Select(l => l.ToList()).ToList()
						});
						equipIdx++;
					}
				}

				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "CounterCreator",
					Type = "Elimination",
					Value = obj.Value,
					IsNecessary = true,
					DynamicLocale = false,
					OneSessionOnly = obj.OneSessionOnly ? true : null,
					Target = new ListOrT<string>(new List<string>(), ""),
					Counter = new QuestConditionCounter
					{
						Id = QuestIds.ConditionId(def.Seed, condIdx + 200),
						Conditions = counterConditions
					}
				});
			}
			else
			{
				// QE condition: impossible server-side condition, QuestsExtended tracks the real objective
				quest.Conditions.AvailableForFinish.Add(new QuestCondition
				{
					Id = new MongoId(condId),
					ConditionType = "CounterCreator",
					Type = MapQeToEQuestType(obj.ConditionType),
					Value = obj.Value,
					IsNecessary = true,
					DynamicLocale = false,
					Target = new ListOrT<string>(new List<string>(), ""),
					Counter = new QuestConditionCounter
					{
						Id = QuestIds.ConditionId(def.Seed, condIdx + 200),
						Conditions = new List<QuestConditionCounterCondition>
						{
							new QuestConditionCounterCondition
							{
								Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 100)),
								ConditionType = "Kills",
								Target = new ListOrT<string>(new List<string> { "Savage" }, "Savage"),
								Distance = new CounterConditionDistance
								{
									CompareMethod = ">=",
									Value = 5555
								}
							}
						}
					}
				});
			}
			locales[condId] = obj.Description;
		}


		// --- Rewards ---
		int rewardIdx = 0;
		var rewards = new List<Reward>();

		// XP
		if (def.XpReward > 0)
		{
			rewards.Add(new Reward
			{
				Id = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++)),
				Type = RewardType.Experience,
				Value = def.XpReward,
				Index = rewardIdx
			});
		}

		// Roubles
		if (def.RoubleReward > 0)
		{
			var roubleRewardId = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++));
			var roubleItemId = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++));
			rewards.Add(new Reward
			{
				Id = roubleRewardId,
				Type = RewardType.Item,
				Value = def.RoubleReward,
				Index = rewardIdx,
				Target = roubleItemId,
				Items = new List<Item>
				{
					new Item
					{
						Id = roubleItemId,
						Template = new MongoId(RoubleTpl),
						Upd = new Upd { StackObjectsCount = def.RoubleReward }
					}
				}
			});
		}

		// Standing
		if (def.StandingReward > 0)
		{
			rewards.Add(new Reward
			{
				Id = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++)),
				Type = RewardType.TraderStanding,
				Value = def.StandingReward,
				Target = QuestIds.KolyaTraderId,
				TraderId = QuestIds.KolyaTraderId,
				Index = rewardIdx
			});
		}

		// Item rewards
		foreach (var item in def.ItemRewards)
		{
			var itemRewardId = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++));
			var itemId = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++));
			rewards.Add(new Reward
			{
				Id = itemRewardId,
				Type = RewardType.Item,
				Value = item.Count,
				Index = rewardIdx,
				Target = itemId,
				Items = new List<Item>
				{
					new Item
					{
						Id = itemId,
						Template = new MongoId(item.TemplateId),
						Upd = new Upd { StackObjectsCount = item.Count }
					}
				}
			});
		}

		quest.Rewards["Success"] = rewards;

		// --- Locales ---
		locales[$"{questId} name"] = def.Locale.Name;
		locales[$"{questId} description"] = def.Locale.Description;
		locales[$"{questId} note"] = def.Locale.Note;
		locales[$"{questId} successMessageText"] = def.Locale.SuccessMessage;
		locales[$"{questId} startedMessageText"] = def.Locale.StartedMessage;
		locales[$"{questId} acceptPlayerMessage"] = def.Locale.AcceptMessage;
		locales[$"{questId} declinePlayerMessage"] = def.Locale.DeclineMessage;
		locales[$"{questId} completePlayerMessage"] = def.Locale.CompleteMessage;

		return new NewQuestDetails
		{
			NewQuest = quest,
			Locales = new Dictionary<string, Dictionary<string, string>> { ["en"] = locales }
		};
	}

	/// <summary>
	/// Maps QE condition types to valid client-side EQuestType values.
	/// </summary>
	private static string MapQeToEQuestType(string qeConditionType) => qeConditionType switch
	{
		// Kill-related
		"KillsWhileADS" or "KillsWithoutADS" or "KillsWhileCrouched" or "KillsWhileProne"
			or "KillsWhileMounted" or "KillsWhileSilent" or "KillsWhileBlindFiring"
			or "RevolverKillsWithoutADS" or "MountedKillsWithLMG" => "Elimination",
		// Damage-related
		"DamageWithAR" or "DamageWithDMR" or "DamageWithLMG" or "DamageWithPistols"
			or "DamageWithRevolvers" or "DamageWithShotguns" or "DamageWithSMG" or "DamageWithAny"
			or "DamageToArmour" or "DamageToArmourWithShotguns"
			or "TotalShotDistanceWithSnipers" or "DestroyLegsWithSMG" => "Elimination",
		// Everything else
		_ => "Completion"
	};

	/// <summary>
	/// Creates a bare quest shell with empty conditions and rewards.
	/// </summary>
	private static Quest BuildShell(string questId, string questSeed, MongoId traderId, string location = "any")
	{
		return new Quest
		{
			Id = new MongoId(questId),
			QuestName = $"{questId} name",
			Image = $"/files/quest/icon/{questSeed}.png",
			TraderId = traderId,
			Location = location,
			Type = QuestTypeEnum.Completion,
			Restartable = false,
			InstantComplete = false,
			SecretQuest = false,
			CanShowNotificationsInGame = true,
			Name = $"{questId} name",
			Description = $"{questId} description",
			SuccessMessageText = $"{questId} successMessageText",
			FailMessageText = "",
			StartedMessageText = $"{questId} startedMessageText",
			AcceptPlayerMessage = $"{questId} acceptPlayerMessage",
			DeclinePlayerMessage = $"{questId} declinePlayerMessage",
			CompletePlayerMessage = $"{questId} completePlayerMessage",
			ChangeQuestMessageText = "",
			Note = $"{questId} note",
			TemplateId = questId,
			Side = "Pmc",
			Conditions = new QuestConditionTypes
			{
				AvailableForStart = new List<QuestCondition>(),
				AvailableForFinish = new List<QuestCondition>(),
				Fail = new List<QuestCondition>()
			},
			Rewards = new Dictionary<string, List<Reward>>
			{
				["Started"] = new List<Reward>(),
				["Success"] = new List<Reward>(),
				["Fail"] = new List<Reward>()
			}
		};
	}

	/// <summary>
	/// Converts snake_case theme names from cards.json to display-friendly title case.
	/// </summary>
	internal static string FormatThemeName(string rawTheme)
	{
		var words = rawTheme.Replace('_', ' ').Split(' ');
		var ti = CultureInfo.InvariantCulture.TextInfo;
		for (int i = 0; i < words.Length; i++)
		{
			if (words[i] is "and" or "of" or "to" or "the" or "vs" && i > 0)
				continue;
			words[i] = ti.ToTitleCase(words[i]);
		}
		return string.Join(" ", words)
			.Replace("Spt", "SPT")
			.Replace("Eft", "EFT")
			.Replace("Pmc", "PMC");
	}
}
