using ShineData.Shine.Files;

namespace ShineData.Shine.Factory;

public static class ShineFactory
{
    public static BaseShineFile<TEntry> Create<TFile, TEntry>(params object[] arguments)
        where TFile : BaseShineFile<TEntry>
    {
        return (BaseShineFile<TEntry>) Activator.CreateInstance(typeof(TFile), arguments);
    }
    //public static T Create(params object[] arguments) => (T) Activator.CreateInstance(typeof(T), arguments);
}