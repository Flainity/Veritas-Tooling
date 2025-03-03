using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ShineSuite.ViewModel;

namespace ShineSuite
{
    public partial class ShineSuiteView : Window
    {
        public ShineSuiteView()
        {
            InitializeComponent();

            DataContext = App.ServiceProvider.GetRequiredService<ShineSuiteViewModel>();
        }
    }
}