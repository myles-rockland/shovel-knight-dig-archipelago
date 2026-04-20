using HarmonyLib;
using System;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(Collectible))]
    public class CollectiblePatch
    {
        public static Action<Collectible> onCollectibleCollected;

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
