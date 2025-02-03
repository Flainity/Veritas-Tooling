using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Questy.Message;
using ShineData.Shine.Structure.Quest;

namespace Questy.ViewModel;

public partial class QuestGeneralViewModel : ObservableObject, IRecipient<QuestSelectionChangedMessage>
{
    [ObservableProperty] private Quest? _selectedQuest;

    public QuestGeneralViewModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }

    public void Receive(QuestSelectionChangedMessage message)
    {
        SelectedQuest = message.Value;
    }
}