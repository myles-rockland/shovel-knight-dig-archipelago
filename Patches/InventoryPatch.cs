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
        }
    }
}
