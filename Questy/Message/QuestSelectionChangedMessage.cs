using CommunityToolkit.Mvvm.Messaging.Messages;
using ShineData.Shine.Structure.Quest;

namespace Questy.Message;

public class QuestSelectionChangedMessage : ValueChangedMessage<Quest>
{
    public QuestSelectionChangedMessage(Quest value) : base(value)
    {
    }
}