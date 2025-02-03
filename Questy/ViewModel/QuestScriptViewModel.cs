using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Questy.Message;
using ShineData.Shine.Structure.Quest;

namespace Questy.ViewModel;

public partial class QuestScriptViewModel : ObservableObject, IRecipient<QuestSelectionChangedMessage>
{
    [ObservableProperty] private Quest? _selectedQuest;
    [ObservableProperty] private string? _scriptText;
    
    public QuestScriptViewModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }
    
    public void Receive(QuestSelectionChangedMessage message)
    {
        SelectedQuest = message.Value;
    }
}