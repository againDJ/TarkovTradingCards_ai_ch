// Minimal PreSpt load class for TTC. Adjust namespaces and base interfaces to match SPT 4.0 server APIs.
using System;

namespace TTC.Mod.Load;

// using SPT.Core.DI; // Injectable attribute + OnLoadOrder
// using SPT.Core.Interfaces; // IOnLoad
// using SPT.Core.Services; // ISptLogger

// [Injectable(TypePriority = OnLoadOrder.PreSptModLoader + 10)]
public sealed class PreSpt /* : IOnLoad */
{
    // private readonly ISptLogger<PreSpt> _logger;

    // public PreSpt(ISptLogger<PreSpt> logger)
    // {
    //     _logger = logger;
    // }

    // public void OnLoad()
    // {
    //     _logger.LogInformation("[TTC] PreSpt starting - validating TTC configs...");
    //     // TODO: read mod_config.jsonc and validate rarity weights early
    // }
}
