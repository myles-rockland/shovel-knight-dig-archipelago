using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ShovelKnightDigAPClient.Archipelago;
using ShovelKnightDigAPClient.MonoBehaviours;
using ShovelKnightDigAPClient.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace ShovelKnightDigAPClient
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.rockm.shovelknightdigapclient";
        public const string PluginName = "ShovelKnightDigAPClient";
        public const string PluginVersion = "0.0.2";

        private Harmony _harmony = new Harmony(PluginGUID);

        public const string ModDisplayInfo = $"{PluginName} v{PluginVersion}";
        private const string APDisplayInfo = $"Archipelago v{ArchipelagoClient.APVersion}";
        public static ManualLogSource BepinLogger;
        public static ArchipelagoClient ArchipelagoClient;

        private AssetBundle apAssetBundle;

        private void Awake()
        {
            // Plugin startup logic
            BepinLogger = Logger;
            ArchipelagoClient = new ArchipelagoClient();
            ArchipelagoConsole.Awake();

            ArchipelagoConsole.LogMessage($"{ModDisplayInfo} loaded!");

            // CUSTOM AP ITEM STUFF
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string resourceName = $"{assemblyName}.assetbundles.ap";

            apAssetBundle = BundleLoader.LoadEmbeddedBundle(resourceName);

            if (apAssetBundle == null)
            {
                Logger.LogError("Failed to load bundle from memory");
                return;
            }

            var upgradeItemPaths = new List<string>()
            {
                "Assets/Upgrade Items/AP Items/Hoofmans_Shop_1.asset",
                "Assets/Upgrade Items/AP Items/Chester_Surface_Shop_1.asset",
            };

            Array.Resize(ref Inventory.Player1Inventory.m_PermanentUpgradeItems,
                Inventory.Player1Inventory.m_PermanentUpgradeItems.Length + upgradeItemPaths.Count);

            for (int i = upgradeItemPaths.Count - 1; i >= 0; i--)
            {
                var upgradeItemPath = upgradeItemPaths[i];
                var upgradeItem = apAssetBundle.LoadAsset<UpgradeItem>(upgradeItemPath);
                if (upgradeItem != null)
                {
                    BepinLogger.LogInfo($"Loaded: {upgradeItem.m_ItemName}");
                }
                else
                {
                    BepinLogger.LogInfo($"Failed to load UpgradeItem at {upgradeItemPath}");
                }
                Inventory.Player1Inventory.m_PermanentUpgradeItems[^(i + 1)] = upgradeItem;
            }

            // Then, when populating m_ItemCatalogue (which happens before ShopUI_new.CreateOverworldShopList),
            // replace it with these!

            //////////////////////////////////////////////////////////////////////////

            CreateSubscribers();

            _harmony.PatchAll();
            BepinLogger.LogMessage("Methods patched!");
        }

        private void OnDestroy()
        {
            apAssetBundle.Unload(true);
        }

        private void OnGUI()
        {
            // show the mod is currently loaded in the corner
            GUI.Label(new Rect(16, 16, 300, 20), ModDisplayInfo);
            ArchipelagoConsole.OnGUI();

            string statusMessage;
            // show the Archipelago Version and whether we're connected or not
            if (ArchipelagoClient.Authenticated)
            {
                // if your game doesn't usually show the cursor this line may be necessary
                Cursor.visible = false;

                statusMessage = " Status: Connected";
                GUI.Label(new Rect(16, 50, 300, 20), APDisplayInfo + statusMessage);
            }
            else
            {
                // if your game doesn't usually show the cursor this line may be necessary
                Cursor.visible = true;

                statusMessage = " Status: Disconnected";
                GUI.Label(new Rect(16, 50, 300, 20), APDisplayInfo + statusMessage);
                GUI.Label(new Rect(16, 70, 150, 20), "Host: ");
                GUI.Label(new Rect(16, 90, 150, 20), "Player Name: ");
                GUI.Label(new Rect(16, 110, 150, 20), "Password: ");

                ArchipelagoClient.ServerData.Uri = GUI.TextField(new Rect(150, 70, 150, 20),
                    ArchipelagoClient.ServerData.Uri);
                ArchipelagoClient.ServerData.SlotName = GUI.TextField(new Rect(150, 90, 150, 20),
                    ArchipelagoClient.ServerData.SlotName);
                ArchipelagoClient.ServerData.Password = GUI.TextField(new Rect(150, 110, 150, 20),
                    ArchipelagoClient.ServerData.Password);

                // requires that the player at least puts *something* in the slot name
                if (GUI.Button(new Rect(16, 130, 100, 20), "Connect") &&
                    !ArchipelagoClient.ServerData.SlotName.IsNullOrWhiteSpace())
                {
                    ArchipelagoClient.Connect();
                }
            }
            // this is a good place to create and add a bunch of debug buttons
        }

        private void CreateSubscribers()
        {
            var subscribersList = new List<GameObject>
            {
                new GameObject("BossDefeatSubscriber", typeof(BossDefeatSubscriber))
            };

            foreach (var subscriber in subscribersList)
            {
                subscriber.hideFlags = HideFlags.HideAndDontSave;
                DontDestroyOnLoad(subscriber);
            }

            BepinLogger.LogMessage("Created subscribers!");
        }
    }
}