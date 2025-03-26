using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShineData.Shine.Files;
using ShineSuite.Common.Manager;
using ShineSuite.Module.Abstate.Message;
using Path = System.IO.Path;

namespace ShineSuite.Module.Abstate.ViewModel;

public partial class AbstateGeneralModel : ObservableObject, IRecipient<SelectedAbstateChangedMessage>
{
    public ObservableCollection<string> EffectTypeOptions { get; } = new() { "BUFF", "DEBUFF" };
    
    private BaseShineFile<AbStateEntry> AbStates => ShineFileManager.Instance.AbState;
    private BaseShineFile<AbstateMemoryEntry> AbstateMemories => ShineFileManager.Instance.AbstateMemory;
    private BaseShineFile<SubAbStateEntry> SubAbStates => ShineFileManager.Instance.SubAbState;

    public readonly int IconSize = 16;
    public readonly int IconColumns = 8;
    
    [ObservableProperty] private AbStateEntry? _selectedAbState;
    [ObservableProperty] private AbstateMemoryEntry? _selectedAbstateMemory;
    [ObservableProperty] private ObservableCollection<SubAbStateEntry>? _selectedSubAbState;
    [ObservableProperty] private AbStateViewEntry? _selectedAbstateView;

    [ObservableProperty] private bool _isAbstateMemoryVisible;
    [ObservableProperty] private bool _isSubAbStateVisible;
    [ObservableProperty] private bool _isAbstateBuff;
    [ObservableProperty] private bool _hasAbstateNoMainState;
    [ObservableProperty] private bool _hasAbstateMainState;
    
    [ObservableProperty] private BitmapImage? _icon;
    [ObservableProperty] private BitmapSource? _selectedIcon;
    [ObservableProperty] private VisualBrush? _iconOverlay;
    [ObservableProperty] private int _iconOverlayX;
    [ObservableProperty] private int _iconOverlayY;

    [ObservableProperty] private List<string> _iconFiles;

    public AbstateGeneralModel()
    {
        WeakReferenceMessenger.Default.Register(this);

        const string iconsPath = @"C:\Veritas\9Data\Shine\Graphics\Icons";
        
        if (Directory.Exists(iconsPath))
        {
            IconFiles = Directory.GetFiles(iconsPath, "*.png").Select(Path.GetFileNameWithoutExtension).ToList();
        }
    }

    public void Receive(SelectedAbstateChangedMessage message)
    {
        SelectedAbState = message.Value;
        HasAbstateNoMainState = SelectedAbState.MainStateInx == "-";
        HasAbstateMainState = !HasAbstateNoMainState;

        var abstateMemory = AbstateMemories.Records.FirstOrDefault(x => x.AbstateIndex == (uint) message.Value.AbstateIndex);
        
        if (abstateMemory != null)
        {
            SelectedAbstateMemory = abstateMemory;
            IsAbstateMemoryVisible = true;
        }
        else
        {
            SelectedAbstateMemory = null;
            IsAbstateMemoryVisible = false;
        }
        
        var subAbState = new ObservableCollection<SubAbStateEntry>(SubAbStates.Records.Where(x => x.InxName == message.Value.SubAbstate).ToList());
        
        if (subAbState.Count > 0)
        {
            SelectedSubAbState = subAbState;
            IsSubAbStateVisible = true;
        }
        
        var abstateView = ShineFileManager.Instance.AbStateView.Records.FirstOrDefault(x => x.InxName == message.Value.InxName);
        
        if (abstateView != null)
        {
            SelectedAbstateView = abstateView;
            IsAbstateBuff = abstateView.IconSort == "BUFF";
            LoadIcon(abstateView.IconFile);
        }
    }

    [RelayCommand]
    private void AddNewSubAbstate()
    {
        if (SelectedSubAbState == null)
        {
            return;
        }

        var lastItem = SelectedSubAbState.Last();
        var newItem = new SubAbStateEntry
        {
            Id = (ushort) (SubAbStates.Records.OrderBy(x => x.Id).LastOrDefault()?.Id + 1 ?? 1),
            InxName = lastItem.InxName,
            Strength = lastItem.Strength + 1,
            Type = lastItem.Type,
            SubType = lastItem.SubType,
            KeepTime = lastItem.KeepTime,
            ActionIndex01 = lastItem.ActionIndex01,
            ActionArg01 = lastItem.ActionArg01,
            ActionIndex02 = lastItem.ActionIndex02,
            ActionArg02 = lastItem.ActionArg02,
            ActionIndex03 = lastItem.ActionIndex03,
            ActionArg03 = lastItem.ActionArg03,
            ActionIndex04 = lastItem.ActionIndex04,
            ActionArg04 = lastItem.ActionArg04
        };
        
        SelectedSubAbState.Add(newItem);
        SubAbStates.Records.Add(newItem);
    }

    [RelayCommand]
    private void SaveAbstates()
    {
        ShineFileManager.Instance.AbState.Save();
        ShineFileManager.Instance.AbstateMemory.Save();
        ShineFileManager.Instance.SubAbState.Save();
        ShineFileManager.Instance.AbStateView.Save();
    }
    
    public void UpdateOverlayPosition()
    {
        IconOverlayX = (int)(SelectedAbstateView.Icon % IconColumns) * IconSize;
        IconOverlayY = (int)(SelectedAbstateView.Icon / IconColumns) * IconSize;
    }
    
    public void UpdateSelectedIcon()
    {
        if (SelectedAbstateView == null)
        {
            SelectedIcon = null;
            return;
        }

        var croppedBitmap = new CroppedBitmap(Icon, new Int32Rect(IconOverlayX, IconOverlayY, IconSize, IconSize));
        SelectedIcon = croppedBitmap;
    }
    
    private void LoadIcon(string path)
    {
        path = Path.Combine(@"C:\Veritas\9Data\Shine\Graphics\Icons\", $"{path}.png");
        
        if (string.IsNullOrEmpty(path) || !File.Exists(path))
        {
            Icon = null;
            IconOverlay = null;
            SelectedIcon = null;
            return;
        }

        try
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.EndInit();
            bitmap.Freeze();

            Icon = bitmap;

            IconOverlayX = (int)(SelectedAbstateView.Icon % IconColumns) * IconSize;
            IconOverlayY = (int)(SelectedAbstateView.Icon / IconColumns) * IconSize;
            
            CroppedBitmap croppedBitmap = new(bitmap, new Int32Rect(IconOverlayX, IconOverlayY, IconSize, IconSize));
            SelectedIcon = croppedBitmap;

            var overlayRect = new Rectangle
            {
                Width = IconSize,
                Height = IconSize,
                Fill = new SolidColorBrush(Colors.Red)
            };

            IconOverlay = new VisualBrush(overlayRect);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden der DDS-Datei: {ex.Message}");
            Icon = null;
        }
    }
}