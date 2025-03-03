using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using iNKORE.UI.WPF.Modern.Controls;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Abstate.ViewModel;

namespace ShineSuite.Module.Abstate.View;

public partial class AbstateGeneralView : UserControl
{
    private readonly AbstateGeneralModel _model;
    private CancellationTokenSource _debounceCts;
    
    public AbstateGeneralView(AbstateGeneralModel model)
    {
        InitializeComponent();

        _model = model;
        DataContext = model;
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var test = 1;
    }

    private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var image = sender as Image;
        var position = e.GetPosition(image);
        var clickedColumn = (int)(position.X / _model.IconSize);
        var clickedRow = (int)(position.Y / _model.IconSize);

        _model.SelectedAbstateView.Icon = (uint) (clickedRow * _model.IconColumns + clickedColumn);
        
        _model.UpdateOverlayPosition();
        _model.UpdateSelectedIcon();
    }

    private async void SubabstateSelection_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;
        
        _debounceCts?.Cancel();
        _debounceCts = new CancellationTokenSource();
        
        try
        {
            await Task.Delay(1000, _debounceCts.Token);
            
            var suitableItems = new List<string>();
            var splitText = sender.Text.ToLower().Split(' ');
            var entries = ShineFileManager.Instance.SubAbState.Records;
            
            foreach (var entry in entries)
            {
                var found = splitText.All((key) =>
                {
                    return entry.InxName.ToLower().Contains(key);
                });
                
                if (found)
                {
                    if (suitableItems.Contains(entry.InxName)) continue;
                    
                    suitableItems.Add(entry.InxName);
                }
            }
            
            if (suitableItems.Count == 0)
            {
                suitableItems.Add("No results found");
            }
            
            sender.ItemsSource = suitableItems;
        }
        catch (TaskCanceledException)
        {
            // Ignore cancellations
        }
    }

    private void SubabstateSelection_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (_model.SelectedAbState == null) return;
        
        _model.SelectedAbState.SubAbstate = args.SelectedItem.ToString()!;

        var subAbState = new ObservableCollection<SubAbStateEntry>(ShineFileManager.Instance.SubAbState.Records
            .Where(x => x.InxName == _model.SelectedAbState.SubAbstate).ToList());

        if (subAbState.Count > 0)
        {
            _model.SelectedSubAbState = subAbState;
            _model.IsSubAbStateVisible = true;
        }
    }
}