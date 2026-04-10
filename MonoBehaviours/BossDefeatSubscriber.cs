using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ShovelKnightDigAPClient.MonoBehaviours
{
    public class BossDefeatSubscriber : MonoBehaviour
    {
        private void OnEnable()
        {
            Enemy.OnBossDefeatedEvent += OnBossDefeated;
        }

        private void OnDisable()
        {
            Enemy.OnBossDefeatedEvent += OnBossDefeated;
        }

        private void OnBossDefeated(StageController.THEME_ID theme)
        {
            Plugin.BepinLogger.LogMessage($"Defeated boss in {theme.ToString()}!");
            //Plugin.ArchipelagoClient.SendMessage("");
        }
    }
}
