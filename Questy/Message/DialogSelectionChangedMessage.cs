using CommunityToolkit.Mvvm.Messaging.Messages;
using ShineData.Shine.Structure.Dialog;

namespace Questy.Message;

public class DialogSelectionChangedMessage : ValueChangedMessage<QuestDialog>
{
    public DialogSelectionChangedMessage(QuestDialog value) : base(value)
    {
    }
}