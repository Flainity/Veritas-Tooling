using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Messaging;
using iNKORE.UI.WPF.Modern.Controls;
using ShineData.Shine.Files;
using ShineData.Shine.Structure.Enum;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Abstate.Message;
using ShineSuite.Module.Abstate.ViewModel;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;

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
                var found = splitText.All((key) => entry.InxName.ToLower().Contains(key));

                if (!found) continue;
                
                if (suitableItems.Contains(entry.InxName)) continue;
                    
                suitableItems.Add(entry.InxName);
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
    
    private void PartyState01_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        PartyState_OnTextChanged(sender, args, 1);
    }
    
    private void PartyState02_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        PartyState_OnTextChanged(sender, args, 2);
    }
    
    private void PartyState03_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        PartyState_OnTextChanged(sender, args, 3);
    }
    
    private void PartyState04_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        PartyState_OnTextChanged(sender, args, 4);
    }
    
    private void PartyState05_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        PartyState_OnTextChanged(sender, args, 5);
    }
    
    private async void PartyState_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args, int partyStateIndex)
    {
        if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;

        if (sender.Text == string.Empty)
        {
            var previousSelection = partyStateIndex switch
            {
                1 => _model.SelectedAbState?.PartyState01,
                2 => _model.SelectedAbState?.PartyState02,
                3 => _model.SelectedAbState?.PartyState03,
                4 => _model.SelectedAbState?.PartyState04,
                5 => _model.SelectedAbState?.PartyState05,
                _ => null
            };
            
            var partyAbstate = ShineFileManager.Instance.AbState.Records.FirstOrDefault(x => x.InxName == previousSelection);
            if (partyAbstate != null)
            {
                partyAbstate.MainStateInx = "-";
            }
            
            switch (partyStateIndex)
            {
                case 1:
                    _model.SelectedAbState.PartyState01 = "-";
                    break;
                case 2:
                    _model.SelectedAbState.PartyState02 = "-";
                    break;
                case 3:
                    _model.SelectedAbState.PartyState03 = "-";
                    break;
                case 4:
                    _model.SelectedAbState.PartyState04 = "-";
                    break;
                case 5:
                    _model.SelectedAbState.PartyState05 = "-";
                    break;
            }
            
            var usedPartyStates = new[] { _model.SelectedAbState?.PartyState01, _model.SelectedAbState?.PartyState02, _model.SelectedAbState?.PartyState03, _model.SelectedAbState?.PartyState04, _model.SelectedAbState?.PartyState05 };
            _model.SelectedAbState.PartyEnchantNumber = (uint)usedPartyStates.Count(state => state != "-");
            
            var binding = sender.GetBindingExpression(AutoSuggestBox.TextProperty);
            binding?.UpdateTarget();
            
            return;
        }
        
        _debounceCts?.Cancel();
        _debounceCts = new CancellationTokenSource();
        
        try
        {
            await Task.Delay(1000, _debounceCts.Token);
            
            var suitableItems = new List<string>();
            var splitText = sender.Text.ToLower().Split(' ');
            var entries = ShineFileManager.Instance.AbState.Records;
            
            foreach (var entry in entries)
            {
                var found = splitText.All((key) => entry.InxName.ToLower().Contains(key));

                if (!found) continue;
                
                if (suitableItems.Contains(entry.InxName)) continue;
                    
                suitableItems.Add(entry.InxName);
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

    private void PartyState01_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        PartyStateSuggestionChosen(sender, args, 1);
    }
    
    private void PartyState02_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        PartyStateSuggestionChosen(sender, args, 2);
    }
    
    private void PartyState03_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        PartyStateSuggestionChosen(sender, args, 3);
    }
    
    private void PartyState04_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        PartyStateSuggestionChosen(sender, args, 4);
    }
    
    private void PartyState05_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        PartyStateSuggestionChosen(sender, args, 5);
    }
    
    private void PartyStateSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args, int partyStateIndex)
    {
        var partyAbstateName = args.SelectedItem.ToString()!;
        var newPartyAbstate = ShineFileManager.Instance.AbState.Records.FirstOrDefault(x => x.InxName == partyAbstateName);
        
        var previousSelection = partyStateIndex switch
        {
            1 => _model.SelectedAbState?.PartyState01,
            2 => _model.SelectedAbState?.PartyState02,
            3 => _model.SelectedAbState?.PartyState03,
            4 => _model.SelectedAbState?.PartyState04,
            5 => _model.SelectedAbState?.PartyState05,
            _ => null
        };
        
        if (newPartyAbstate != null)
        {
            var usedPartyStates = new[] { newPartyAbstate.PartyState01, newPartyAbstate.PartyState02, newPartyAbstate.PartyState03, newPartyAbstate.PartyState04, newPartyAbstate.PartyState05 };
            
            if (usedPartyStates.Any(state => state != "-"))
            {
                MessageBox.Show("This Abstate is already used as a main party state. You can not use an already existing main abstate in another abstate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                var binding = sender.GetBindingExpression(AutoSuggestBox.TextProperty);
                binding?.UpdateTarget();
                return;
            }
        }

        if (previousSelection != "-")
        {
            var partyAbstate = ShineFileManager.Instance.AbState.Records.FirstOrDefault(x => x.InxName == previousSelection);
            if (partyAbstate != null)
            {
                partyAbstate.MainStateInx = "-";
            }
        }

        switch (partyStateIndex)
        {
            case 1:
                _model.SelectedAbState.PartyState01 = args.SelectedItem.ToString()!;
                break;
            case 2:
                _model.SelectedAbState.PartyState02 = args.SelectedItem.ToString()!;
                break;
            case 3:
                _model.SelectedAbState.PartyState03 = args.SelectedItem.ToString()!;
                break;
            case 4:
                _model.SelectedAbState.PartyState04 = args.SelectedItem.ToString()!;
                break;
            case 5:
                _model.SelectedAbState.PartyState05 = args.SelectedItem.ToString()!;
                break;
        }
        
        if (newPartyAbstate != null)
        {
            newPartyAbstate.MainStateInx = _model.SelectedAbState.InxName;
            
            var usedPartyStates = new[] { _model.SelectedAbState.PartyState01, _model.SelectedAbState.PartyState02, _model.SelectedAbState.PartyState03, _model.SelectedAbState.PartyState04, _model.SelectedAbState.PartyState05 };
            _model.SelectedAbState.PartyEnchantNumber = (uint)usedPartyStates.Count(state => state != "-");
        }
    }

    private void MainAbstateButton_OnClick(object sender, RoutedEventArgs e)
    {
        var mainAbstate = ShineFileManager.Instance.AbState.Records.FirstOrDefault(x => x.InxName == _model.SelectedAbState.MainStateInx);
        
        if (mainAbstate != null)
        {
            WeakReferenceMessenger.Default.Send(new SelectedAbstateChangedMessage(mainAbstate));
        }
    }

    private void EffectType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;

        switch (comboBox.SelectedValue.ToString())
        {
            case "BUFF":
                _model.SelectedAbstateView.TypeSort = StateType.ST_NORMAL;
                _model.IsAbstateBuff = true;
                break;
            case "DEBUFF":
                _model.SelectedAbstateView.TypeSort = StateType.ST_DEBUFF;
                _model.IsAbstateBuff = false;
                break;
        }
        
        var itemBinding = IconSortComboBox.GetBindingExpression(ComboBox.SelectedItemProperty);
        var enabledBinding = IconSortComboBox.GetBindingExpression(IsEnabledProperty);
        
        itemBinding?.UpdateTarget();
        enabledBinding?.UpdateTarget();
    }

    private async void IconFile_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput) return;
        
        _debounceCts?.Cancel();
        _debounceCts = new CancellationTokenSource();
        
        try
        {
            await Task.Delay(1000, _debounceCts.Token);
            
            var suitableItems = new List<string>();
            var splitText = sender.Text.ToLower().Split(' ');
            var entries = _model.IconFiles;
            
            foreach (var entry in entries)
            {
                var found = splitText.All((key) => entry.ToLower().Contains(key));

                if (!found) continue;
                
                if (suitableItems.Contains(entry)) continue;
                    
                suitableItems.Add(entry);
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

    private void IconFile_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        var fileName = args.SelectedItem.ToString()!;
        
        _model.SelectedAbstateView.IconFile = fileName;
        
        var path = Path.Combine(@"C:\Veritas\9Data\Shine\Graphics\Icons\", $"{fileName}.png");
        
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.UriSource = new Uri(path, UriKind.Absolute);
        bitmap.EndInit();
        bitmap.Freeze();
        
        _model.Icon = bitmap;
        
        var croppedBitmap = new CroppedBitmap(_model.Icon, new Int32Rect(_model.IconOverlayX, _model.IconOverlayY, _model.IconSize, _model.IconSize));
        _model.SelectedIcon = croppedBitmap;
    }
}