using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Skill.Provider;

namespace ShineSuite.Module.Skill.ViewModel;

public partial class ActiveSkillStepModel : ObservableObject
{
    public ObservableCollection<AbStateEntry> AbStates => ShineFileManager.Instance.AbState.Records;
    public AbStateEntry? SkillAbstate01 { get; set; }
    public AbStateEntry? SkillAbstate02 { get; set; }
    public AbStateEntry? SkillAbstate03 { get; set; }
    public AbStateEntry? SkillAbstate04 { get; set; }
    
    [ObservableProperty] private ActiveSkillEntry? _activeSkillEntry;
    [ObservableProperty] private ActiveSkillInfoServerEntry? _activeSkillInfoServerEntry;
    [ObservableProperty] private ActiveSkillViewEntry? _activeSkillViewEntry;
    [ObservableProperty] private ObservableCollection<string> _abstateProvider = new();
    
    public ActiveSkillStepModel(ActiveSkillEntry activeSkillEntry)
    {
        ActiveSkillEntry = activeSkillEntry;
        ActiveSkillInfoServerEntry =
            ShineFileManager.Instance.ActiveSkillInfoServer.Records.FirstOrDefault(x =>
                x.InxName == activeSkillEntry.Step.ToString("D2"));
        ActiveSkillViewEntry =
            ShineFileManager.Instance.ActiveSkillView.Records.FirstOrDefault(x =>
                x.InxName == activeSkillEntry.Step.ToString("D2"));
        
        SkillAbstate01 = AbStates.FirstOrDefault(x => x.InxName == ActiveSkillEntry.AbstateName01);
        SkillAbstate02 = AbStates.FirstOrDefault(x => x.InxName == ActiveSkillEntry.AbstateName02);
        SkillAbstate03 = AbStates.FirstOrDefault(x => x.InxName == ActiveSkillEntry.AbstateName03);
        SkillAbstate04 = AbStates.FirstOrDefault(x => x.InxName == ActiveSkillEntry.AbstateName04);

        foreach (var abstate in AbStates)
        {
            AbstateProvider.Add(abstate.InxName);
        }
    }
}