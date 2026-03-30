using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Routers;
using SPTarkov.Server.Core.Services.Mod;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Quests;

[Injectable]
/// <summary>
/// Registers generated quests into the SPT database via CustomQuestService.
/// </summary>
public sealed class QuestRegistrationService
{
	private readonly CustomQuestService _customQuestService;
	private readonly QuestFactory _questFactory;
	private readonly ImageRouter _imageRouter;

	public QuestRegistrationService(CustomQuestService customQuestService, QuestFactory questFactory, ImageRouter imageRouter)
	{
		_customQuestService = customQuestService;
		_questFactory = questFactory;
		_imageRouter = imageRouter;
	}

	/// <summary>
	/// Build and register all TTC quests. Returns (created, failed).
	/// </summary>
	public (int created, int failed) RegisterAll(string emptyBoosterId)
	{
		RegisterQuestImages();
		int created = 0, failed = 0;

		// Introduction quest (no objectives, rewards Empty Booster)
		if (_customQuestService.CreateQuest(_questFactory.BuildIntroQuest(emptyBoosterId)).Success)
			created++; else failed++;

		// Info quest for returning players (no objectives, no reward)
		if (_customQuestService.CreateQuest(_questFactory.BuildInfoQuest()).Success)
			created++; else failed++;

		// Theme quests
		RegisterThemeQuests(BossesThemeDefinitions.GetAll(), ref created, ref failed);
		RegisterThemeQuests(IconicWeaponsThemeDefinitions.GetAll(), ref created, ref failed);
		RegisterThemeQuests(IconicLocationsThemeDefinitions.GetAll(), ref created, ref failed);
		RegisterThemeQuests(HideoutThemeDefinitions.GetAll(), ref created, ref failed);
		RegisterThemeQuests(FactionsThemeDefinitions.GetAll(), ref created, ref failed);
		RegisterThemeQuests(ManyWaysToDieThemeDefinitions.GetAll(), ref created, ref failed);

		return (created, failed);
	}

	private void RegisterThemeQuests(List<Models.QuestDefinition> definitions, ref int created, ref int failed)
	{
		foreach (var def in definitions)
		{
			if (_customQuestService.CreateQuest(_questFactory.BuildFromDefinition(def)).Success)
				created++; else failed++;
		}
	}

	/// <summary>
	/// Registers all .png images from files/quest/icon/ via ImageRouter.
	/// Each image is registered both with and without extension.
	/// </summary>
	private void RegisterQuestImages()
	{
		try
		{
			var (configDir, _, _) = PathResolver.GetConfigPaths();
			var modRoot = System.IO.Path.GetDirectoryName(configDir)!;
			var iconDir = System.IO.Path.Combine(modRoot, "files", "quest", "icon");
			if (!Directory.Exists(iconDir)) return;

			foreach (var file in Directory.EnumerateFiles(iconDir, "*.png"))
			{
				var fileName = System.IO.Path.GetFileName(file);
				var nameNoExt = System.IO.Path.GetFileNameWithoutExtension(file);
				_imageRouter.AddRoute($"/files/quest/icon/{nameNoExt}", file);
				_imageRouter.AddRoute($"/files/quest/icon/{fileName}", file);
			}
		}
		catch { }
	}
}
