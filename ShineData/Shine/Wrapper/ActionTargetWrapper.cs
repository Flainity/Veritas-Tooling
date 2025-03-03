using System.ComponentModel;
using ShineData.Shine.Structure.Enum.Action;

namespace ShineData.Shine.Wrapper;

public class ActionTargetWrapper : INotifyPropertyChanged
{
    private ActionTargetType _targetItem01;
    private ITargetType _targetItem02;

    public ActionTargetType TargetItem01
    {
        get { return _targetItem01; }
        set
        {
            if (_targetItem01 != value)
            {
                _targetItem01 = value;
                OnPropertyChanged(nameof(TargetItem01));
            }
        }
    }

    public ITargetType TargetItem02
    {
        get { return _targetItem02; }
        set
        {
            if (_targetItem02 != value)
            {
                _targetItem02 = value;
                OnPropertyChanged(nameof(TargetItem02));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}