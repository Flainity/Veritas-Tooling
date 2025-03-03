using System.Windows;
using System.Windows.Controls;

namespace ShineSuite.Module.Abstate.Helper;

public static class GridHelper
{
    public static double GetSpacing(DependencyObject obj) => (double)obj.GetValue(SpacingProperty);
    public static void SetSpacing(DependencyObject obj, double value) => obj.SetValue(SpacingProperty, value);

    public static readonly DependencyProperty SpacingProperty =
        DependencyProperty.RegisterAttached("Spacing", typeof(double), typeof(GridHelper), new PropertyMetadata(0.0, OnSpacingChanged));

    private static void OnSpacingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Grid grid)
            grid.Loaded += (_, _) => ApplySpacing(grid, (double)e.NewValue);
    }

    private static void ApplySpacing(Grid grid, double spacing)
    {
        int columnCount = grid.ColumnDefinitions.Count;
        int rowCount = grid.RowDefinitions.Count;

        // Falls horizontale Spalten existieren
        for (int i = 0; i < columnCount - 1; i++)
            grid.ColumnDefinitions[i].Width = new GridLength(1, GridUnitType.Star);

        // Falls vertikale Zeilen existieren
        for (int i = 0; i < rowCount - 1; i++)
            grid.RowDefinitions[i].Height = new GridLength(1, GridUnitType.Star);

        // Setze Margin für alle Kinder im Grid
        foreach (UIElement child in grid.Children)
        {
            if (child is FrameworkElement element)
                element.Margin = new Thickness(0, 0, spacing, spacing);
        }
    }
}