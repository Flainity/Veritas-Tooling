using CommunityToolkit.Mvvm.Messaging.Messages;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Abstate.Message;

public class SelectedAbstateChangedMessage : ValueChangedMessage<AbState>
{
    public SelectedAbstateChangedMessage(AbState value) : base(value)
    {
    }
}