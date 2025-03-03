using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum SubAbstateAction : uint
{
    [Description("None")]
    SAA_NONE = 0x0,
    [Description("Strength Rate")]
    SAA_STRRATE = 0x1,
    [Description("Strength Plus")]
    SAA_STRPLUS = 0x2,
    [Description("Physical Damage Plus")]
    SAA_WCPLUS = 0x3,
    [Description("Physical Damage Rate")]
    SAA_WCRATE = 0x4,
    [Description("Physical Resistance Plus")]
    SAA_ACPLUS = 0x5,
    [Description("Physical Resistance Rate")]
    SAA_ACRATE = 0x6,
    [Description("Dexterity Plus")]
    SAA_DEXPLUS = 0x7,
    [Description("Evasion Plus")]
    SAA_TBPLUS = 0x8,
    [Description("Evasion Rate")]
    SAA_TBRATE = 0x9,
    [Description("Aim Plus")]
    SAA_THPLUS = 0xA,
    [Description("Aim Rate")]
    SAA_THRATE = 0xB,
    [Description("Intelligence Plus")]
    SAA_INTPLUS = 0xC,
    [Description("Magical Damage Plus")]
    SAA_MAPLUS = 0xD,
    [Description("Mental Plus")]
    SAA_MENTALPLUS = 0xE,
    [Description("Magical Resistance Plus")]
    SAA_MRPLUS = 0xF,
    [Description("Magical Resistance Rate")]
    SAA_MRRATE = 0x10,
    [Description("Shield Amount")]
    SAA_SHIELDAMOUNT = 0x11,
    [Description("Shield Physical Resistance Rate")]
    SAA_SHIELDACRATE = 0x12,
    [Description("No Movement")]
    SAA_NOMOVE = 0x13,
    [Description("Speed Rate")]
    SAA_SPEEDRATE = 0x14,
    [Description("Attack Speed Rate")]
    SAA_ATTACKSPEEDRATE = 0x15,
    [Description("Max HP Rate")]
    SAA_MAXHPRATE = 0x16,
    [Description("Max SP Rate")]
    SAA_MAXSPRATE = 0x17,
    [Description("Dead HP Recovery Rate")]
    SAA_DEADHPSPRECOVRATE = 0x18,
    [Description("No Attack")]
    SAA_NOATTACK = 0x19,
    [Description("Tick")]
    SAA_TICK = 0x1A,
    [Description("Damage Over Time")]
    SAA_DOTDAMAGE = 0x1B,
    [Description("Continuous Heal")]
    SAA_CONHEAL = 0x1C,
    [Description("Casting Time Plus")]
    SAA_CASTINGTIMEPLUS = 0x1D,
    [Description("Heal Amount")]
    SAA_HEALAMOUNT = 0x1E,
    [Description("Poison Resistance Rate")]
    SAA_POISONRESISTRATE = 0x1F,
    [Description("Disease Resistance Rate")]
    SAA_DISEASERESISTRATE = 0x20,
    [Description("Curse Resistance Rate")]
    SAA_CURSERESISTRATE = 0x21,
    [Description("Critical Rate")]
    SAA_CRITICALRATE = 0x22,
    [Description("Max HP Plus")]
    SAA_MAXHPPLUS = 0x23,
    [Description("Max SP Plus")]
    SAA_MAXSPPLUS = 0x24,
    [Description("Intelligence Rate")]
    SAA_INTRATE = 0x25,
    [Description("Fear")]
    SAA_FEAR = 0x26,
    [Description("All Stats Plus")]
    SAA_ALLSTATEPLUS = 0x27,
    [Description("Revive Heal Rate")]
    SAA_REVIVEHEALRATE = 0x28,
    [Description("Count")]
    SAA_COUNT = 0x29,
    [Description("Silence")]
    SAA_SILIENCE = 0x2A,
    [Description("Deadly Blessing")]
    SAA_DEADLYBLESSING = 0x2B,
    [Description("Damage Rate")]
    SAA_DAMAGERATE = 0x2C,
    [Description("Target Enemy")]
    SAA_TARGETENEMY = 0x2D,
    [Description("Magical Damage Rate")]
    SAA_MARATE = 0x2E,
    [Description("Heal Rate")]
    SAA_HEALRATE = 0x2F,
    [Description("Damage Over Time Rate")]
    SAA_DOTRATE = 0x30,
    [Description("Away")]
    SAA_AWAY = 0x31,
    [Description("Total Damage Rate")]
    SAA_TOTALDAMAGERATE = 0x32,
    [Description("Dispel Speed Rate")]
    SAA_DISPELSPEEDRATE = 0x33,
    [Description("Set Abstate Me")]
    SAA_SETABSTATEME = 0x34,
    [Description("Set Abstate Friend")]
    SAA_SETABSTATEFRIEND = 0x35,
    [Description("Set Abstate")]
    SAA_SETABSTATE = 0x36,
    [Description("Area Effect")]
    SAA_AREA = 0x37,
    [Description("GTI Resistance Rate")]
    SAA_GTIRESISTRATE = 0x38,
    [Description("Max HP Rate Damage")]
    SAA_MAXHPRATEDAMAGE = 0x39,
    [Description("Meta Ability")]
    SAA_METAABILITY = 0x3A,
    [Description("Meta Skin")]
    SAA_METASKIN = 0x3B,
    [Description("Miss Rate")]
    SAA_MISSRATE = 0x3C,
    [Description("Reflect Damage")]
    SAA_REFLECTDAMAGE = 0x3D,
    [Description("Release Action")]
    SAA_RELESEACTION = 0x3E,
    [Description("Scan Enemy User")]
    SAA_SCANENEMYUSER = 0x3F,
    [Description("Target All")]
    SAA_TARGETALL = 0x40,
    [Description("Hide Enemy")]
    SAA_HIDEENEMY = 0x41,
    [Description("Target Not Me")]
    SAA_TARGETNOTME = 0x42,
    [Description("DOT Die Damage")]
    SAA_DOTDIEDAMAGE = 0x43,
    [Description("Add All DOT Damage")]
    SAA_ADDALLDOTDMG = 0x44,
    [Description("Add Bleeding Damage")]
    SAA_ADDBLOODINGDMG = 0x45,
    [Description("Add Poison Damage")]
    SAA_ADDPOISONDMG = 0x46,
    [Description("Evasion Amount")]
    SAA_EVASIONAMOUNT = 0x47,
    [Description("Use SP Rate")]
    SAA_USESPRATE = 0x48,
    [Description("Physical Resistance Minus")]
    SAA_ACMINUS = 0x49,
    [Description("Physical Resistance Down Rate")]
    SAA_ACDOWNRATE = 0x4A,
    [Description("Subtract All DOT Damage")]
    SAA_SUBTRACTALLDOTDMG = 0x4B,
    [Description("Subtract Bleeding Damage")]
    SAA_SUBTRACTBLOODINGDMG = 0x4C,
    [Description("Subtract Poison Damage")]
    SAA_SUBTRACTPOISONDMG = 0x4D,
    [Description("Attack Speed Down Rate")]
    SAA_ATKSPEEDDOWNRATE = 0x4E,
    [Description("Away Back")]
    SAA_AWAYBACK = 0x4F,
    [Description("Critical Down Rate")]
    SAA_CRITICALDOWNRATE = 0x50,
    [Description("Dexterity Minus")]
    SAA_DEXMINUS = 0x51,
    [Description("Heal Amount Minus")]
    SAA_HEALAMOUNTMINUS = 0x52,
    [Description("Magical Damage Minus")]
    SAA_MAMINUS = 0x53,
    [Description("Magical Damage Down Rate")]
    SAA_MADOWNRATE = 0x54,
    [Description("Max HP Down Rate")]
    SAA_MAXHPDOWNRATE = 0x55,
    [Description("Magical Resistance Minus")]
    SAA_MRMINUS = 0x56,
    [Description("Magical Resistance Down Rate")]
    SAA_MRDOWNRATE = 0x57,
    [Description("Speed Down Rate")]
    SAA_SPEEDDOWNRATE = 0x58,
    [Description("Strength Minus")]
    SAA_STRMINUS = 0x59,
    [Description("Evasion Minus")]
    SAA_TBMINUS = 0x5A,
    [Description("Evasion Down Rate")]
    SAA_TBDOWNRATE = 0x5B,
    [Description("Aim Minus")]
    SAA_THMINUS = 0x5C,
    [Description("Aim Down Rate")]
    SAA_THDOWNRATE = 0x5D,
    [Description("Physical Damage Minus")]
    SAA_WCMINUS = 0x5E,
    [Description("Physical Damage Down Rate")]
    SAA_WCDOWNRATE = 0x5F,
    [Description("DOT Physical Damage Rate")]
    SAA_DOTWCRATE = 0x60,
    [Description("Target Number Version")]
    SAA_TARGETNUMVER = 0x61,
    [Description("DOT Magical Damage Rate")]
    SAA_DOTMARATE = 0x62,
    [Description("Magical Damage Down Rate")]
    SAA_MENDOWNRATE = 0x63,
    [Description("Use SP Down")]
    SAA_USESPDOWN = 0x64,
    [Description("Critical Up Rate")]
    SAA_CRIUPRATE = 0x65,
    [Description("Magical Resistance Shield Rate")]
    SAA_MRSHIELDRATE = 0x66,
    [Description("Physical Resistance Shield Rate")]
    SAA_ACSHIELDRATE = 0x67,
    [Description("Monster Stick")]
    SAA_MONSTERSTICK = 0x68,
    [Description("Set Active Skill")]
    SAA_SETACTIVESKILL = 0x69,
    [Description("HP Rate Damage")]
    SAA_HPRATEDAMAGE = 0x6A,
    [Description("EXP Rate")]
    SAA_EXPRATE = 0x6B,
    [Description("Drop Rate")]
    SAA_DROPRATE = 0x6C,
    [Description("Away Back Spot")]
    SAA_AWAYBACKSPOT = 0x6D,
    [Description("Stop Animation")]
    SAA_STOPANI = 0x6E,
    [Description("DOT Damage Down Rate")]
    SAA_DOTDMGDOWNRATE = 0x6F,
    [Description("Shield Rate")]
    SAA_SHIELDRATE = 0x70,
    [Description("LP Amount")]
    SAA_LPAMOUNT = 0x71,
    [Description("Min HP")]
    SAA_MINHP = 0x72,
    [Description("Damage Down Rate")]
    SAA_DMGDOWNRATE = 0x73,
    [Description("Speed Resist Rate")]
    SAA_SPEEDRESISTRATE = 0x74,
    [Description("Melee")]
    SAA_MELEE = 0x75,
    [Description("Range")]
    SAA_RANGE = 0x76,
    [Description("All Stats Plus")]
    SAA_ALLSTATPLUS = 0x77,
    [Description("Range Over")]
    SAA_RANGEOVER = 0x78,
}