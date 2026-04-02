using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Routers;
using SPTarkov.Server.Core.Services.Image;
using TTC.Mod.Models;

namespace TTC.Mod.Services.Traders;

[Injectable]
/// <summary>
/// Registers the custom trader "Kolya" (Nikolai Vetrov) in SPT's database.
/// </summary>
public sealed class KolyaRegistrationService
{
    private readonly ISptLogger<KolyaRegistrationService> _logger;
    private readonly DatabaseService _db;
    private readonly ImageRouter _imageRouter;
    private readonly ImageRouterService _imageRouterService;

    // Prapor's trader ID — used as template to clone from
    private static readonly string PraporId = "54cb50c76803fa8b248b4571";

    public KolyaRegistrationService(ISptLogger<KolyaRegistrationService> logger, DatabaseService db, ImageRouter imageRouter, ImageRouterService imageRouterService)
    {
        _logger = logger;
        _db = db;
        _imageRouter = imageRouter;
        _imageRouterService = imageRouterService;
    }

    /// <summary>
    /// Register Kolya in the trader database by cloning Prapor's base and customizing it.
    /// </summary>
    public bool Register(string traderBaseJsonPath)
    {
        try
        {
            var tables = _db.GetTables();
            var traderId = new MongoId(QuestIds.KolyaTraderId);

            // Clone Prapor's base as a starting point (avoids JSON deserialization issues with TraderBase record)
            if (!tables.Traders.TryGetValue(PraporId, out var prapor) || prapor?.Base == null)
            {
                _logger.Error("[TTC][Kolya] Cannot find Prapor to clone trader base");
                return false;
            }

            var traderBase = prapor.Base with
            {
                Id = traderId,
                Avatar = $"/files/trader/avatar/{QuestIds.KolyaTraderId}.jpg",
                Nickname = "Kolya",
                Name = "Nikolai Vetrov",
                Surname = "Vetrov",
                Location = "Tarkov outskirts",
                Currency = CurrencyType.RUB,
                UnlockedByDefault = true,
                Medic = false,
                CustomizationSeller = false,
                BuyerUp = false,
                Discount = 0,
                DiscountEnd = 0,
                BalanceRub = 5000000,
                BalanceDollar = 0,
                BalanceEuro = 0,
                GridHeight = 100,
                Insurance = new TraderInsurance
                {
                    Availability = false,
                    ExcludedCategory = new List<MongoId>(),
                    MaxReturnHour = 0,
                    MaxStorageTime = 0,
                    MinPayment = 0,
                    MinReturnHour = 0
                },
                Repair = new TraderRepair
                {
                    Availability = false,
                    Currency = "5449016a4bdc2d6f028b456f",
                    CurrencyCoefficient = 1,
                    ExcludedCategory = new List<MongoId>(),
                    ExcludedIdList = new List<string>(),
                    PriceRate = 0,
                    Quality = 0
                },
                ItemsBuy = new ItemBuyData
                {
                    Category = new HashSet<MongoId> { new MongoId("5b47574386f77428ca22b2f1") },
                    IdList = new HashSet<MongoId>()
                },
                ItemsBuyProhibited = new ItemBuyData
                {
                    Category = new HashSet<MongoId>(),
                    IdList = new HashSet<MongoId>()
                },
                SellCategory = new List<string>(),
                LoyaltyLevels = new List<TraderLoyaltyLevel>
                {
                    new() { BuyPriceCoefficient = 60, MinLevel = 1, MinSalesSum = 0, MinStanding = 0 },
                    new() { BuyPriceCoefficient = 55, MinLevel = 1, MinSalesSum = 0, MinStanding = 0.20 },
                    new() { BuyPriceCoefficient = 50, MinLevel = 1, MinSalesSum = 0, MinStanding = 0.40 },
                    new() { BuyPriceCoefficient = 45, MinLevel = 1, MinSalesSum = 0, MinStanding = 0.60 }
                }
            };

            // Create trader with empty assort
            var trader = new Trader
            {
                Base = traderBase,
                Assort = new TraderAssort
                {
                    Items = new List<Item>(),
                    BarterScheme = new Dictionary<MongoId, List<List<BarterScheme>>>(),
                    LoyalLevelItems = new Dictionary<MongoId, int>()
                },
                QuestAssort = new Dictionary<string, Dictionary<MongoId, MongoId>>
                {
                    ["started"] = new(),
                    ["success"] = new(),
                    ["fail"] = new()
                },
                Dialogue = new Dictionary<string, List<string>>()
            };

            // Register in database
            tables.Traders[traderId] = trader;

            // Register avatar image route so SPT serves the trader portrait
            RegisterAvatarImage();

            // Register locale entries
            RegisterLocales(QuestIds.KolyaTraderId);

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error($"[TTC][Kolya] Registration failed: {ex.Message}");
            _logger.Error($"[TTC][Kolya] Stack: {ex.StackTrace}");
            return false;
        }
    }

    private void RegisterAvatarImage()
    {
        var avatarFileName = $"{QuestIds.KolyaTraderId}.jpg";
        try
        {
            var (configDir, _, _) = Common.PathResolver.GetConfigPaths();
            var modRoot = System.IO.Path.GetDirectoryName(configDir)!;
            var srcPath = System.IO.Path.Combine(modRoot, "files", "trader", "avatar", avatarFileName);

            if (!File.Exists(srcPath))
            {
                _logger.Warning($"[TTC][Kolya] Avatar image not found at: {srcPath}");
                return;
            }

            // Register via ImageRouter (like WTT-CommonLib)
            _imageRouter.AddRoute($"/files/trader/avatar/{QuestIds.KolyaTraderId}", srcPath);
            _imageRouter.AddRoute($"/files/trader/avatar/{avatarFileName}", srcPath);
        }
        catch (Exception ex)
        {
            _logger.Warning($"[TTC][Kolya] Could not register avatar image: {ex.Message}");
        }
    }

    private void RegisterLocales(string traderId)
    {
        var locales = new Dictionary<string, string>
        {
            [$"{traderId} Nickname"] = "Kolya",
            [$"{traderId} FirstName"] = "Nikolai",
            [$"{traderId} FullName"] = "Nikolai Vetrov",
            [$"{traderId} Location"] = "Tarkov outskirts",
            [$"{traderId} Description"] =
                "Before the conflict, Nikolai Vetrov worked as a senior archivist in TerraGroup's Tarkov branch, " +
                "cataloguing classified reports and research documentation. When the city fell into chaos, he found " +
                "himself trapped in the exclusion zone with crates of documents nobody would ever come to collect. " +
                "Rather than risk the dangerous routes out, he settled into an abandoned utility bunker near the old flea market grounds.\n\n" +
                "With nothing but time and salvaged printing supplies, Kolya began illustrating what he witnessed: " +
                "the brutal firefights, the legendary operators, the cursed artifacts, the stories whispered between " +
                "scavengers at campfires. He prints his cards on whatever paper he can find and trades them for food, " +
                "medicine, and ammunition.\n\n" +
                "To most PMCs, he's an eccentric hermit with an odd hobby. To collectors, he's the only man in Tarkov " +
                "who understands that memories are worth more than gear — because gear rusts, but stories survive."
        };

        try
        {
            var serverLocales = _db.GetLocales();
            if (serverLocales?.Global != null)
            {
                foreach (var (_, lazyLocale) in serverLocales.Global)
                {
                    lazyLocale.AddTransformer(localeData =>
                    {
                        foreach (var (key, value) in locales)
                            localeData[key] = value;
                        return localeData;
                    });
                }
            }
        }
        catch { }
    }
}
