using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace ShovelKnightDigAP
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

            // Make a Harmony instance, patch all the methods

            // Not sure if manual patching or automatic patching with attributes is better?
        }
    }
}
