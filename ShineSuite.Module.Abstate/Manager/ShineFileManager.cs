using System;
using System.Collections.ObjectModel;
using Cogs.Collections;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Abstate.Manager;

public class ShineFileManager
{
    private static readonly Lazy<ShineFileManager> _instance = new(() => new ShineFileManager());
    public static ShineFileManager Instance => _instance.Value;

    public ObservableCollection<AbState> AbStates { get; set; } = new();
    public ObservableCollection<AbstateMemory> AbstateMemories { get; set; } = new();
    public ObservableCollection<SubAbState> SubAbStates { get; set; } = new();

    private ShineFileManager() { }
}