using System.Windows;
using System.Windows.Controls;

namespace ShineSuite.Module.Action.Template;

public class ActionPairTemplateSelector : DataTemplateSelector
{
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (container is FrameworkElement element)
        {
            return element.FindResource("ActionPairTemplate") as DataTemplate;
        }
        return base.SelectTemplate(item, container);
    }
}