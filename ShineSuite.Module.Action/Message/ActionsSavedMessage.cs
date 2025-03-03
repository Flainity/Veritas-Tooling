using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ShineSuite.Module.Action.Message;

public class ActionsSavedMessage : ValueChangedMessage<bool>
{
    public ActionsSavedMessage(bool value) : base(value)
    {
    }
}