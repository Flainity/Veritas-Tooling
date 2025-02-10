using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShineSuite.View.Module;

namespace ShineSuite.ViewModel;

public partial class ShineSuiteViewModel : ObservableObject
{
    [ObservableProperty] private object? _currentModule;
    
    [RelayCommand]
    private void LoadAbstateModule()
    {
        CurrentModule = new AbstateModuleView();
    }
}