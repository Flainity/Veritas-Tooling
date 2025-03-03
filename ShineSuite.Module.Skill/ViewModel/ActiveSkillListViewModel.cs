using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineData.Shine.Structure.Enum;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Skill.Message;

namespace ShineSuite.Module.Skill.ViewModel;

public partial class ActiveSkillListViewModel : ObservableObject
{
    public BaseShineFile<ActiveSkillEntry> ActiveSkill => ShineFileManager.Instance.ActiveSkill;
    
    [ObservableProperty] private ObservableCollection<ActiveSkillEntry> _activeSkills;
    [ObservableProperty] private ActiveSkillEntry? _selectedActiveSkill;
    
    public ActiveSkillListViewModel()
    {
        
        
        ActiveSkills = new ObservableCollection<ActiveSkillEntry>(ActiveSkill.Records.Where(x => x.Step == 1 && x.WeaponDemandType != WeaponDemandType.DT_ALL));
    }

    partial void OnSelectedActiveSkillChanged(ActiveSkillEntry? value)
    {
        if (value == null)
        {
            return;
        }

        WeakReferenceMessenger.Default.Send(new SelectedSkillChangedMessage(value));
    }
}