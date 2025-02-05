using System.Data;
using System.Text.RegularExpressions;

namespace ShineData.Text.IO;

internal partial class TextFileReader
{
    public readonly List<string> ColumnTypes = new();
    
    private readonly string[] _lines;

    public TextFileReader(string path)
    {
        _lines = File.ReadAllLines(path);
    }
    
    public DataSet ReadFile()
    {
        return ParseFile();
    }

    public Task<DataSet> ReadFileAsync()
    {
        return Task.Factory.StartNew(ParseFile);
    }

    private DataSet ParseFile()
    {
        var dataSet = new DataSet();
            
        foreach (var line in _lines)
        {
            var str = HeaderRegex().Replace(line, "\t");
            var arguments = str.Split('\t');

            switch (arguments[0].ToLower())
            {
                case "#table":
                    var table = new DataTable(arguments[1]);
                    dataSet.Tables.Add(table);
                    break;

                case "#columntype":
                    ColumnTypes.Add(string.Join("\t", arguments.Skip(1)));
                    break;

                case "#columnname":
                    foreach (var arg in arguments.Skip(1))
                    {
                        dataSet.Tables.Cast<DataTable>().Last().Columns.Add(new DataColumn(arg));
                    }
                    break;

                case "#record":
                    var row = dataSet.Tables.Cast<DataTable>().Last().NewRow();
                    row.ItemArray = arguments.Skip(1).ToArray();
                    dataSet.Tables.Cast<DataTable>().Last().Rows.Add(row);
                    break;
            }
        }
            
        return dataSet;
    }

    [GeneratedRegex("\t+")]
    private static partial Regex HeaderRegex();
}