using HarmonyLib;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(ChesterChest))]
    public class ChesterChestPatch
    {
        private static bool undoCogInsertionRunning = false;

        [HarmonyPatch(nameof(ChesterChest.CreateItemList))]
        [HarmonyPostfix]
        public static void UndoCogInsertion(ChesterChest __instance, ref bool ___m_WillSayCogOnStringIntro)
        {
            if (!undoCogInsertionRunning)
            {
                undoCogInsertionRunning = true;

                if (__instance.gameObject.GetComponent<InGameShop>().m_ItemCatalogue[0].m_ID == "COG_STRING")
                {
                    if (SaveManager.GetInt("ap received cog string") == 0)
                    {
                        __instance.CreateItemList();
                        EnchantressQuest.Instance.ChesterHasSoldCogOnString = false;
                        ___m_WillSayCogOnStringIntro = false;
                        SetDefaultIntroLines(__instance);
                    }
                }

                undoCogInsertionRunning = false;
            }
        }

        private static void SetDefaultIntroLines(ChesterChest __instance)
        {
            __instance.gameObject.GetComponent<InGameShop>().m_OpeningLineAlt = new string[3];
            __instance.gameObject.GetComponent<InGameShop>().m_OpeningLineAlt[0] = "CHESTER_CHEST_INTRO_ALT_1";
            __instance.gameObject.GetComponent<InGameShop>().m_OpeningLineAlt[1] = "CHESTER_CHEST_INTRO_ALT_2";
            __instance.gameObject.GetComponent<InGameShop>().m_OpeningLineAlt[2] = "CHESTER_CHEST_INTRO_ALT_3";
        }
    }
}
