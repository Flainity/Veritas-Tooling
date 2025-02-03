using System;
using System.Collections.ObjectModel;
using ShineData.Shine.Structure.Quest;

namespace Questy.Service;

public class QuestService
{
    private static readonly Lazy<QuestService> _instance = new(() => new QuestService());
    public static QuestService Instance => _instance.Value;

    public ObservableCollection<Quest> QuestList { get; set; } = new();
    public ushort QuestDataHeader { get; set; }

    private QuestService() { }
}