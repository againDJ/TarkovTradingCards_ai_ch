using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Containers;

[Injectable]
public sealed class PouchCompatibilityUpdater
{
    private readonly DatabaseService _db;
    private readonly State _state;

    public PouchCompatibilityUpdater(DatabaseService db, State state)
    {
        _db = db;
        _state = state;
    }

    // Make TTC cards compatible with S I C C and Documents case containers
    public void Update()
    {
        try
        {
            var tables = _db.GetTables();
            var templates = tables.Templates;
            if (templates == null || templates.Items == null) { return; }

            var items = templates.Items as IDictionary<MongoId, TemplateItem>;
            if (items == null) { return; }

            var ttcIds = new HashSet<MongoId>(_state.Cards.Select(c => new MongoId(c.id)));
            int containersMatched = 0, filtersTouched = 0, totalAdded = 0;

            var targetCases = new[] { "5d235bb686f77443f4331278", "590c60fc86f77412b13fddcf" };

            foreach (var tpl in targetCases)
            {
                var key = new MongoId(tpl);
                if (!items.TryGetValue(key, out var template) || template?.Properties?.Grids == null) { continue; }

                int localFiltersTouched = 0, localAdded = 0;
                foreach (var grid in template.Properties.Grids)
                {
                    var gprops = grid?.Properties; if (gprops?.Filters == null) continue;
                    foreach (var filter in gprops.Filters)
                    {
                        var set = filter?.Filter; if (set == null) continue;
                        int before = set.Count;
                        set.UnionWith(ttcIds);
                        int delta = set.Count - before;
                        if (delta > 0) { localFiltersTouched++; localAdded += delta; }
                    }
                }

                if (localAdded > 0)
                {
                    containersMatched++;
                    filtersTouched += localFiltersTouched;
                    totalAdded += localAdded;
                }
            }
        }
        catch (Exception ex)
        {
            _ = ex;
        }
    }
}
