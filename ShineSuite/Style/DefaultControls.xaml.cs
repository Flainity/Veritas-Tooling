using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShineSuite.Style;

public partial class DefaultControls : ResourceDictionary
{
    public DefaultControls()
    {
        InitializeComponent();
    }

    public void ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is ComboBox comboBox)
        {
            if (!comboBox.IsDropDownOpen)
            {
                comboBox.IsDropDownOpen = true;
                e.Handled = true;
            }
        }
    }
}