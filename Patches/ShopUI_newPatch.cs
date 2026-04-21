using HarmonyLib;
using ShovelKnightDigAPClient.Archipelago;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(ShopUI_new))]
    public class ShopUI_newPatch
    {
        [HarmonyPatch(nameof(ShopUI_new.BuyItem))]
        public static void HandleAPItems(ShopUI_new __instance, UIShopItem shopItem)
        {
            switch (shopItem.m_UpgradeItem.m_ID)
            {
                case "Hoofman's Shop 1":
                    Plugin.ArchipelagoClient.CheckLocation(1); // TODO: Refactor to remove repetition and magic numbers
                    break;
                case "Chester Surface Shop 1":
                    Plugin.ArchipelagoClient.CheckLocation(2);
                    break;
                default:
                    Plugin.BepinLogger.LogMessage("Handling some non-AP item");
                    break;
            }
        }
    }
}

public class ShopUI_new
{
    public bool BuyItem(UIShopItem shopItem)
    {
        throw new NotImplementedException();
    }
}