using System.Data;
using ShineData.Text.IO;

namespace ShineData.Text;

public class TextFile : IDisposable
{
    public DataSet? DataSet { get; set; }
    
    private string _filePath;
    private List<string> _columnTypes;
    private TextFileReader _reader;
    private TextFileWriter _writer;
    
    public void Dispose()
    {
        DataSet = null;
    }
    
    public TextFile(string filePath)
    {
        _filePath = filePath;
        _columnTypes = new List<string>();
        _reader = new TextFileReader(filePath);
        _writer = new TextFileWriter(filePath);
    }
    
    public DataSet ReadFile()
    {
        try
        {
            DataSet = _reader.ReadFile();
            _columnTypes = _reader.ColumnTypes;
            
            return DataSet;
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to read file: {_filePath}", e);
        }
    }

    public async Task<DataSet> ReadFileAsync()
    {
        try
        {
            DataSet = await _reader.ReadFileAsync();
            _columnTypes = _reader.ColumnTypes;
            
            return DataSet;
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to read file: {_filePath}", e);
        }
    }
}