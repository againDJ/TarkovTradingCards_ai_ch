using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Type of random reward generator for special crates.
/// </summary>
public enum RandomRewardType
{
	ScavCase2500,       // 2,500₽ — mostly common
	ScavCase15000,      // 15,000₽ — common + rare
	ScavCase95000,      // 95,000₽ — rare + superrare
	ScavCaseMoonshine,  // Moonshine — superrare heavy
	ScavCaseIntel,      // Intelligence folder — best odds
	CultistCircle,      // 5M rouble budget, includes quest/hideout items
	RandomMeds,         // Random pick from all medkits, drugs, and stimulators
	RandomKeys          // Random pick from all mechanical keys (no keycards)
}

[Injectable]
/// <summary>
/// Maps reward crate template IDs to the items they should contain (fixed or random).
/// Populated by QuestAssortService, consumed by RewardCrateRouter.
/// </summary>
public sealed class RewardCrateRegistry
{
	private readonly Dictionary<string, List<BarterRewardItem>> _contents = new();
	private readonly Dictionary<string, RandomRewardType> _randomRewards = new();
	private readonly Dictionary<string, int> _randomCounts = new();

	/// <summary>Register a crate template and its fixed reward items.</summary>
	public void Register(string crateTemplateId, List<BarterRewardItem> items)
		=> _contents[crateTemplateId] = items;

	/// <summary>Register a crate template with a random reward generator and optional roll count.</summary>
	public void RegisterRandom(string crateTemplateId, RandomRewardType rewardType, int count = 1)
	{
		_randomRewards[crateTemplateId] = rewardType;
		if (count > 1) _randomCounts[crateTemplateId] = count;
	}

	/// <summary>Get the fixed reward items for a crate template, or null if not a fixed crate.</summary>
	public List<BarterRewardItem>? GetContents(string crateTemplateId)
		=> _contents.GetValueOrDefault(crateTemplateId);

	/// <summary>Get the random reward type for a crate, or null if not a random crate.</summary>
	public RandomRewardType? GetRandomType(string crateTemplateId)
		=> _randomRewards.TryGetValue(crateTemplateId, out var type) ? type : null;

	/// <summary>Get the number of random reward rolls for a crate (defaults to 1).</summary>
	public int GetRandomCount(string crateTemplateId)
		=> _randomCounts.GetValueOrDefault(crateTemplateId, 1);

	/// <summary>Check if a template ID is a registered reward crate (fixed or random).</summary>
	public bool IsCrate(string templateId) => _contents.ContainsKey(templateId) || _randomRewards.ContainsKey(templateId);

	/// <summary>True if any crates have been registered.</summary>
	public bool HasAnyCrates => _contents.Count > 0 || _randomRewards.Count > 0;

	/// <summary>All registered crate template IDs (fixed + random).</summary>
	public IEnumerable<string> AllCrateTemplateIds => _contents.Keys.Concat(_randomRewards.Keys).Distinct();
}
