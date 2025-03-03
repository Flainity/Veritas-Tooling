using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Skill.Helper;
using ShineSuite.Module.Skill.Message;

namespace ShineSuite.Module.Skill.ViewModel;

public partial class ActiveSkillGeneralViewModel : ObservableObject, IRecipient<SelectedSkillChangedMessage>
{
    public ObservableCollection<ActiveSkillEntry> AssociatedActiveSkills = new();
    public ObservableCollection<ActiveSkillInfoServerEntry> AssociatedActiveSkillInfoServer = new();
    public ObservableCollection<ActiveSkillViewEntry> AssociatedActiveSkillView = new();
    
    [ObservableProperty] private ActiveSkillEntry? _selectedActiveSkill;
    [ObservableProperty] private ObservableCollection<ActiveSkillStepModel> _activeSkillSteps = new();
    [ObservableProperty] private ActiveSkillStepModel? _selectedActiveSkillStep;
    
    [ObservableProperty] private string _indexName = null!;
    [ObservableProperty] private string _skillName = null!;
    [ObservableProperty] private string _rawDescription = null!;
    [ObservableProperty] private ushort _swingTime;
    [ObservableProperty] private ushort _hitTime;
    
    public ActiveSkillGeneralViewModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }
    
    // TODO: For the description, use placeholders to insert different variables automatically
    // ? This skill deals [{minDamage}-{maxDamage}] Damage to [{targetNumber}] Targets
    // ? This skill deals [1000-2000] Damage to [5] Targets
    public void Receive(SelectedSkillChangedMessage message)
    {
        SelectedActiveSkill = message.Value;
        
        AssociatedActiveSkills.Clear();
        AssociatedActiveSkillInfoServer.Clear();
        AssociatedActiveSkillView.Clear();
        ActiveSkillSteps.Clear();
        
        SkillName = SelectedActiveSkill.Name[..^5];
        IndexName = SelectedActiveSkill.InxName[..^2];

        AssociatedActiveSkills = new ObservableCollection<ActiveSkillEntry>(
            ShineFileManager.Instance.ActiveSkill.Records
                .Where(x => x.InxName.StartsWith(SelectedActiveSkill.InxName.Substring(0, SelectedActiveSkill.InxName.Length - 2)) 
                            && x.InxName.Length == SelectedActiveSkill.InxName.Length) // Prüft die exakte Länge
                .ToList());
        AssociatedActiveSkillInfoServer = new ObservableCollection<ActiveSkillInfoServerEntry>(
            ShineFileManager.Instance.ActiveSkillInfoServer.Records
                .Where(x => x.InxName.StartsWith(SelectedActiveSkill.InxName.Substring(0, SelectedActiveSkill.InxName.Length - 2)) 
                            && x.InxName.Length == SelectedActiveSkill.InxName.Length) // Prüft die exakte Länge
                .ToList());
        AssociatedActiveSkillView = new ObservableCollection<ActiveSkillViewEntry>(
            ShineFileManager.Instance.ActiveSkillView.Records
                .Where(x => x.InxName.StartsWith(SelectedActiveSkill.InxName.Substring(0, SelectedActiveSkill.InxName.Length - 2)) 
                            && x.InxName.Length == SelectedActiveSkill.InxName.Length) // Prüft die exakte Länge
                .ToList());
        
        SwingTime = AssociatedActiveSkillInfoServer.Select(x => x.SwingTime).FirstOrDefault();
        HitTime = AssociatedActiveSkillInfoServer.Select(x => x.HitTime).FirstOrDefault();
        RawDescription = AssociatedActiveSkillView.Select(x => x.RawDescription).FirstOrDefault();
        
        foreach (var skill in AssociatedActiveSkills)
        {
            ActiveSkillSteps.Add(new ActiveSkillStepModel(skill));
        }
        
        SelectedActiveSkillStep = ActiveSkillSteps.FirstOrDefault();
    }

    partial void OnSkillNameChanged(string value)
    {
        foreach (var skills in AssociatedActiveSkills)
        {
            skills.Name = value + " [" + skills.Step.ToString("D2") + "]";
        }
    }

    partial void OnIndexNameChanged(string value)
    {
        foreach (var skills in AssociatedActiveSkills)
        {
            skills.InxName = value + skills.InxName[^2..];
        }
        
        foreach (var skills in AssociatedActiveSkillInfoServer)
        {
            skills.InxName = value + skills.InxName[^2..];
        }
        
        foreach (var skills in AssociatedActiveSkillView)
        {
            skills.InxName = value + skills.InxName[^2..];
        }
    }

    partial void OnSwingTimeChanged(ushort value)
    {
        foreach (var skill in AssociatedActiveSkillInfoServer)
        {
            skill.SwingTime = value;
        }
    }

    partial void OnHitTimeChanged(ushort value)
    {
        foreach (var skill in AssociatedActiveSkillInfoServer)
        {
            skill.HitTime = value;
        }
    }

    partial void OnRawDescriptionChanged(string value)
    {
        if (value == "-")
        {
            return;
        }
        
        foreach (var skill in AssociatedActiveSkillView)
        {
            var activeSkill = AssociatedActiveSkills.FirstOrDefault(x => x.InxName == skill.InxName);
            var activeSkillServer  = AssociatedActiveSkillInfoServer.FirstOrDefault(x => x.InxName == skill.InxName);
            var description = DescriptionVariableHelper.ReplaceVariables(value, activeSkill, activeSkillServer, skill);

            if (description.Length > 256)
            {
                MessageBox.Show($"Description is too long. The maximum length is 256, but your description for {skill.InxName} is {description.Length} already.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            skill.RawDescription = value;
            skill.Description = description;
        }
    }

    [RelayCommand]
    private void SaveSkills()
    {
        ShineFileManager.Instance.ActiveSkillView.Save();
    }
}