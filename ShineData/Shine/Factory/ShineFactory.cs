using ShineData.Shine.Files;

namespace ShineData.Shine.Factory;

public static class ShineFactory<T> where T : IShineFile
{
    public static T Create(params object[] arguments) => (T) Activator.CreateInstance(typeof(T), arguments);
}