using CommunityToolkit.Mvvm.Messaging.Messages;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Abstate.Message;

public class SelectedAbstateChangedMessage : ValueChangedMessage<AbStateEntry>
{
    public SelectedAbstateChangedMessage(AbStateEntry value) : base(value)
    {
    }
}