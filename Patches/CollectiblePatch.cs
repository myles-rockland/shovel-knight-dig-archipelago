using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using ShovelKnightDigAPClient.Archipelago;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(Collectible))]
    public class CollectiblePatch
    {
        [HarmonyPatch(nameof(Collectible.Collect))]
        [HarmonyPostfix]
        public static void CheckCog(Collectible __instance)
        {
            if (__instance.m_Type == Collectible.TYPE.COG)
            {
                Plugin.BepinLogger.LogMessage($"Cog {__instance.GetComponent<GearCollectible>().ProgressionIndex} collected in {StageController.Theme.ToString()}!");
                //Plugin.ArchipelagoClient.SendMessage("Gear Collected");
            }
        }
    }
}
