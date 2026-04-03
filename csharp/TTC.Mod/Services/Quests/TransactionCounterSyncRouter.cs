using System.Text.Json;
using System.Text.Json.Serialization;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Utils;

namespace TTC.Mod.Services.Quests;

/// <summary>Request data for /ttc/syncCounters endpoint.</summary>
public record SyncCountersRequest : IRequestData
{
    [JsonPropertyName("counters")]
    public Dictionary<string, int> Counters { get; init; } = new();
}

[Injectable]
/// <summary>
/// Custom HTTP endpoint: POST /ttc/syncCounters
/// Receives transaction counter updates from the TTC client plugin and writes them
/// to the profile's TaskConditionCounters for persistence between sessions.
/// </summary>
public sealed class TransactionCounterSyncRouter(
    JsonUtil jsonUtil,
    ProfileHelper profileHelper,
    HttpResponseUtil httpResponseUtil,
    ISptLogger<TransactionCounterSyncRouter> logger
) : StaticRouter(jsonUtil, [
    new RouteAction<SyncCountersRequest>(
        "/ttc/syncCounters",
        (url, requestData, sessionId, output) =>
            HandleSync(sessionId, requestData, profileHelper, httpResponseUtil, logger)
    )
])
{
    private static ValueTask<string> HandleSync(
        MongoId sessionId, SyncCountersRequest? request,
        ProfileHelper profileHelper,
        HttpResponseUtil httpResponseUtil,
        ISptLogger<TransactionCounterSyncRouter> logger)
    {
        try
        {
            var counters = request?.Counters;
            if (counters == null || counters.Count == 0)
                return ValueTask.FromResult(httpResponseUtil.NullResponse());

            var pmcData = profileHelper.GetPmcProfile(sessionId);
            if (pmcData?.TaskConditionCounters == null)
            {
                logger.Warning("[TTC][SyncCounters] Profile not found");
                return ValueTask.FromResult(httpResponseUtil.NullResponse());
            }

            int synced = 0;
            foreach (var (condId, value) in counters)
            {
                var mongoId = new MongoId(condId);

                // Find or create the counter entry
                if (pmcData.TaskConditionCounters.TryGetValue(mongoId, out var existing))
                {
                    if (existing.Value != value)
                    {
                        existing.Value = value;
                        synced++;
                    }
                }
                else
                {
                    // Create new counter entry
                    pmcData.TaskConditionCounters[mongoId] = new TaskConditionCounter
                    {
                        Id = mongoId,
                        Type = "CounterCreator",
                        Value = value,
                        SourceId = ""
                    };
                    synced++;
                }
            }

            if (synced > 0)
                logger.Debug($"[TTC][SyncCounters] Synced {synced} counters for {sessionId}");

            return ValueTask.FromResult(httpResponseUtil.NullResponse());
        }
        catch (Exception ex)
        {
            logger.Error($"[TTC][SyncCounters] Error: {ex.Message}");
            return ValueTask.FromResult(httpResponseUtil.NullResponse());
        }
    }
}
