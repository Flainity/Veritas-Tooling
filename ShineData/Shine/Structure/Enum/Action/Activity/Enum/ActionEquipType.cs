using System.ComponentModel;

namespace ShineData.Shine.Structure.Enum.Action.Activity.Enum;

public enum ActionEquipType : uint
{
    [Description("Equip Item")]
    AET_ITEM_EQUIP = 0,
    [Description("Use Item")]
    AET_ITEM_USE = 1
}