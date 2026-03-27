using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Spt.Server;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using TTC.Mod.Models;
using TTC.Mod.Services.Common;
using TTC.Mod.Services.Quests;

namespace TTC.Mod.Services.Containers;

[Injectable]
/// <summary>
/// Creates "Kolya's Reward Package" item templates for each multi-item barter.
/// These items are purchased from Kolya, then intercepted by RewardCrateRouter
/// which removes them and sends the actual reward items via mail.
/// Each crate gets a unique description listing its contents.
/// </summary>
public sealed class RewardCrateFactory
{
	private readonly State _state;
	private readonly DatabaseService _db;
	private readonly LocaleService _localeService;
	private readonly CustomItemService _customItemService;

	public RewardCrateFactory(State state, DatabaseService db, LocaleService localeService, CustomItemService customItemService)
	{
		_state = state;
		_db = db;
		_localeService = localeService;
		_customItemService = customItemService;
	}

	/// <summary>
	/// Create item templates for all registered reward crates.
	/// </summary>
	/// <returns>(created, failed) counts.</returns>
	public (int created, int failed) CreateAll(RewardCrateRegistry registry)
	{
		int created = 0, failed = 0;
		var containerBase = _state.ContainerBase;
		var gameLocale = _localeService.GetDesiredGameLocale();

		foreach (var crateTemplateId in registry.AllCrateTemplateIds)
		{
			var contents = registry.GetContents(crateTemplateId);
			var ok = CreateCrate(crateTemplateId, contents, containerBase, gameLocale);
			if (ok) created++; else failed++;
		}

		return (created, failed);
	}

	private bool CreateCrate(string crateTemplateId, List<BarterRewardItem>? contents, Models.ContainerBase containerBase, string gameLocale)
	{
		try
		{
			const string english = "en";
			var tables = _db.GetTables();
			var contentDesc = BuildContentDescription(contents, tables);
			var shortName = BuildShortName(contents, tables);
			var name = shortName;
			var description = $"A package from Kolya containing your barter rewards. The items inside will be delivered to you via message.\n\nContents:\n{contentDesc}";

			var locales = new Dictionary<string, LocaleDetails>
			{
				[gameLocale] = new LocaleDetails { Name = name, ShortName = shortName, Description = description },
				[english] = new LocaleDetails { Name = name, ShortName = shortName, Description = description }
			};

			var details = new NewItemFromCloneDetails
			{
				NewId = crateTemplateId,
				ItemTplToClone = containerBase.clone_item,
				ParentId = containerBase.item_parent,
				Locales = locales,
				HandbookParentId = containerBase.category_id,
				HandbookPriceRoubles = 1000,
				FleaPriceRoubles = null
			};

			var prefabPath = LookupPrefabPath(tables, contents);
			var props = new TemplateItemProperties
			{
				Prefab = new Prefab { Path = prefabPath },
				BackgroundColor = "yellow",
				Weight = 0.5f,
				ItemSound = containerBase.item_sound,
				ExaminedByDefault = true,
				Width = 1,
				Height = 1,
				CanSellOnRagfair = false
			};

			details.OverrideProperties = props;
			var result = _customItemService.CreateItemFromClone(details);

			// If item already existed, update its prefab (in case reward order changed)
			if (tables.Templates?.Items?.TryGetValue(crateTemplateId, out var existing) == true
				&& existing.Properties != null)
			{
				existing.Properties.Prefab = new Prefab { Path = prefabPath };
			}

			return result.Success == true;
		}
		catch
		{
			return false;
		}
	}

	/// <summary>
	/// Builds a concise tooltip-friendly summary of crate contents.
	/// Example: "3x Propital, PVS-14" or "8x M67, 8x RGD-5, 8x F-1"
	/// </summary>
	private string BuildShortName(List<BarterRewardItem>? contents, DatabaseTables tables)
	{
		if (contents == null || contents.Count == 0)
			return "Reward Pkg";

		var parts = new List<string>();
		foreach (var item in contents)
		{
			var count = Math.Max(1, item.Count);
			var itemName = item.DisplayName ?? LookupItemName(tables, item.TemplateId);
			parts.Add(count > 1 ? $"{count}x {itemName}" : itemName);
		}

		return string.Join(", ", parts);
	}

	/// <summary>
	/// Builds a human-readable list of crate contents using item names from the database.
	/// Example: "- 3x Propital\n- 1x PVS-14"
	/// </summary>
	private string BuildContentDescription(List<BarterRewardItem>? contents, DatabaseTables tables)
	{
		if (contents == null || contents.Count == 0)
			return "- Unknown items";

		var lines = new List<string>();

		foreach (var item in contents)
		{
			var count = Math.Max(1, item.Count);
			var itemName = item.DisplayName ?? LookupItemName(tables, item.TemplateId);
			lines.Add($"- {count}x {itemName}");
		}

		return string.Join("\n", lines);
	}

	/// <summary>
	/// Look up an item's short name from the database locale, falling back to template Name, then ID.
	/// </summary>
	private string LookupItemName(DatabaseTables tables, string templateId)
	{
		// Try English locale
		var serverLocales = _db.GetLocales();
		if (serverLocales?.Global?.TryGetValue("en", out var lazyLocale) == true)
		{
			var localeData = lazyLocale.Value;
			var shortNameKey = $"{templateId} ShortName";
			var nameKey = $"{templateId} Name";
			if (localeData.TryGetValue(shortNameKey, out var shortName) && !string.IsNullOrEmpty(shortName))
				return shortName;
			if (localeData.TryGetValue(nameKey, out var name) && !string.IsNullOrEmpty(name))
				return name;
		}

		// Fallback to item template name
		if (tables.Templates?.Items?.TryGetValue(templateId, out var tpl) == true)
			return tpl.Name ?? templateId[..8];

		return templateId[..8];
	}

	/// <summary>
	/// Copy the Prefab path from the first reward item so the crate shows that item's icon.
	/// Falls back to empty string (default container icon) if lookup fails.
	/// </summary>
	private static string LookupPrefabPath(DatabaseTables tables, List<BarterRewardItem>? contents)
	{
		if (contents == null || contents.Count == 0)
			return "";

		var firstTemplateId = contents[0].TemplateId;
		if (tables.Templates?.Items?.TryGetValue(firstTemplateId, out var itemTemplate) == true)
			return itemTemplate.Properties?.Prefab?.Path ?? "";

		return "";
	}
}
