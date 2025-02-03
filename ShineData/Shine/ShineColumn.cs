using System.Data;

namespace ShineData.Shine;

public class ShineColumn : DataColumn
{
    public ShineColumnType ColumnType { get; set; }
    public int Length { get; set; }
    
    public ShineColumn(string columnName, uint type, int length) : base(columnName)
    {
        ColumnType = new ShineColumnType(type);
        DataType = ColumnType.DataType;
        Length = length;
    }
}