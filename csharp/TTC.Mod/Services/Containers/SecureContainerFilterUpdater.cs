using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Services;

namespace TTC.Mod.Services.Containers;

[Injectable]
public sealed class SecureContainerFilterUpdater
{
    private readonly DatabaseService _db;

    public SecureContainerFilterUpdater(DatabaseService db)
    {
        _db = db;
    }

    // Add Empty Booster tpl to secure container filter lists
    public void AddToSecureContainers(string itemTpl)
    {
        if (string.IsNullOrWhiteSpace(itemTpl)) return;
        try
        {
            var tables = _db.GetTables();
            var templates = tables.Templates;
            if (templates == null || templates.Items == null) return;
            var items = templates.Items as IDictionary<MongoId, TemplateItem>;
            if (items == null) return;

            var secureContainerIds = new[]
            {
                "544a11ac4bdc2d470e8b456a", // Alpha
                "5857a8b324597729ab0a0e7d", // Beta
                "59db794186f77448bc595262", // Epsilon
                "5857a8bc2459772bad15db29", // Gamma
                "665ee77ccf2d642e98220bca", // Gamma (bis)
                "5c093ca986f7740a1867ab12", // Kappa
                "676008db84e242067d0dc4c9", // Kappa (Desecrated)
                "664a55d84a90fc2c8a6305c9", // Theta
                "5732ee6a24597719ae0c0281"  // Waist pouch
            };

            var tpl = new MongoId(itemTpl);
            foreach (var id in secureContainerIds)
            {
                var key = new MongoId(id);
                if (!items.TryGetValue(key, out var template) || template?.Properties?.Grids == null) continue;
                foreach (var grid in template.Properties.Grids)
                {
                    var gprops = grid?.Properties; if (gprops?.Filters == null) continue;
                    foreach (var filter in gprops.Filters)
                    {
                        filter?.Filter?.Add(tpl);
                    }
                }
            }
        }
        catch { }
    }
}
