using System.Windows;
using System.Windows.Controls;
using ShineData.Shine.Files;
using ShineSuite.Module.Action.ViewModel;

namespace ShineSuite.Module.Action.View;

public partial class ActionPairView : UserControl
{
    public ActionPairView()
    {
        InitializeComponent();
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is ItemActionEntry action)
        {
            DataContext = new ActionPairModel(action);
        }
    }
}