using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using iNKORE.UI.WPF.Modern;
using Page = iNKORE.UI.WPF.Modern.Controls.Page;

namespace ShineSuite.View.Page;

public partial class SettingsPage : iNKORE.UI.WPF.Modern.Controls.Page
{
    public SettingsPage()
    {
        InitializeComponent();
    }
    
    private void OnThemeRadioButtonChecked(object sender, RoutedEventArgs e)
    {
        var selectTheme = ((RadioButton)sender)?.Tag?.ToString();

        if(selectTheme != null)
        {
            //ThemeHelper.RootTheme = App.GetEnum<ElementTheme>(selectTheme);
        }
    }

    private void OnThemeRadioButtonKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Up)
        {
            //NavigationRootPage.GetForElement(this).PageHeader.Focus();
        }
    }
}