using ShovelKnightDigAPClient.Utils;

namespace ShovelKnightDigAPClient.Archipelago
{
    public static class ReceivedItemHandler
    {
        public static void Handle(global::Archipelago.MultiClient.Net.Models.ItemInfo receivedItem)
        {
            Plugin.BepinLogger.LogMessage("We received an item, handling it now!");

            switch (receivedItem.ItemId)
            {
                case 1:
                    {
                        // Cog on a String
                        Plugin.BepinLogger.LogMessage("Received Cog on a String Unlock!");
                        SaveManager.SetInt("ap received cog string", 1);
                        SaveManager.Save();
                        break;
                    }
                case 2:
                    {
                        // Altius
                        Plugin.BepinLogger.LogMessage($"Received Altius in Overworld!");
                        SaveManager.SetInt("ap received owl", 1);
                        SaveManager.Save();
                        break;
                    }
                case 3:
                    {
                        // Skeleton Key
                        Plugin.BepinLogger.LogMessage($"Received Skeleton Key Unlock!");
                        SaveManager.SetInt("ap received skeleton key", 1);
                        SaveManager.Save();
                        break;
                    }
                case 4:
                    {
                        // Follow Slot Upgrade
                        Plugin.BepinLogger.LogMessage("Received Follow Slot Upgrade!");
                        Inventory.Player1Inventory.IncrementMaxFollowItems();
                        break;
                    }
                case 5:
                    {
                        // Gems
                        Plugin.BepinLogger.LogMessage("Received 1000 Gems!");
                        StageController.totalGold += 1000; // TODO: Never use a magic number >:(
                        UICanvas.UI.UpdateTotalGoldCounter();
                        SaveManager.SetInt("total gold", StageController.totalGold);
                        SaveManager.Save();
                        break;
                    }
                default:
                    {
                        Plugin.BepinLogger.LogMessage($"Received {receivedItem.ItemName}!");
                        var upgradeItemID = APWorldMaps.ItemIDInternalDict[receivedItem.ItemId];
                        var upgradeItem = Inventory.GetItemByID(upgradeItemID);
                        Inventory.Player1Inventory.AddPermItem(upgradeItem);
                        break;
                    }
            }
        }
    }
}