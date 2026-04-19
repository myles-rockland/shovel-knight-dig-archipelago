using HarmonyLib;
using System;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(Inventory))]
    public class InventoryPatch
    {
        [HarmonyPatch(nameof(Inventory.Init))]
        [HarmonyPrefix]
        public static void ClearInitialBuffs(Inventory __instance)
        {
            Plugin.BepinLogger.LogMessage("Resizing m_InitialUnlockedBuffs to 0!");
            Array.Resize(ref __instance.m_InitialUnlockedBuffs, 0);

            var item = __instance.GetItemByID("COG_STRING");

            if (item != null)
            {
                Plugin.BepinLogger.LogMessage($"Value of COG_STRING unlock: {SaveManager.GetBitValue("UNLOCKED ITEMS", __instance.GetItemIndex(item))}");
            }
            else
            {
                Plugin.BepinLogger.LogMessage("Couldn't find COG_STRING");
            }

            Plugin.BepinLogger.LogMessage($"DataCollect.IsActive: {DataCollect.IsActive}");
        }
    }
}
