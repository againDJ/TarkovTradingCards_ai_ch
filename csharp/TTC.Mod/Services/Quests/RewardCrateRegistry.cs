using SPTarkov.DI.Annotations;
using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Maps reward crate template IDs to the items they should contain.
/// Populated by QuestAssortService, consumed by RewardCrateRouter.
/// </summary>
public sealed class RewardCrateRegistry
{
	private readonly Dictionary<string, List<BarterRewardItem>> _contents = new();

	/// <summary>Register a crate template and its fixed reward items.</summary>
	public void Register(string crateTemplateId, List<BarterRewardItem> items)
		=> _contents[crateTemplateId] = items;

	/// <summary>Get the reward items for a crate template, or null if not a crate.</summary>
	public List<BarterRewardItem>? GetContents(string crateTemplateId)
		=> _contents.GetValueOrDefault(crateTemplateId);

	/// <summary>Check if a template ID is a registered reward crate.</summary>
	public bool IsCrate(string templateId) => _contents.ContainsKey(templateId);

	/// <summary>True if any crates have been registered.</summary>
	public bool HasAnyCrates => _contents.Count > 0;

	/// <summary>All registered crate template IDs.</summary>
	public IEnumerable<string> AllCrateTemplateIds => _contents.Keys;
}
