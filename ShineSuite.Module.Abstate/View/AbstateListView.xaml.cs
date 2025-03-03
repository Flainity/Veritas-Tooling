using System.Windows.Controls;
using ShineSuite.Module.Abstate.ViewModel;

namespace ShineSuite.Module.Abstate.View;

public partial class AbstateListView : UserControl
{
    public AbstateListView(AbstateListModel model)
    {
        InitializeComponent();
        
        DataContext = model;
    }
}