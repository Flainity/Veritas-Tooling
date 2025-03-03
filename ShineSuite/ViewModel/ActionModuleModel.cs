using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using ShineSuite.Module.Action.View;

namespace ShineSuite.ViewModel;

public partial class ActionModuleModel : ObservableObject
{
    [ObservableProperty] private UserControl? _listView;
    [ObservableProperty] private UserControl? _editorView;
    
    public ActionModuleModel()
    {
        ListView = App.ServiceProvider.GetRequiredService<ActionListView>();
        EditorView = App.ServiceProvider.GetRequiredService<ActionEditorView>();
    }
}