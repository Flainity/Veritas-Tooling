using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using iNKORE.UI.WPF.Modern.Controls;
using Microsoft.Extensions.DependencyInjection;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;
using ShineSuite.Factory.Abstate;
using ShineSuite.View.Module;
using ShineSuite.View.Page;

namespace ShineSuite.ViewModel;

public partial class ShineSuiteViewModel : ObservableObject
{
    [ObservableProperty] private object? _currentModule;
    [ObservableProperty] private NavigationViewItem? _selectedPage;

    public ShineSuiteViewModel()
    {
        CurrentModule = new WelcomeModuleView();
    }

    public void NavigateTo<TPage>() where TPage : Page
    {
        CurrentModule = App.ServiceProvider.GetService(typeof(TPage)) as Page;
    }

    partial void OnSelectedPageChanged(NavigationViewItem? value)
    {
        if (value == null) return;

        switch (value.Content)
        {
            case "Abstate Module":
                NavigateTo<AbstateModuleView>();
                break;
            case "Action Module":
                NavigateTo<ActionModuleView>();
                break;
            case "Skill Module":
                NavigateTo<SkillModuleView>();
                break;
            default:
                return;
        }
    }

    [RelayCommand]
    private void LoadAbstateModule()
    {
        CurrentModule = App.ServiceProvider.GetRequiredService<AbstateModuleView>();
    }

    [RelayCommand]
    private void LoadActionModule()
    {
        CurrentModule = App.ServiceProvider.GetRequiredService<ActionModuleView>();
    }
    
    [RelayCommand]
    private void LoadSkillModule()
    {
        CurrentModule = new SkillModuleView();
    }
}