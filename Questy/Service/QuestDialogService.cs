using System;
using System.Collections.ObjectModel;
using Cogs.Collections;
using ShineData.Shine.Structure.Dialog;
using ShineData.Shine.Structure.Quest;

namespace Questy.Service;

public class QuestDialogService
{
    private static readonly Lazy<QuestDialogService> _instance = new(() => new QuestDialogService());
    public static QuestDialogService Instance => _instance.Value;

    public ObservableSortedDictionary<uint, QuestDialog> QuestDialogList { get; set; } = new();

    private QuestDialogService() { }
}