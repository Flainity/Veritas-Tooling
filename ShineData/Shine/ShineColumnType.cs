namespace ShineData.Shine;

public class ShineColumnType
{
    public uint TypeId { get; set; }
    public Type DataType { get; set; }
    
    public ShineColumnType(uint typeId) : this(typeId, GetDataType(typeId)) { }
    
    private ShineColumnType(uint typeId, Type dataType)
    {
        TypeId = typeId;
        DataType = dataType;
    }
    
    private static Type GetDataType(uint typeId)
    {
        return typeId switch
        {
            1 or 12 or 16 => typeof(byte),
            2 => typeof(ushort),
            3 or 11 or 18 or 27 => typeof(uint),
            5 => typeof(float),
            9 or 24 => typeof(string),
            13 or 21 => typeof(short),
            20 => typeof(sbyte),
            22 => typeof(int),
            26 => typeof(string),
            _ => typeof(object)
        };
    }
}