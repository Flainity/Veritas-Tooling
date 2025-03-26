using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using iNKORE.UI.WPF.Modern.Controls;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineData.Shine.Structure.Enum;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Abstate.Message;
using ShineSuite.Module.Abstate.View.ContentDialog;
using ShineSuite.Module.Abstate.Window;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;

namespace ShineSuite.Module.Abstate.ViewModel;

public partial class AbstateListModel : ObservableObject
{
    public BaseShineFile<AbStateEntry> AbnormalState => ShineFileManager.Instance.AbState;
    
    [ObservableProperty] private AbStateEntry? _selectedAbState;
    [ObservableProperty] private string _searchTerm;
    [ObservableProperty] private ICollectionView _filteredAbstates;
    
    private CancellationTokenSource _debounceCts;
    
    public AbstateListModel()
    {
        FilteredAbstates = CollectionViewSource.GetDefaultView(AbnormalState.Records);
        FilteredAbstates.Filter = FilterAbstates;
    }

    partial void OnSelectedAbStateChanged(AbStateEntry? value)
    {
        if (value == null) return;

        WeakReferenceMessenger.Default.Send(new SelectedAbstateChangedMessage(value));
    }

    private bool FilterAbstates(object item)
    {
        if (item is AbStateEntry entry)
        {
            return string.IsNullOrEmpty(SearchTerm) || entry.InxName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase);
        }
        
        return false;
    }

    partial void OnSearchTermChanged(string value)
    {
        _debounceCts?.Cancel();
        _debounceCts = new CancellationTokenSource();

        Task.Delay(1000, _debounceCts.Token).ContinueWith(task =>
        {
            if (!task.IsCanceled)
            {
                Application.Current.Dispatcher.Invoke(() => FilteredAbstates.Refresh());
            }
        });
    }

    [RelayCommand]
    private async void CreateAbstate()
    {
        //var createWindow = new NewAbstateWindow();
        var createWindow = new ContentDialog
        {
            Title = "Create Abstate",
            PrimaryButtonText = "Create",
            SecondaryButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = new CreateAbstateDialog()
        };

        var result = await createWindow.ShowAsync();
        
        if (result == ContentDialogResult.Primary)
        {
            var content = createWindow.Content as CreateAbstateDialog;
            if (AbnormalState.Records.Any(x => x.InxName == content.AbstateName.Text))
            {
                MessageBox.Show("An abstate with that name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            var newAbstateIndex = AbnormalState.Records.OrderBy(x => (uint) x.AbstateIndex).Last().AbstateIndex + 1;
        
            var newAbstate = new AbStateEntry
            {
                Id = (ushort)(AbnormalState.Records.LastOrDefault()!.Id + 1),
                InxName = content.AbstateName.Text,
                AbstateIndex = newAbstateIndex,
                KeepTimeRatio = 1000,
                KeepTimePower = 1,
                AbstateSaveType = AbstateSaveType.AST_NONE,
                DispelAttribute = DispelAttribute.DA_NONE,
                Duplicate = 0,
                MainStateInx = "-",
                SubAbstate = $"Sub{content.AbstateName.Text}",
            };
        
            ShineFileManager.Instance.AbState.Records.Add(newAbstate);
            
            var lastMemoryRecord = ShineFileManager.Instance.AbstateMemory.Records.LastOrDefault();
            if (lastMemoryRecord?.AbstateIndex == (uint)newAbstateIndex)
            {
                var newMemory = new AbstateMemoryEntry
                {
                    AbstateIndex = (uint) newAbstateIndex + 1,
                    AbstateMemoryStruct = AbstateMemoryStruct.AMS_ELEMENT_NORMAL,
                    SubAbstateAction = 0
                };
        
                ShineFileManager.Instance.AbstateMemory.Records.Add(newMemory);
            }

            var newSubAbstate = new SubAbStateEntry
            {
                Id = (ushort)(ShineFileManager.Instance.SubAbState.Records.LastOrDefault()!.Id + 1),
                InxName = $"Sub{content.AbstateName.Text}",
                Strength = 1,
                Type = SubState.SUBAB_DEFAULT,
                SubType = 1,
                KeepTime = 1000,
                ActionIndex01 = SubAbstateAction.SAA_NONE,
                ActionArg01 = 0,
                ActionIndex02 = SubAbstateAction.SAA_NONE,
                ActionArg02 = 0,
                ActionIndex03 = SubAbstateAction.SAA_NONE,
                ActionArg03 = 0,
                ActionIndex04 = SubAbstateAction.SAA_NONE,
                ActionArg04 = 0,
            };
        
            ShineFileManager.Instance.SubAbState.Records.Add(newSubAbstate);

            var newAbstateView = new AbStateViewEntry
            {
                Id = (ushort) (ShineFileManager.Instance.AbStateView.Records.LastOrDefault().Id + 1),
                InxName = content.AbstateName.Text,
                Icon = 0,
                IconFile = "AbState00",
                Description = "A magical effect!",
                Red = 0,
                Green = 0,
                Blue = 0,
                AnimationIndex = "-",
                EffectName = "-",
                EffectNamePosition = EffectPosition.EP_NONE,
                EffectRefresh = 0,
                LoopEffect = "-",
                LoopEffectPosition = EffectPosition.EP_NONE,
                LastEffect = "-",
                LastEffectPosition = EffectPosition.EP_NONE,
                DamageOverTimeEffect = "-",
                DamageOverTimeEffectPosition = EffectPosition.EP_NONE,
                IconSort = "DEBUFF",
                TypeSort = StateType.ST_NORMAL,
                View = 1
            };
            
            ShineFileManager.Instance.AbStateView.Records.Add(newAbstateView);
        }
    }
}