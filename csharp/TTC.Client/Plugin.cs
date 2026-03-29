using System;
using System.Reflection;
using BepInEx;
using EFT;
using HarmonyLib;

namespace TTC
{
    [BepInPlugin("com.ttc.client", "TTC", "3.0.0")]
    [BepInDependency("com.cshazey.questsextended", BepInDependency.DependencyFlags.SoftDependency)]
    public class Plugin : BaseUnityPlugin
    {
        internal static MethodInfo CollectScavOrCultistMethod;

        private void Awake()
        {
            try
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (asm.GetName().Name != "QuestsExtended") continue;

                    var hideoutCtrlType = asm.GetType("QuestsExtended.Quests.HideoutQuestController");
                    CollectScavOrCultistMethod = hideoutCtrlType?.GetMethod(
                        "CollectScavOrCultist", BindingFlags.Public | BindingFlags.Static);
                    break;
                }

                var harmony = new Harmony("com.ttc.client");
                var targetMethod = AccessTools.Method(typeof(Class308), "StartCultistsProduction");
                if (targetMethod != null)
                    harmony.Patch(targetMethod, postfix: new HarmonyMethod(typeof(CultistSacrificePatch), "Postfix"));
            }
            catch (Exception) { }
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
