using System.ComponentModel.DataAnnotations;

namespace ShineData.Shine.Structure.Enum;

public enum AbstateSaveType : uint
{
    AST_NONE = 0x0,
    AST_LINK_LOGOFF = 0x1,
    AST_LINK_LOGOFF_DIE = 0x2,
    AST_LINK_DIE = 0x3
}