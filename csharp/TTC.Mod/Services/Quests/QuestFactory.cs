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
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Builds TTC quest definitions for registration via CustomQuestService.
/// </summary>
public sealed class QuestFactory
{
	private static readonly string RoubleTpl = "5449016a4bdc2d6f028b456f";
	private static readonly List<string> AllMapIds = new()
	{
		"bigmap", "factory4_day", "factory4_night", "Interchange", "Woods",
		"Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory",
		"Sandbox", "Sandbox_high"
	};
	private static readonly string[] AllLocaleCodes = { "ch", "cz", "en", "es-mx", "es", "fr", "ge", "hu", "it", "jp", "kr", "pl", "po", "ro", "ru", "sk", "tu" };

	/// <summary>Replicate locale entries across all supported languages (English text as fallback).</summary>
	private static Dictionary<string, Dictionary<string, string>> AllLocales(Dictionary<string, string> entries)
		=> AllLocaleCodes.ToDictionary(lang => lang, _ => entries);
	private readonly DatabaseService _db;
	private readonly State _state;
	private readonly Dictionary<string, List<string>> _parentClassCache = new();
	private HashSet<string>? _ttcItemIds;

	public QuestFactory(DatabaseService db, State state)
	{
		_db = db;
		_state = state;
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
	/// 5 random cards are sent separately via mail when the quest is completed (handled by RewardCrateRouter).
	/// </summary>
	public NewQuestDetails BuildIntroQuest(string emptyBoosterId)
	{
		var questSeed = "ttc_quest_introduction";
		var questId = QuestIds.QuestId(questSeed);
		var traderId = new MongoId(QuestIds.KolyaTraderId);

		int rewardIdx = 0;
		var rewards = new List<Reward>();

		// 5 random cards + 1 Empty Booster are sent via mail on quest completion (see RewardCrateRouter)

		var quest = BuildShell(questId, questSeed, traderId);
		quest.Rewards["Success"] = rewards;

		var locales = new Dictionary<string, string>
		{
			[$"{questId} name"] = "欢迎加入收藏",
			[$"{questId} description"] = "\u554a\uff0c\u65b0\u9762\u5b54\uff01\u8fdb\u6765\uff0c\u8fdb\u6765\u3002\u6211\u662fKolya\u2014\u2014\u6b63\u5f0f\u70b9\u8bf4\uff0c\u5c3c\u53e4\u62c9\u00b7\u7ef4\u7279\u7f57\u592b\u3002\u5728\u8fd9\u573a\u6df7\u4e71\u4e4b\u524d\uff0c\u6211\u662fTerraGroup\u7684\u6863\u6848\u7ba1\u7406\u5458\u3002\u73b0\u5728\uff1f\u6211\u7528\u8fd9\u4e9b\u5361\u724c\u8bb0\u5f55\u6211\u770b\u5230\u7684\u4e00\u5207\u3002\u6bcf\u4e00\u4e2aBoss\uff0c\u6bcf\u4e00\u53d1\u5b50\u5f39\uff0c\u8fd9\u5ea7\u88ab\u9057\u5f03\u57ce\u5e02\u91cc\u6bcf\u4e00\u6b21\u8352\u8c2c\u7684\u6b7b\u4ea1\u3002\u6211\u641e\u4e86\u4e2a\u5c0f\u5c0f\u7684\u6536\u85cf\u9879\u76ee\uff0c\u800c\u6709\u4f60\u8fd9\u6837\u2026\u2026\u5b9e\u6218\u7ecf\u9a8c\u7684\u4eba\u6b63\u5408\u9002\u3002\u62ff\u7740\u8fd9\u4e2a\u5361\u5305\u2014\u2014\u5c31\u5f53\u662f\u6b22\u8fce\u793c\u7269\u3002\u4ece\u6211\u6863\u6848\u91cc\u968f\u673a\u62bd\u7684\u4e94\u5f20\u5361\u3002\u7ed9\u4f60\u4e2a\u5efa\u8bae\uff1a\u597d\u597d\u4fdd\u7ba1\u3002\u6bcf\u4e00\u5f20\u5361\u90fd\u53ef\u4ee5\u627e\u6211\u6362\u6709\u7528\u7684\u4e1c\u897f\u2014\u2014\u6b66\u5668\u3001\u88c5\u5907\u3001\u94a5\u5319\uff0c\u5e94\u6709\u5c3d\u6709\u3002\u5361\u8d8a\u7a00\u6709\uff0c\u5956\u52b1\u8d8a\u597d\u3002\u60f3\u4e70\u66f4\u591a\u5361\u5305\u7684\u8bdd\uff0c\u6211\u4e5f\u5356\u3002\u5982\u679c\u4f60\u5bf9\u5b9a\u5411\u6536\u85cf\u611f\u5174\u8da3\uff0c\u6211\u4e5f\u6709\u6d3b\u7ed9\u4f60\u5e72\u3002\u6bcf\u4e2a\u7cfb\u5217\u90fd\u6709\u4e00\u6bb5\u6545\u4e8b\uff0c\u6211\u9700\u8981\u5e2e\u624b\u628a\u5b83\u4eec\u51d1\u9f50\u3002",
			[$"{questId} note"] = "结识Kolya并领取你的第一个卡包。",
			[$"{questId} successMessageText"] = "欢迎加入，收藏家。这只是个开始。",
			[$"{questId} startedMessageText"] = "随便看看，朋友。像你这样的人，我有很多活给你。",
			[$"{questId} acceptPlayerMessage"] = "听起来有意思，算我一个。",
			[$"{questId} declinePlayerMessage"] = "下次再说。",
			[$"{questId} completePlayerMessage"] = "谢谢你的欢迎礼物，Kolya。"
		};

		return new NewQuestDetails
		{
			NewQuest = quest,
			Locales = AllLocales(locales)
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
			[$"{questId} name"] = "给回归收藏家的提示",
			[$"{questId} description"] = "\u563f\uff0c\u6211\u770b\u4f60\u5728\u6211\u5f00\u5e97\u4e4b\u524d\u5c31\u5df2\u7ecf\u641e\u5230\u4e86\u4e00\u4e9b\u5361\u724c\u548c\u5361\u518c\u3002\u7ed9\u4f60\u4e2a\u5efa\u8bae\u2014\u2014\u5982\u679c\u4f60\u60f3\u4f53\u9a8c\u901a\u8fc7\u4efb\u52a1\u6323\u6bcf\u5f20\u5361\u7684\u5b8c\u6574\u8fc7\u7a0b\uff0c\u53ef\u4ee5\u8003\u8651\u628a\u4f60\u73b0\u6709\u7684\u5361\u724c\u548c\u5361\u518c\u5356\u7ed9\u6211\u3002\u6211\u7684\u4efb\u52a1\u662f\u4e00\u4e2a\u8fdb\u5ea6\u7cfb\u7edf\uff1a\u6bcf\u5b8c\u6210\u4e00\u4e2a\u4efb\u52a1\uff0c\u5c31\u89e3\u9501\u90a3\u5f20\u5361\u5bf9\u5e94\u7684\u4ea4\u6613\u3002\u5982\u679c\u4f60\u5df2\u7ecf\u6709\u4e86\u90a3\u4e9b\u5361\uff0c\u5c31\u9519\u8fc7\u4e86\u72e9\u730e\u7684\u4e50\u8da3\u3002\u5f53\u7136\uff0c\u5982\u679c\u4f60\u60f3\u7559\u7740\u4f60\u624b\u5934\u7684\u4e1c\u897f\uff0c\u4e5f\u6ca1\u5173\u7cfb\u2014\u2014\u4f60\u8fd8\u662f\u53ef\u4ee5\u505a\u4efb\u52a1\uff0c\u7528\u91cd\u590d\u7684\u5361\u6765\u4ea4\u6613\u3002\u4f60\u8bf4\u4e86\u7b97\uff0c\u670b\u53cb\u3002",
			[$"{questId} note"] = "给已拥有旧版TTC卡牌的玩家的信息。",
			[$"{questId} successMessageText"] = "很好，你看过了。现在开始干活吧。",
			[$"{questId} startedMessageText"] = "给回归收藏家的一个小提示。",
			[$"{questId} acceptPlayerMessage"] = "明白了，谢谢提醒。",
			[$"{questId} declinePlayerMessage"] = "回头再读。",
			[$"{questId} completePlayerMessage"] = "了解，Kolya。"
		};

		return new NewQuestDetails
		{
			NewQuest = quest,
			Locales = AllLocales(locales)
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
		foreach (var rawObj in def.Objectives)
		{
			// Auto-fill SurviveLocations for "Survive" conditions without explicit maps
			var obj = rawObj;
			if (obj.ConditionType == "Survive" && obj.SurviveLocations == null)
			{
				obj = obj with { SurviveLocations = AllMapIds };
			}

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

				if (obj.KillZoneIds is { Count: > 0 })
				{
					counterConditions.Add(new QuestConditionCounterCondition
					{
						Id = new MongoId(QuestIds.ConditionId(def.Seed, condIdx + 155)),
						ConditionType = "InZone",
						Zones = obj.KillZoneIds
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

		// Standing — auto-assign based on XP (rarity) if not explicitly set
		var standing = def.StandingReward;
		if (standing <= 0 && def.XpReward > 0)
		{
			standing = def.XpReward switch
			{
				1000 => 0.01,   // Common
				3000 => 0.02,   // Uncommon
				10000 => 0.03,  // Rare
				20000 => 0.05,  // Epic
				35000 => 0.08,  // Legendary
				60000 => 0.10,  // Secret
				_ => 0
			};
		}
		if (standing > 0)
		{
			rewards.Add(new Reward
			{
				Id = new MongoId(QuestIds.RewardId(def.Seed, rewardIdx++)),
				Type = RewardType.TraderStanding,
				Value = standing,
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
			Locales = AllLocales(locales)
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
			or "DamageWithThrowables" or "DamageToArmour" or "DamageToArmourWithShotguns"
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

	// Booster pack rarity weights: 40% C, 30% U, 20% R, 8% E, 1.5% L, 0.5% S
	private static readonly (string rarity, double weight)[] BoosterRarityWeights =
	{
		("Common", 40.0), ("Uncommon", 30.0), ("Rare", 20.0),
		("Epic", 8.0), ("Legendary", 1.5), ("Secret", 0.5)
	};

	/// <summary>
	/// Pick N cards using weighted rarity distribution (same weights as Booster Pack).
	/// </summary>
	private List<string> PickRandomCards(int count)
	{
		var cardsByRarity = new Dictionary<string, List<string>>();
		foreach (var card in _state.Cards)
		{
			if (!cardsByRarity.ContainsKey(card.rarity))
				cardsByRarity[card.rarity] = new List<string>();
			cardsByRarity[card.rarity].Add(card.id);
		}

		var result = new List<string>();
		var random = new Random();
		for (int i = 0; i < count; i++)
		{
			var roll = random.NextDouble() * 100.0;
			double cumulative = 0;
			string selectedRarity = "Common";
			foreach (var (rarity, weight) in BoosterRarityWeights)
			{
				cumulative += weight;
				if (roll < cumulative) { selectedRarity = rarity; break; }
			}

			if (cardsByRarity.TryGetValue(selectedRarity, out var pool) && pool.Count > 0)
				result.Add(pool[random.Next(pool.Count)]);
		}
		return result;
	}
}
