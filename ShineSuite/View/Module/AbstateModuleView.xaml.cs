using System.Windows.Controls;
using ShineSuite.Module.Abstate.View;
using ShineSuite.ViewModel;
using Page = iNKORE.UI.WPF.Modern.Controls.Page;

namespace ShineSuite.View.Module;

public partial class AbstateModuleView : iNKORE.UI.WPF.Modern.Controls.Page
{
    public AbstateModuleView(AbstateModuleModel model)
    {
        InitializeComponent();
        
        DataContext = model;
    }
}