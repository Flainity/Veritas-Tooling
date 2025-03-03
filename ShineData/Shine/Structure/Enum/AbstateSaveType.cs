using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShineData.Shine.Structure.Enum;

public enum AbstateSaveType : uint
{
    [Description("None")]
    AST_NONE = 0x0,
    [Description("Logoff")]
    AST_LINK_LOGOFF = 0x1,
    [Description("Logoff or Death")]
    AST_LINK_LOGOFF_DIE = 0x2,
    [Description("Death")]
    AST_LINK_DIE = 0x3
}