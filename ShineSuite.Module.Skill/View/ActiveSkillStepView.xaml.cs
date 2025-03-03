using System.Windows;
using System.Windows.Controls;
using ShineData.Shine.Files;
using ShineSuite.Module.Skill.ViewModel;

namespace ShineSuite.Module.Skill.View;

public partial class ActiveSkillStepView : UserControl
{
    public ActiveSkillStepView()
    {
        InitializeComponent();
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is ActiveSkillEntry action)
        {
            DataContext = new ActiveSkillStepModel(action);
        }
    }
}