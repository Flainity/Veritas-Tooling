using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ShineSuite.ViewModel;

namespace ShineSuite.View.Startup;

public partial class StartupWindow : Window
{
    public StartupWindow(StartupWindowModel model)
    {
        InitializeComponent();
        
        DataContext = model;
        
        model.ShineFilesLoaded += (sender, args) =>
        {
            Dispatcher.Invoke(() =>
            {
                var mainWindow = App.ServiceProvider.GetRequiredService<ShineSuiteView>();
                mainWindow.Show();
                Close();
            });
        };
    }
}