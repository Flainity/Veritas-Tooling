using System.Windows;

namespace ShineSuite.Module.Abstate.Window;

public partial class NewAbstateWindow : System.Windows.Window
{
    public string AbstateName { get; set; }
    
    public NewAbstateWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        AbstateName = AbstateNameTextBox.Text;
        DialogResult = true;
        Close();
    }
}