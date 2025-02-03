namespace ShineData.Shine.Structure.Dialog;

public class QuestDialog
{
    public uint Id { get; set; }
    public string Dialog { get; set; }
    public QuestDialogType Type { get; set; }
    
    public QuestDialog(uint id, string dialog, QuestDialogType type)
    {
        Id = id;
        Dialog = dialog;
        Type = type;
    }
    
    public override string ToString()
    {
        var sanitizedDialog = Dialog.Replace("\n", "").Replace("\r", "");
        var truncatedDialog = sanitizedDialog.Length > 38 ? sanitizedDialog[..38] : sanitizedDialog;
        return $"{Id} - {truncatedDialog}";
    }
}