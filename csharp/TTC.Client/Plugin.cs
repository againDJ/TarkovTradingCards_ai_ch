using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using EFT;
using EFT.Quests;
using HarmonyLib;
using SPT.Common.Http;

namespace TTC
{
    [BepInPlugin("com.ttc.client", "TTC", "3.0.5")]
    [BepInDependency("com.cshazey.questsextended", BepInDependency.DependencyFlags.SoftDependency)]
    public class Plugin : BaseUnityPlugin
    {
        internal static MethodInfo CollectScavOrCultistMethod;
        internal static ManualLogSource Log;
        internal static HashSet<string> TransactionConditionIds;
        internal static Assembly QeAssembly;

        private void Awake()
        {
            Log = Logger;
            try
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (asm.GetName().Name != "QuestsExtended") continue;
                    QeAssembly = asm;

                    var hideoutCtrlType = asm.GetType("QuestsExtended.Quests.HideoutQuestController");
                    CollectScavOrCultistMethod = hideoutCtrlType?.GetMethod(
                        "CollectScavOrCultist", BindingFlags.Public | BindingFlags.Static);
                    break;
                }

                var harmony = new Harmony("com.ttc.client");
                var targetMethod = AccessTools.Method(typeof(Class308), "StartCultistsProduction");
                if (targetMethod != null)
                    harmony.Patch(targetMethod, postfix: new HarmonyMethod(typeof(CultistSacrificePatch), "Postfix"));

                // Load transaction condition IDs
                TransactionConditionIds = LoadTransactionConditionIds();
                Logger.LogInfo($"[TTC] Loaded {TransactionConditionIds.Count} transaction condition IDs");

                if (TransactionConditionIds.Count > 0 && QeAssembly != null)
                {
                    var tradingCtrlType = QeAssembly.GetType("QuestsExtended.Quests.TradingQuestController");
                    if (tradingCtrlType != null)
                    {
                        // Patch SaleMade (synchronous — handles EarnMoneyOnTransaction)
                        var saleMade = tradingCtrlType.GetMethod("SaleMade", BindingFlags.Static | BindingFlags.Public);
                        if (saleMade != null)
                        {
                            harmony.Patch(saleMade, postfix: new HarmonyMethod(typeof(TransactionPersistPatch), "Postfix"));
                            Logger.LogInfo("[TTC] Patched SaleMade for transaction persistence");
                        }

                        // Patch PurchaseMade (launches coroutine — handles SpendMoneyOnTransaction)
                        var purchaseMade = tradingCtrlType.GetMethod("PurchaseMade", BindingFlags.Static | BindingFlags.Public);
                        if (purchaseMade != null)
                        {
                            harmony.Patch(purchaseMade, postfix: new HarmonyMethod(typeof(TransactionPersistPatch), "Postfix"));
                            Logger.LogInfo("[TTC] Patched PurchaseMade for transaction persistence");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"[TTC] Awake error: {ex.Message}");
            }
        }

        private static HashSet<string> LoadTransactionConditionIds()
        {
            var result = new HashSet<string>();
            try
            {
                var qeDir = Path.Combine(BepInEx.Paths.PluginPath, "QuestsExtended", "Quests");
                var file = Path.Combine(qeDir, "TTC_quests.json");
                if (!File.Exists(file)) return result;

                var lines = File.ReadAllLines(file);
                string lastCondId = null;
                foreach (var line in lines)
                {
                    var trimmed = line.Trim();
                    if (trimmed.Contains("\"ConditionId\""))
                    {
                        var start = trimmed.IndexOf(":") + 1;
                        lastCondId = trimmed.Substring(start).Trim().Trim(',').Trim('"');
                    }
                    else if (trimmed.Contains("\"ConditionType\"") && lastCondId != null)
                    {
                        var start = trimmed.IndexOf(":") + 1;
                        var condType = trimmed.Substring(start).Trim().Trim(',').Trim('"');
                        if (condType is "EarnMoneyOnTransaction" or "SpendMoneyOnTransaction" or "CompleteAnyTransaction")
                            result.Add(lastCondId);
                        lastCondId = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log?.LogWarning($"[TTC] Failed to load transaction conditions: {ex.Message}");
            }
            return result;
        }
    }

    /// <summary>
    /// After each trade, read QE's ProgressChecker values for transaction conditions
    /// and send them to the TTC server mod to update TaskConditionCounters in the profile.
    /// </summary>
    public static class TransactionPersistPatch
    {
        public static void Postfix()
        {
            try
            {
                if (Plugin.TransactionConditionIds == null || Plugin.QeAssembly == null) return;

                var qecType = Plugin.QeAssembly.GetType("QuestsExtended.Quests.QuestExtendedController");
                if (qecType == null) return;

                var controller = UnityEngine.Object.FindObjectOfType(qecType);
                if (controller == null) return;

                var abstractCtrlField = qecType.GetField("_questAbstractController",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (abstractCtrlField == null) return;

                var abstractCtrl = abstractCtrlField.GetValue(controller) as AbstractQuestControllerClass;
                if (abstractCtrl == null) return;

                // Collect current values for transaction conditions
                var updates = new Dictionary<string, int>();
                foreach (var quest in abstractCtrl.Quests)
                {
                    if (quest == null) continue;
                    foreach (var kvp in quest.ProgressCheckers)
                    {
                        var condId = kvp.Key.id.ToString();
                        if (!Plugin.TransactionConditionIds.Contains(condId)) continue;

                        var currentValue = (int)kvp.Value.CurrentValue;
                        if (currentValue > 0)
                            updates[condId] = currentValue;
                    }
                }

                if (updates.Count == 0) return;

                // Send to server — format: {"counters": {"condId": value, ...}}
                var inner = string.Join(",", updates.Select(u => $"\"{u.Key}\":{u.Value}"));
                var json = "{\"counters\":{" + inner + "}}";
                RequestHandler.PostJson("/ttc/syncCounters", json);
                Plugin.Log?.LogDebug($"[TTC] Sent {updates.Count} transaction counters to server");
            }
            catch (Exception ex)
            {
                Plugin.Log?.LogWarning($"[TTC] TransactionPersist error: {ex.Message}");
            }
        }
    }

    public static class CultistSacrificePatch
    {
        public static void Postfix()
        {
            try
            {
                Plugin.CollectScavOrCultistMethod?.Invoke(null, new object[] { (EAreaType)27 });
            }
            catch (Exception) { }
        }
    }
}
