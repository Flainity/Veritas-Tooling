using System.Windows.Controls;
using ShineSuite.ViewModel;
using Page = iNKORE.UI.WPF.Modern.Controls.Page;

namespace ShineSuite.View.Module;

public partial class ActionModuleView : iNKORE.UI.WPF.Modern.Controls.Page
{
    public ActionModuleView(ActionModuleModel model)
    {
        InitializeComponent();
        
        DataContext = model;
    }
}