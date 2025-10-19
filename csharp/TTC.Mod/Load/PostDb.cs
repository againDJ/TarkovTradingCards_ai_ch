// Main PostDB injector for TTC. Adjust namespaces to match SPT 4.0 server APIs.
using System;

namespace TTC.Mod.Load;

// using SPT.Core.DI; // Injectable attribute + TypePriority
// using SPT.Core.Interfaces; // IOnLoad
// using SPT.Core.Services; // DatabaseService, CustomItemService, ISptLogger

// [Injectable(TypePriority = OnLoadOrder.Database + 50)]
public sealed class PostDb /* : IOnLoad */
{
    // private readonly ISptLogger<PostDb> _logger;
    // private readonly DatabaseService _db;
    // private readonly CustomItemService _items;

    // public PostDb(ISptLogger<PostDb> logger, DatabaseService db, CustomItemService items)
    // {
    //     _logger = logger;
    //     _db = db;
    //     _items = items;
    // }

    // public void OnLoad()
    // {
    //     _logger.LogInformation("[TTC] PostDB starting - injecting initial items...");
    //     // TODO: parse JSON configs, clone 1 card + 1 container, add locales/handbook/trader entries
    // }
}
