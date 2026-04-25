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
            long id = theme switch
            {
                StageController.THEME_ID.MUSHROOM => 4,
                StageController.THEME_ID.SMELT_WORKS => 5,
                StageController.THEME_ID.WATER => 6,
                StageController.THEME_ID.HIVE => 7,
                StageController.THEME_ID.MAGIC_LANDFILL => 8,
                StageController.THEME_ID.DK_CASTLE => 9,
                StageController.THEME_ID.CHRYSTAL_CORE => 10,
                _ => 0
            };
            Plugin.ArchipelagoClient.CheckLocation(id);

            if (id == 10) // TODO: This should be moved out to some APGoalHandler, since options can change goal so this might not be our goal
            {
                Plugin.ArchipelagoClient.Session.SetGoalAchieved();
            }
        }
    }
}
