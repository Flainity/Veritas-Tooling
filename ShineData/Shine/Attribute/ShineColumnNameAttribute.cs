namespace ShineData.Shine.Attribute;

public class ShineColumnNameAttribute : System.Attribute
{
    public string Name { get; private set; }
    
    public ShineColumnNameAttribute(string name)
    {
        Name = name;
    }
}