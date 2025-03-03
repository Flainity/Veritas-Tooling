using System.Windows.Controls;
using ShineSuite.Module.Action.ViewModel;

namespace ShineSuite.Module.Action.View;

public partial class ActionListView : UserControl
{
    public ActionListView(ActionListModel model)
    {
        InitializeComponent();
        
        DataContext = model;
    }
}