using System.ComponentModel;

namespace ShineData.Shine.Structure.Dialog;

public enum QuestDialogType : byte
{
    [Description("None")]
    QDT_NONE = 0,
    [Description("Title")]
    QDT_TITLE = 1,
    [Description("Description")]
    QDT_DESCRIPTION = 2,
    [Description("Dialog")]
    QDT_DIALOG = 3
}