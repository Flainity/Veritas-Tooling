using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Action.Message;

namespace ShineSuite.Module.Action.ViewModel;

public partial class ActionListModel : ObservableObject, IRecipient<ActionsSavedMessage>
{
    public BaseShineFile<ItemActionEffectDescEntry> ItemActionEffectDescription => ShineFileManager.Instance.ItemActionEffectDesc;
    
    [ObservableProperty] private ObservableCollection<ItemActionEffectDescEntry> _itemActionEffectDescriptions;
    [ObservableProperty] private ItemActionEffectDescEntry? _selectedItemAction;

    public ActionListModel()
    {
        WeakReferenceMessenger.Default.Register(this);
        
        
        
        ItemActionEffectDescriptions = new ObservableCollection<ItemActionEffectDescEntry>(ItemActionEffectDescription.Records.GroupBy(x => x.Id).Select(x => x.First()));
    }

    partial void OnSelectedItemActionChanged(ItemActionEffectDescEntry? value)
    {
        if (value == null)
        {
            return;
        }

        WeakReferenceMessenger.Default.Send(new SelectedItemActionChanged(value));
    }

    public void Receive(ActionsSavedMessage message)
    {
        ItemActionEffectDescriptions.Clear();
        ItemActionEffectDescriptions = new ObservableCollection<ItemActionEffectDescEntry>(ShineFileManager.Instance.ItemActionEffectDesc.Records.GroupBy(x => x.Id).Select(x => x.First()));
    }
}