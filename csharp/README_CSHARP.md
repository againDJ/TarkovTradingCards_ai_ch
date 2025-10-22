# TTC C# port (SPT 4.0)

This folder will contain the C# version of Tarkov Trading Cards for SPT 4.0.

Key SPT 4.0 changes to adopt:
- No package.json, no order.json.
- Implement a metadata class inheriting `AbstractModMetadata`.
- Use `[Injectable(TypePriority = ...)]` on classes implementing `IOnLoad` to control execution order.

## Structure

- TTC.Mod/TTC.Mod.csproj — .NET project (net9.0)
- TTC.Mod/Mod/TTCModMetadata.cs — metadata class (fill fields, inherit `AbstractModMetadata` once reference is added)
- TTC.Mod/Load/PreSpt.cs — early stage (config validation)
- TTC.Mod/Load/PostDb.cs — main injection (items/locales/handbook/traders/loot)

## Build (Windows / PowerShell)

Requirements:
- .NET 9 SDK
- Reference the SPT 4.0 server assemblies in the .csproj (HintPath to your server install)

Steps:
1. Open a Developer PowerShell at repo root
2. Edit `csharp/TTC.Mod/TTC.Mod.csproj` to add `<Reference>` entries to your SPT server DLLs
3. Build:

```
# build project
dotnet build csharp/TTC.Mod/TTC.Mod.csproj -c Release

# copy output to your SPT server mods folder (adjust path)
$dest = "C:\\SPT-4.0\\user\\mods\\TarkovTradingCards"
New-Item -ItemType Directory -Force -Path $dest | Out-Null
Copy-Item -Recurse -Force csharp/TTC.Mod/bin/Release/net9.0/* $dest
Copy-Item bundles.json $dest
Copy-Item -Recurse bundles $dest/bundles
Copy-Item -Recurse config $dest/config
```

After copying, start the SPT server and watch for TTC log lines.

## Next steps
- Wire up actual SPT namespaces and types (AbstractModMetadata, IOnLoad, Injectable, DatabaseService, CustomItemService, ISptLogger).
- Port the TS logic to parse configs and inject cards/containers.
- Implement ragfair/fence toggles, loot probabilities, and binders.
