using System.Windows.Controls;
using ShineSuite.Module.Action.ViewModel;

namespace ShineSuite.Module.Action.View;

public partial class ActionEditorView : UserControl
{
    public ActionEditorView(ActionEditorModel model)
    {
        InitializeComponent();
        
        DataContext = model;
    }
}