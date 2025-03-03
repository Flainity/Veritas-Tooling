using System.Collections.ObjectModel;
using ShineData.Shine.Cryptography;
using ShineData.Shine.Factory;
using ShineData.Shine.Files;
using ShineData.Shine.IO;

namespace ShineData.Shine;

public class ShineClass
{
    private static byte[] _securityHeader;
    private static uint _dataHeader;
    private static byte[] _fileData;
    private static uint _recordCount;
    private static uint _columnCount;
    private static uint _defaultRecordLength;

    public static BaseShineFile<TEntry> Load<T, TEntry>(string fileName) where T : BaseShineFile<TEntry>, new() where TEntry : new()
    {
        var serverPath = @"C:\Veritas\9Data\Shine\";
        var fields = typeof(TEntry).GetProperties();
        var factoryFile = ShineFactory.Create<T, TEntry>();
        var list = new List<TEntry>();

        serverPath += fileName;
        factoryFile.FilePath = serverPath;

        using (var file = File.OpenRead(serverPath))
        using (var fileReader = new BinaryReader(file))
        {
            _securityHeader = fileReader.ReadBytes(32);
            factoryFile.SecurityHeader = _securityHeader;
            _fileData = fileReader.ReadBytes(fileReader.ReadInt32() - 36);

            Encryptor.Encrypt(_fileData, 0, _fileData.Length);
        }
        
        using (var stream = new MemoryStream(_fileData))
        using (var reader = new ShineBinaryReader(stream))
        {
            _dataHeader = reader.ReadUInt32();
            _recordCount = reader.ReadUInt32();
            _defaultRecordLength = reader.ReadUInt32();
            _columnCount = reader.ReadUInt32();

            factoryFile.DataHeader = _dataHeader;
            factoryFile.DefaultRecordLength = _defaultRecordLength;
            factoryFile.ColumnCount = _columnCount;
            
            if (_columnCount != fields.Length)
            {
                throw new ArgumentException("Column count mismatch.");
            }
            
            var tempColumns = new List<ShineColumn>();
            var recordLength = 2;

            for (var i = 0; i < _columnCount; i++)
            {
                var name = reader.ReadString(48);
                var columnType = reader.ReadUInt32();
                var size = reader.ReadInt32();

                var column = new ShineColumn(name, columnType, size);
                
                tempColumns.Add(column);
                factoryFile.Columns.Add(column);

                recordLength += size;
            }

            if (recordLength != _defaultRecordLength)
            {
                throw new ArgumentException("Record length mismatch.");
            }

            for (uint i = 0; i < _recordCount; i++)
            {
                var parameters = new List<object>();
                var rowLength = reader.ReadUInt16();

                for (var x = 0; x < _columnCount; x++)
                {
                    var field = fields[x];
                    var type = field.PropertyType;
                    var column = tempColumns[x];

                    if (type.IsEnum)
                    {
                        type = Enum.GetUnderlyingType(type);
                    }

                    parameters.Add(ReadCell(reader, column, rowLength));
                }

                var entry = (TEntry) Activator.CreateInstance(typeof(TEntry), parameters.ToArray());
                list.Add(entry);
            }
        }

        factoryFile.Records = new ObservableCollection<TEntry>(list);
        return factoryFile;
    }
    
    public static Task<BaseShineFile<TEntry>> LoadAsync<T, TEntry>(string fileName) where T : BaseShineFile<TEntry>, new() where TEntry : new()
    {
        return Task.Run(() => Load<T, TEntry>(fileName));
    }

    private static object ReadCell(ShineBinaryReader reader, ShineColumn column, ushort rowLength)
    {
        switch (column.ColumnType.TypeId)
        {
            case 1:
            case 12:
            case 16:
                return reader.ReadByte();
            case 2:
                return reader.ReadUInt16();
            case 3:
            case 11:
            case 18:
            case 27:
                return reader.ReadUInt32();
            case 5:
                return reader.ReadSingle();
            case 9:
            case 24:
                return reader.ReadString(column.Length);
            case 13:
            case 21:
                return reader.ReadInt16();
            case 20:
                return reader.ReadSByte();
            case 22:
                return reader.ReadInt32();
            case 26:
                return reader.ReadString(rowLength - (int) _defaultRecordLength + 1);
            case 29:
                var bytes = reader.ReadBytes(column.Length);

                var val1 = BitConverter.ToUInt32(bytes, 0);
                var val2 = BitConverter.ToUInt32(bytes, 4);

                return new Tuple<uint, uint>(val1, val2);
            default:
                throw new Exception("Unknown column type.");
        }
    }
}