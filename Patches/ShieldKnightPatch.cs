using HarmonyLib;
using System;
using UnityEngine;

namespace ShovelKnightDigAPClient.Patches
{
    [HarmonyPatch(typeof(ShieldKnight))]
    public class ShieldKnightPatch
    {
        [HarmonyPatch(nameof(ShieldKnight.OnCreateDynamically))]
        [HarmonyPostfix]
        public static void DisableKeyIfNotUnlocked(ShieldKnight __instance)
        {
            if (SaveManager.GetInt("ap received skeleton key") == 0)
            {
                __instance.skeletonKey.SetActive(false);
            }
        }
    }
}

// My first stub!
public class ShieldKnight
{
    public GameObject skeletonKey;

    public void OnCreateDynamically(Level level, AppearInOverworldCondition appearCondition)
    {
        throw new NotImplementedException();
    }
}
