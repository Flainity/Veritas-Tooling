using CommunityToolkit.Mvvm.Messaging.Messages;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Action.Message;

public class SelectedItemActionChanged : ValueChangedMessage<ItemActionEffectDescEntry>
{
    public SelectedItemActionChanged(ItemActionEffectDescEntry value) : base(value)
    {
    }
}