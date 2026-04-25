using HarmonyLib;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(InGameShop))]
    public class InGameShopPatch
    {
        [HarmonyPatch(nameof(InGameShop.StartInteraction))]
        [HarmonyPrefix]
        public static void SetItemCatalogue(InGameShop __instance)
        {
            if (!__instance.m_ShopHasBeenOpen)
            {
                switch (__instance.m_Type)
                {
                    case InGameShop.SHOP_TYPE.CHESTER_OVERWORLD:
                        Plugin.BepinLogger.LogMessage("Initialising Chester Overworld shop!");
                        __instance.m_ItemCatalogue.Clear();
                        __instance.m_ItemCatalogue.Add(Inventory.Player1Inventory.m_PermanentUpgradeItems[^2]);
                        break;
                    case InGameShop.SHOP_TYPE.HORSEMANN:
                        Plugin.BepinLogger.LogMessage("Initialising Hoofman's overworld shop!");
                        __instance.m_ItemCatalogue.Clear();
                        __instance.m_ItemCatalogue.Add(Inventory.Player1Inventory.m_PermanentUpgradeItems[^1]);
                        break;
                }
            }
        }
    }
}
