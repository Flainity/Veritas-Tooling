using System.Data;

namespace ShineData.Text.IO;

public class TextFileWriter
{
    private readonly string _filePath;
    
    public TextFileWriter(string filePath)
    {
        _filePath = filePath;
    }
    
    public void WriteFile(DataTable dataTable, List<string> columnTypes)
    {
        Write(dataTable, columnTypes);
    }
    
    public Task WriteFileAsync(DataTable dataTable, List<string> columnTypes)
    {
        return Task.Factory.StartNew(() =>
        {
            Write(dataTable, columnTypes);
        });
    }

    private void Write(DataTable dataTable, List<string> columnTypes)
    {
        var lines = new List<string>
        {
            "#Ignore\t\\o042",
            "#Exchange\t#\t\\x20",
            "#Delimiter\t\\x20\n",
            "#Table\t" + dataTable.TableName,
            "#ColumnType\t" + string.Join("\t", columnTypes).Trim()
        };

        var columnNames = dataTable.Columns.Cast<DataColumn>().Aggregate("#ColumnName\t", (current, column) => current + column.ColumnName + "\t");
            
        lines.Add(columnNames.Trim());

        lines.AddRange(dataTable.Rows.Cast<DataRow>().Select(row => "#Record\t" + string.Join("\t", row.ItemArray).Trim()));

        lines.Add("#End");

        File.Delete(_filePath);
        File.WriteAllLines(_filePath, lines.ToArray());
    }
}