using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using ShineSuite.Module.Abstate.View;

namespace ShineSuite.ViewModel;

public partial class AbstateModuleModel : ObservableObject
{
    [ObservableProperty] private UserControl? _listView;
    [ObservableProperty] private UserControl? _detailView;
    
    public AbstateModuleModel()
    {
        ListView = App.ServiceProvider.GetRequiredService<AbstateListView>();
        DetailView = App.ServiceProvider.GetRequiredService<AbstateGeneralView>();
    }
}