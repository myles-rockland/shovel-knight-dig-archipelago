using HarmonyLib;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(Owl))]
    public class OwlPatch
    {
        [HarmonyPatch(nameof(Owl.InitInOverworld))]
        [HarmonyPostfix]
        public static void DeactivateOwlIfNotUnlocked(Owl __instance)
        {
            if (SaveManager.GetInt("ap received owl") == 0)
            {
                __instance.gameObject.SetActive(false);
            }
        }
    }
}
