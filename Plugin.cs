using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using Unity.Netcode;

namespace CompanyExecutive
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> Enabled;
        public static ConfigEntry<int> MoneyToGive;
        public static ConfigEntry<bool> ConsistentGive;
        public static ConfigEntry<bool> OverrideMoney;
        
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        private void Awake()
        {
            // man fuck this shit this shit is a MONOBEHAVIOUR?? WHAT THE FUCK?
            Enabled = Config.Bind("General", "Enabled", true, "If the mod is enabled or not");
            MoneyToGive = Config.Bind("General", "MoneyToGive", 1000000, "The amount of money to give.");
            ConsistentGive = Config.Bind("General", "ConsistentGive", true, "Whether to give more money on each day or not.");
            OverrideMoney = Config.Bind("General", "OverrideMoney", true, "Whether to override the starting money or just add to it.");
            
            harmony.PatchAll(typeof(TerminalPatch));
            
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
    
    [HarmonyPatch(typeof(Terminal))]
    internal class TerminalPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void Thingy(Terminal __instance, ref int ___groupCredits)
        {
            if (!Plugin.Enabled.Value) return;
            if (!Plugin.ConsistentGive.Value)
            {
                if (TimeOfDay.Instance.daysUntilDeadline != 3 || TimeOfDay.Instance.profitQuota != 130) return;
                switch (Plugin.OverrideMoney.Value)
                {
                    case true:
                        ___groupCredits = Plugin.MoneyToGive.Value;
                        break;
                    default:
                        ___groupCredits += Plugin.MoneyToGive.Value;
                        break;
                }
            }
            else
            {
                switch (Plugin.OverrideMoney.Value)
                {
                    case true:
                        ___groupCredits = Plugin.MoneyToGive.Value;
                        break;
                    default:
                        ___groupCredits += Plugin.MoneyToGive.Value;
                        break;
                }
            }
        }
    }
}
