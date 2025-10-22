# TTC.Mod

Server-side module for TarkovTradingCards (SPT). Provides item creation, trader/Ragfair wiring, and the static loot injection pipeline.

## Build
Set `SPT_DIR` to your SPT server root before building. Example :

```powershell
dotnet build ".\TTC.Mod.csproj" -c Release
```

Output: `bin/Release/net9.0/TTC.Mod.dll`

## Packaging
- Place built DLL and mod assets into your SPT `user/mods/<your-mod>/` folder per SPT packaging conventions.
- Include the `bundles/` and `config/` content from this repository.

## Key entry points
- `Load/PostDb.cs`: Orchestrator called after DB load; creates cards/binders, configures Ragfair/Fence, adds trader offers, injects loot.
- DI: classes annotated with `[Injectable]` are discovered and injected by SPT.

## Config flow
- `Services/Common/State`: runtime state (loaded config and resolved data)
- `config/*.json[c]`: controls creation, trader/ragfair toggles, and loot injection behavior

## Logging
- Minimal by default; set `debug` or `verbose_logs` in `config/mod_config.jsonc` for additional traces.