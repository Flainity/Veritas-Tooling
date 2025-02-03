namespace ShineData.Shine.Service;

public class ShineHandlerService : IShineHandlerService
{
    public ShineFile Load(string path)
    {
        return new ShineFile(path);
    }
}