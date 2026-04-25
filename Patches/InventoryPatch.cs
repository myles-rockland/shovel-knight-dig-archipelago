using HarmonyLib;
using ShovelKnightDigAPClient.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        [HarmonyPatch(nameof(Inventory.Init))]
        [HarmonyPostfix]
        public static void SetupCustomItems()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Plugin.BepinLogger.LogInfo($"assemblyName: {assemblyName}");
            string resourceName = $"{assemblyName}.assetbundles.ap";

            if (Plugin.ApAssetBundle == null)
                Plugin.ApAssetBundle = BundleLoader.LoadEmbeddedBundle(resourceName);

            if (Plugin.ApAssetBundle == null)
            {
                Plugin.BepinLogger.LogError("Failed to load bundle from memory");
                return;
            }

            Plugin.BepinLogger.LogInfo($"Loaded a bundle from memory!");

            var upgradeItemPaths = new List<string>()
            {
                "Assets/Upgrade Items/AP Items/Hoofmans_Shop_1.asset",
                "Assets/Upgrade Items/AP Items/Chester_Surface_Shop_1.asset",
            };

            Plugin.BepinLogger.LogInfo($"About to resize an array!");

            Array.Resize(ref Inventory.Player1Inventory.m_PermanentUpgradeItems,
                Inventory.Player1Inventory.m_PermanentUpgradeItems.Length + upgradeItemPaths.Count);

            Plugin.BepinLogger.LogInfo($"Resized the array!");

            for (int i = upgradeItemPaths.Count - 1; i >= 0; i--)
            {
                var upgradeItemPath = upgradeItemPaths[i];
                var upgradeItem = Plugin.ApAssetBundle.LoadAsset<UpgradeItem>(upgradeItemPath);
                if (upgradeItem != null)
                {
                    Plugin.BepinLogger.LogInfo($"Loaded: {upgradeItem.m_ItemName}");
                }
                else
                {
                    Plugin.BepinLogger.LogInfo($"Failed to load UpgradeItem at {upgradeItemPath}");
                }
                Inventory.Player1Inventory.m_PermanentUpgradeItems[^(i + 1)] = upgradeItem;
            }
        }
    }
}
