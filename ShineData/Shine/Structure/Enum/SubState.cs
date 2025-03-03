using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum SubState : uint
{
    [Description("STR Rate")]
    SUBAB_STRRATE = 0,
    [Description("STR Plus")]
    SUBAB_STRPLUS = 1,
    [Description("Physical Damage Plus")]
    SUBAB_WCPLUS = 2,
    [Description("Physical Damage Rate")]
    SUBAB_WCRATE = 3,
    [Description("Physical Defense Plus")]
    SUBAB_ACPLUS = 4,
    [Description("Physical Defense Rate")]
    SUBAB_ACRATE = 5,
    [Description("DEX Plus")]
    SUBAB_DEXPLUS = 6,
    [Description("Evasion Plus")]
    SUBAB_TBPLUS = 7,
    [Description("Evasion Rate")]
    SUBAB_TBRATE = 8,
    [Description("Aim Plus")]
    SUBAB_THPLUS = 9,
    [Description("Aim Rate")]
    SUBAB_THRATE = 10,
    [Description("INT Plus")]
    SUBAB_INTPLUS = 11,
    [Description("Magic Damage Plus")]
    SUBAB_MAPLUS = 12,
    [Description("MEN Plus")]
    SUBAB_MENPLUS = 13,
    [Description("Magic Resistance Plus")]
    SUBAB_MRPLUS = 14,
    [Description("Magic Resistance Rate")]
    SUBAB_MRRATE = 15,
    [Description("Damage Shield")]
    SUBAB_DAMAGESHIELD = 16,
    [Description("Mana Shield")]
    SUBAB_MANASHIELD = 17,
    [Description("Shield Rate")]
    SUBAB_SHIELDACRATE = 18,
    [Description("Movement Speed")]
    SUBAB_MOVESPEED = 19,
    [Description("Attack Speed")]
    SUBAB_ATKSPEED = 20,
    [Description("Stun")]
    SUBAB_STUN = 21,
    [Description("Bleeding")]
    SUBAB_BLOODING = 22,
    [Description("Entangle")]
    SUBAB_ENTANGLE = 23,
    [Description("Max HP Rate")]
    SUBAB_MAXHPRATE = 24,
    [Description("Max SP Rate")]
    SUBAB_MAXSPRATE = 25,
    [Description("Dead HP SP Recover Rate")]
    SUBAB_DEADHPSPRECOVRATE = 26,
    [Description("Dot Damage")]
    SUBAB_DOTDAMAGE = 27,
    [Description("Fear")]
    SUBAB_FEAR = 28,
    [Description("Consume HP SP")]
    SUBAB_CONHEAL = 29,
    [Description("Casting Time Plus")]
    SUBAB_CASTINGTIMEPLUS = 30,
    [Description("Cool Time Remove")]
    SUBAB_COOLTIMEREMOVE = 31,
    [Description("Magic Attack No Use")]
    SUBAB_MAGICATTACKNOUSE = 32,
    [Description("Poison")]
    SUBAB_POISON = 33,
    [Description("Disease")]
    SUBAB_DISEASE = 34,
    [Description("Curse")]
    SUBAB_CURSE = 35,
    [Description("Resist")]
    SUBAB_RESIST = 36,
    [Description("Critical Rate")]
    SUBAB_CRITICALRATE = 37,
    [Description("Default")]
    SUBAB_DEFAULT = 38,
    [Description("Max HP Plus")]
    SUBAB_MAXHPPLUS = 39,
    [Description("Max SP Plus")]
    SUBAB_MAXSPPLUS = 40,
    [Description("Consume HP SP Heal")]
    SUBAB_CONSPHEAL = 41,
    [Description("Quest Stun")]
    SUBAB_QUESTSTUN = 42,
    [Description("Physical Damage Minus")]
    SUBAB_WCMINUS = 43,
    [Description("DEX Minus")]
    SUBAB_DEXMINUS = 44,
    [Description("Physical Defense Minus")]
    SUBAB_ACMINUS = 45,
    [Description("Magic Resistance Minus")]
    SUBAB_MRMINUS = 46,
    [Description("STR Minus")]
    SUBAB_STRMINUS = 47,
    [Description("Aim Minus")]
    SUBAB_THMINUS = 0x30,
    [Description("Evasion Minus")]
    SUBAB_TBMINUS = 0x31,
    [Description("Curse Magic Resistance")]
    SUBAB_CURSEMR = 0x32,
    [Description("Curse Aim")]
    SUBAB_CURSETH = 0x33,
    [Description("Curse Physical Defense")]
    SUBAB_CURSEAC = 0x34,
    [Description("Curse Evasion")]
    SUBAB_CURSETB = 0x35,
    [Description("Curse Dexterity")]
    SUBAB_CURSEDEX = 0x36,
    [Description("Curse Physical Damage")]
    SUBAB_CURSEWC = 0x37,
    [Description("Intelligence Rate")]
    SUBAB_INTRATE = 0x38,
    [Description("Curse Critical")]
    SUBAB_CURSECRITICAL = 0x39,
    [Description("Self Revive")]
    SUBAB_SELFREVIVE = 0x3A,
    [Description("Range Shield Counter")]
    SUBAB_RANGESHIELDCOUNTER = 0x3B,
    [Description("Hide")]
    SUBAB_HIDE = 0x3C,
    [Description("Blind")]
    SUBAB_BLIND = 0x3D,
    [Description("Deadly Blessing")]
    SUBAB_DEADLYBLESSING = 0x3E,
    [Description("Guild Buff AC")]
    SUBAB_GUILDBUFAC = 0x3F,
    [Description("Natural Enemy")]
    SUBAB_NATURALENEMY = 0x40,
    [Description("Quest Entangle")]
    SUBAB_QUESTENTANGLE = 0x41,
    [Description("Consume HP SP Heal")]
    SUBAB_CONHPSPHEAL = 0x42,
    [Description("Knockback")]
    SUBAB_KNOCKBACK = 0x43,
    [Description("Fatal Knockback")]
    SUBAB_FATALKNOCKBACK = 0x44,
    [Description("Event Transform")]
    SUBAB_EVENTTRANSFORM = 0x45,
    [Description("Captivate")]
    SUBAB_CAPTIVATE = 0x46,
    [Description("Can't Heal")]
    SUBAB_CANTHEAL = 0x47,
    [Description("Can't Chat")]
    SUBAB_CANTCHAT = 0x48,
    [Description("AC Mode")]
    SUBAB_ACMODE = 0x49,
    [Description("MR Mode")]
    SUBAB_MRMODE = 0x4A,
    [Description("Angry")]
    SUBAB_ANGRY = 0x4B,
    [Description("Damage Neglect")]
    SUBAB_DAMAGENEGLECT = 0x4C,
    [Description("Time Attack")]
    SUBAB_TIMEATTACK = 0x4D,
    [Description("Detach Process")]
    SUBAB_DETACHPROCESS = 0x4E,
    [Description("Malephar Damage Rate")]
    SUBAB_HUMARWCRATE = 0x4F,
    [Description("Malephar Defense Rate")]
    SUBAB_HUMARACRATE = 0x50,
    [Description("Physical Defense Down Rate")]
    SUBAB_ACDOWNRATE = 0x51,
    [Description("Guild Tournament")]
    SUBAB_GTI = 0x52,
    [Description("Burn")]
    SUBAB_BURN = 0x53,
    [Description("Fit Blooding")]
    SUBAB_FITBLOODING = 0x54,
    [Description("Range Evasion")]
    SUBAB_RANGEEVASION = 0x55,
    [Description("Use SP Rate")]
    SUBAB_USESPRATE = 0x56,
    [Description("Soul Free")]
    SUBAB_SOULFREE = 0x57,
    [Description("Onetime Cannot Use Skill")]
    SUBAB_ONETIMECANNOTUSESKILL = 0x58,
    [Description("Mob AP UP")]
    SUBAB_MOBAPU = 0x59,
    [Description("Helga None")]
    SUBAB_HELGANONE = 0x5A,
    [Description("Helga Ball")]
    SUBAB_HELGBALL = 0x5B,
    SUBAB_UBAUP = 0x5C,
    SUBAB_UBADOWN = 0x5D,
    [Description("Burn Pain Self")]
    SUBAB_BURNPAINME = 0x5E,
    [Description("Burn Pain Enemy")]
    SUBAB_BURNPAINFOE = 0x5F,
    [Description("Airborne")]
    SUBAB_AIRBORNE = 0x60,
    [Description("Bomb Shot")]
    SUBAB_BOMBSHOT = 0x61,
    [Description("Cross Drop")]
    SUBAB_CROSSDROP = 0x62,
    [Description("Meteor")]
    SUBAB_METEOR = 0x63,
    [Description("Use SP Down")]
    SUBAB_USESPDOWN = 0x64,
    [Description("Mental Down Rate Self")]
    SUBAB_MENDOWNRATEME = 0x65,
    [Description("Mental Down Rate")]
    SUBAB_MENDOWNRATE = 0x66,
    [Description("Critical Up Rate")]
    SUBAB_CRIUPRATE = 0x67,
    [Description("Damage Shield")]
    SUBAB_DMGSHIELD = 0x68,
    [Description("Cannot Target")]
    SUBAB_CANNOTTARGET = 0x69,
    [Description("Hide Damage")]
    SUBAB_HIDEDAMAGE = 0x6A,
    [Description("Magic Field")]
    SUBAB_MAGICFIELD = 0x6B,
    [Description("Mine Reward")]
    SUBAB_MINEREWARD = 0x6C,
    [Description("EXP Rate")]
    SUBAB_EXPRATE = 0x6D,
    [Description("Drop Rate")]
    SUBAB_DROPRATE = 0x6E,
    [Description("Magical Damage Rate")]
    SUBAB_MARATE = 0x6F,
    [Description("Surprise")]
    SUBAB_SURPRISE = 0x70,
    [Description("Dispel")]
    SUBAB_DISPEL = 0x71,
    [Description("Range Damage Rate")]
    SUBAB_RANGEDMGDOWNRATE = 0x72,
    [Description("Damage Shield Rate")]
    SUBAB_DMGSHIELDRATE = 0x73,
    [Description("Damage Down Rate")]
    SUBAB_DMGDOWNRATE = 0x74,
    [Description("Min HP")]
    SUBAB_MINHP = 0x75,
    [Description("Delete Casting")]
    SUBAB_DELCASTING = 0x76,
    [Description("Range Damage Rate ATK")]
    SUBAB_RANGEDMGDOWNRATEATK = 0x77,
}