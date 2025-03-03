namespace ShineData.Shine.Attribute;

public class ShineColumnTypeAttribute : System.Attribute
{
    public uint ColumnType { get; private set; }
    
    public ShineColumnTypeAttribute(uint columnType)
    {
        ColumnType = columnType;
    }
}