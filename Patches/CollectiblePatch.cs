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

                foreach (var item in Inventory.Player1Inventory.m_PermanentUpgradeItems)
                {
                    if (item.m_ID == "FIRE_RING" && !Inventory.Player1Inventory.DoesPlayerHavePermItem(item))
                    {
                        Plugin.BepinLogger.LogMessage($"Unlocking fire ring!");
                        Inventory.Player1Inventory.AddPermItem(item);
                        break;
                    }
                }
            }
        }
    }
}
