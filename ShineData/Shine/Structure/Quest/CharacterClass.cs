// Copyright 2019 RED Software, LLC. All Rights Reserved.

using System.ComponentModel;

namespace ShineData.Shine.Structure.Quest
{
    public enum CharacterClass : byte
    {
        [Description("None")]
        CC_NONE = 0,
        [Description("Fighter")]
        CC_FIGHTER = 1,
        [Description("Clever Fighter")]
        CC_CLEVER_FIGHTER = 2,
        [Description("Warrior")]
        CC_WARRIOR = 3,
        [Description("Gladiator")]
        CC_GLADIATOR = 4,
        [Description("Knight")]
        CC_KNIGHT = 5,
        [Description("Cleric")]
        CC_CLERIC = 6,
        [Description("High Cleric")]
        CC_HIGH_CLERIC = 7,
        [Description("Paladin")]
        CC_PALADIN = 8,
        [Description("Holy Knight")]
        CC_HOLY_KNIGHT = 9,
        [Description("Guardian")]
        CC_GUARDIAN = 10,
        [Description("Archer")]
        CC_ARCHER = 11,
        [Description("Hawk Archer")]
        CC_HAWK_ARCHER = 12,
        [Description("Scout")]
        CC_SCOUT = 13,
        [Description("Sharpshooter")]
        CC_SHARPSHOOTER = 14,
        [Description("Ranger")]
        CC_RANGER = 15,
        [Description("Mage")]
        CC_MAGE = 16,
        [Description("Wiz Mage")]
        CC_WIZ_MAGE = 17,
        [Description("Enchanter")]
        CC_ENCHANTER = 18,
        [Description("Warlock")]
        CC_WARLOCK = 19,
        [Description("Wizard")]
        CC_WIZARD = 20,
        [Description("Trickster")]
        CC_TRICKSTER = 21,
        [Description("Gambit")]
        CC_GAMBIT = 22,
        [Description("Renegade")]
        CC_RENEGADE = 23,
        [Description("Spectre")]
        CC_SPECTRE = 24,
        [Description("Reaper")]
        CC_REAPER = 25,
        [Description("Crusader")]
        CC_CRUSADER = 26,
        [Description("Templar")]
        CC_TEMPLAR = 27
    }
}
