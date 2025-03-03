using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum;

public enum SkillEffectIncreaseType : uint
{
    [Description("Damage Rate Increase")]
    SEIT_DAMAGE_RATE_INCREASE,
    [Description("Cooldown Rate Decrease")]
    SEIT_COOLTIME_RATE_DECREASE,
    [Description("Keeptime Rate Increase")]
    SEIT_KEEPTIME_RATE_INCREASE,
    [Description("Use SP Rate Decrease")]
    SEIT_USESP_RATE_DECREASE,
    [Description("Abstate Defense Rate Decrease")]
    SEIT_STA_AC_RATE_DECREASE,
    [Description("Aggro Rate Increase")]
    SEIT_AGGRO_RATE_INCREASE,
    [Description("Abstate Dexterity Rate Decrease")]
    SEIT_STA_DEX_RATE_DECREASE,
    [Description("Aim & HP Rate Increase")]
    SEIT_SS_RATE_THHPUP,
    [Description("Abstate Max HP & SP Rate Increase")]
    SEIT_STA_MAX_HPSP_RATE_INCREASE,
    [Description("Abstate Death HP & SP Recovery Rate Increase")]
    SEIT_STA_DEAD_HPSP_RECOVER_RATE_INCREASE,
    [Description("Abstate Shield Defense Rate Increase")]
    SEIT_STA_SHIELDAC_RATE_INDREASE,
    [Description("Heal Rate Increase")]
    SEIT_HEAL_RATE_INCREASE,
    [Description("Abstate DOT Heal Rate Increase")]
    SEIT_STA_DOT_HEAL_RATE_INCREASE,
    [Description("Abstate Damage Rate Increase")]
    SEIT_STA_WC_RATE_INCEASE,
    [Description("Abstate Shield Block Rate Increase")]
    SEIT_STA_SHEILD_BLOCK_RATE_INCREASE,
}