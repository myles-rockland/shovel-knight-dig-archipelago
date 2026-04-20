using System.Collections.Generic;

namespace ShovelKnightDigAPClient.Utils
{
    public class APWorldMaps
    {
        private static Dictionary<string, string> itemNameIDDict = new()
        {
            { "Cog on a String", "COG_STRING" },
            { "Altius", "" }, // Not an item
            { "Skeleton Key", "KEY_SKELETON" }, // This is a special case since it never really gets "unlocked"
            { "Follow Slot Upgrade", "" }, // There is FOLLOW_CONTAINER_1 and FOLLOW_CONTAINER_2...
            { "Gems", "" }, // Not an item

            { "Enchanted Slamvil", "BOSS_BAD_NEWS" },
            { "Suave Salve", "CHARM_SPELL" },
            { "Burrow Horns", "HEADBUTT" },
            { "Comet Collar", "SUPER_KNOCKBACK" },
            { "Berserker Bauble", "BERSERKER" },
            { "Inverse Repeller", "GOLD_MAGNET" },
            { "Lucky U-shaped Charm", "HORSESHOE" },
            { "Spikeproof Sabatons", "IRON_BOOTS" },
            { "Scoot Boots", "SPEED_BOOTS" },
            { "Leaping Plume", "JUMPIN_FEATHER" },
            { "Book of Bomb", "CHAIN_EXPLODE" },
            { "Looking Glass", "LOOKING_GLASS" },
            { "Platter Charm", "LUCKY_FOOD_CHARM" },
            { "Boom Rock Trigger", "POP_ROCK" },
            { "Flameo Ring", "FIRE_RING" },
            { "Bolteo Ring", "LIGHTNING_RING" },
            { "Blast Ring", "BOMB_RING" },
            { "Blizzeo Ring", "ICE_RING" },
            { "Gusteo Ring", "WING_RING" },
            { "Lucky Magic Vial", "LUCKY_MAGIC_VIAL" },
            { "Tome of Relic Thrift", "POTION_BOOST" },
            { "Fenix Feather", "VIAL_OF_REVIVAL" },
            { "Shovel Blade Flint", "SHOVEL_SWING" },
            { "Dynamo Greaves", "DYNAMO_GREAVES" },
            { "Dynamo Gauntlets", "DYNAMO_GAUNTLETS" },
            { "Dirtwrecker Curse", "DIRTWRECKER" },
            { "Nesting Twigs", "FAMILIAR_LEVEL_UP" },
            { "Wand Wisp", "DOUBLE_WAND_PROJECTILES" },
            { "Boulder Blade", "BREAK_HARD_DIRT" },
            { "Lightward Locket", "LANTERN_GIFT" },
            { "Hoofling's Boot", "WATER_PROJECTILE" },

            { "Pandemonium Plate", "ARMOUR_RANDOM" },
            { "Final Guard", "ARMOUR_FINAL_GUARD" },
            { "Ornate Plate", "ARMOUR_ORNATE_PLATE" },
            { "Streamline Mail", "ARMOUR_REGIMENTED_ARMOUR" },
            { "Scrounger's Suit", "ARMOUR_CHANCE_SUIT" },
            { "Ballistic Armor", "ARMOUR_WACKY_MOBILITY" },
            { "Conjurer's Coat", "ARMOUR_CONJURERS_COAT" },
            { "Brash Bracers", "ARMOUR_GILDED_MAIL" }, // ARMOUR_GILDED_MAIL (and ARMOUR_GILDED_MAIL_OFF when you get hit?)
            { "Combo Cuirass", "ARMOUR_COMBO_CUIRASS" },
            { "Black Knight Suit", "ARMOUR_BLACK_KNIGHT" }
        };

        public static Dictionary<string, string> ItemNameIDDict => itemNameIDDict;

        private static Dictionary<long, string> itemIDInternalDict = new()
        {
            { 1, "COG_STRING" },
            { 2, "" }, // Altius. Not an item
            { 3, "KEY_SKELETON" }, // This is a special case since it never really gets "unlocked"
            { 4, "" }, // Follow Slot Upgrade. There is FOLLOW_CONTAINER_1 and FOLLOW_CONTAINER_2...
            { 5, "" }, // Gems. Not an item

            { 10, "BOSS_BAD_NEWS" },
            { 11, "CHARM_SPELL" },
            { 12, "HEADBUTT" },
            { 13, "SUPER_KNOCKBACK" },
            { 14, "BERSERKER" },
            { 15, "GOLD_MAGNET" },
            { 16, "HORSESHOE" },
            { 17, "IRON_BOOTS" },
            { 18, "SPEED_BOOTS" },
            { 19, "JUMPIN_FEATHER" },
            { 20, "CHAIN_EXPLODE" },
            { 21, "LOOKING_GLASS" },
            { 22, "LUCKY_FOOD_CHARM" },
            { 23, "POP_ROCK" },
            { 24, "FIRE_RING" },
            { 25, "LIGHTNING_RING" },
            { 26, "BOMB_RING" },
            { 27, "ICE_RING" },
            { 28, "WING_RING" },
            { 29, "LUCKY_MAGIC_VIAL" },
            { 30, "POTION_BOOST" },
            { 31, "VIAL_OF_REVIVAL" },
            { 32, "SHOVEL_SWING" },
            { 33, "DYNAMO_GREAVES" },
            { 34, "DYNAMO_GAUNTLETS" },
            { 35, "DIRTWRECKER" },
            { 36, "DROP_SPARK" },
            { 37, "FAMILIAR_LEVEL_UP" },
            { 38, "DOUBLE_WAND_PROJECTILES" },
            { 39, "BREAK_HARD_DIRT" },
            { 40, "LANTERN_GIFT" },
            { 41, "WATER_PROJECTILE" },

            { 50, "ARMOUR_RANDOM" }, // Pandemonium
            { 51, "ARMOUR_FINAL_GUARD" }, // Final guard
            { 52, "ARMOUR_ORNATE_PLATE" }, // Ornate plate
            { 53, "ARMOUR_REGIMENTED_ARMOUR" }, // Streamline Mail
            { 54, "ARMOUR_CHANCE_SUIT" }, // Scrounger's Suit
            { 55, "ARMOUR_WACKY_MOBILITY" }, // Ballistic armour
            { 56, "ARMOUR_CONJURERS_COAT" }, // Conjurer's Coat
            { 57, "ARMOUR_GILDED_MAIL" }, // ARMOUR_GILDED_MAIL (and ARMOUR_GILDED_MAIL_OFF when you get hit?) // Brash bracers
            { 58, "ARMOUR_COMBO_CUIRASS" }, // Combo Cuirass
            { 59, "ARMOUR_BLACK_KNIGHT" } // Black Knight Suit
        };

        public static Dictionary<long, string> ItemIDInternalDict => itemIDInternalDict;

        //private static Dictionary<string, long> locationNameIDDict = new()
        //{
        //    { "Hoofman's Shop 1", 1 },

        //    { "Chester Surface Shop 1", 2 },

        //    { "Mushroom Mines - Stage 1 - Cog 1", 3 },

        //    { "Spore Knight Defeated", 4 },
        //    { "Tinker Knight Defeated", 5 },
        //    { "Mole Knight Defeated", 6 },
        //    { "Hive Knight Defeated", 7 },
        //    { "Scrap Knight Defeated", 8 },
        //    { "Drill Knight Defeated", 9 },
        //    { "The Enchantress Defeated", 10 },
        //};

        //public static Dictionary<string, long> LocationNameIDDict => locationNameIDDict;
    }
}
