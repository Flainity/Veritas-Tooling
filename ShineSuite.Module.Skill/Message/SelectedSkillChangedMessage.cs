using CommunityToolkit.Mvvm.Messaging.Messages;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Skill.Message;

public class SelectedSkillChangedMessage : ValueChangedMessage<ActiveSkillEntry>
{
    public SelectedSkillChangedMessage(ActiveSkillEntry value) : base(value)
    {
    }
}