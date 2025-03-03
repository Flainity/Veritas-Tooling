using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using ShineData.Shine.Attribute;
using ShineData.Shine.Cryptography;
using ShineData.Shine.Extension;
using ShineData.Shine.IO;
using ShineData.Shine.Wrapper;

namespace ShineData.Shine.Files;

public class BaseShineFile<T> : IShineFile
{
    public string FilePath { get; set; }
    public byte[] SecurityHeader;
    public uint DataHeader;
    public uint ColumnCount;
    public uint RecordCount;
    public uint DefaultRecordLength;
    
    public List<ShineColumn> Columns { get; set; } = new();
    public ObservableCollection<T> Records { get; set; } = new();

    public void Save()
    {
        var stream = new MemoryStream();
        using var writer = new ShineBinaryWriter(stream);
        
        writer.Write(DataHeader);
        writer.Write(Records.Count);
        writer.Write(CalculateDefaultRecordLength());
        writer.Write(ColumnCount);

        foreach (var column in Columns)
        {
            if (column.ColumnName.Contains("UnkCol"))
            {
                writer.Write(new byte[0x30]);
            }
            else
            {
                writer.WriteString(column.ColumnName, 0x30);
            }
            
            writer.Write(column.ColumnType.TypeId);
            writer.Write(column.Length);
        }

        foreach (var record in Records)
        {
            var position = writer.BaseStream.Position;
            writer.Write((ushort) 0);

            for (int i = 0; i < Columns.Count; i++)
            {
                var column = Columns[i];
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                var property = properties[i];
                var value = property.GetValue(record);
                
                if (property.PropertyType.IsEnum)
                {
                    var type = Enum.GetUnderlyingType(property.PropertyType);
                    value = Convert.ChangeType(value, type);
                }
                    
                WriteCell(writer, column, value);
            }
            
            var offset = writer.BaseStream.Position;
            var length = offset - position;
            writer.BaseStream.Seek(position, SeekOrigin.Begin);
            writer.Write((ushort) length);
            writer.BaseStream.Seek(offset, SeekOrigin.Begin);
        }
        
        var sourceArray = stream.GetBuffer();
        var destinationArray = new byte[stream.Length];
        Array.Copy(sourceArray, destinationArray, stream.Length);

        Encryptor.Encrypt(destinationArray, 0, destinationArray.Length);

        using var w = new BinaryWriter(File.Create(FilePath));

        w.Write(SecurityHeader.ToArray());
        w.Write(destinationArray.Length + 0x24);
        w.Write(destinationArray);
    }
    
    private void WriteCell(ShineBinaryWriter writer, ShineColumn column, object value)
    {
        switch (column.ColumnType.TypeId)
        {
            case 1:
            case 12:
            case 16:
                if (value is string s) value = byte.Parse(s);
                writer.Write((byte) value);
                break;
            case 2:
                if (value is string s1) value = ushort.Parse(s1);
                writer.Write((ushort) value);
                break;
            case 3:
            case 11:
            case 18:
            case 27:
                if (value is string s2) value = uint.Parse(s2);
                writer.Write((uint) value);
                break;
            case 5:
                if (value is string s3) value = float.Parse(s3);
                writer.Write((float) value);
                break;
            case 9:
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    writer.WriteString(value.ToString(), column.Length);
                }
                else
                {
                    writer.WriteString((string) value, column.Length);
                }

                break;
            case 13:
            case 21:
                if (value is string s4) value = short.Parse(s4);
                writer.Write((short) value);
                break;
            case 20:
                if (value is string s5) value = sbyte.Parse(s5);
                writer.Write((sbyte) value);
                break;
            case 22:
                if (value is string s6) value = int.Parse(s6);
                writer.Write((int) value);
                break;
            case 24:
                writer.WriteString((string) value, column.Length);
                break;
            case 26:
                writer.WriteString((string) value, -1);
                break;
            case 29:
                if (value is ActionTargetWrapper wrapper)
                {
                    value = new Tuple<uint, uint>((uint)wrapper.TargetItem01, wrapper.TargetItem02.Value);
                }

                if (value is ActionActivityWrapper wrapper2)
                {
                    value = new Tuple<uint, uint>((uint)wrapper2.TargetItem01, wrapper2.TargetItem02.Value);
                }
                
                var tuple = (Tuple<uint, uint>) value;
                writer.Write(BitConverter.GetBytes(tuple.Item1));
                writer.Write(BitConverter.GetBytes(tuple.Item2));
                break;
            default:
                throw new Exception("Unknown column type.");
        }
    }
    
    private uint CalculateDefaultRecordLength()
    {
        uint start = 2;
        foreach (ShineColumn col in Columns)
        {
            start += (uint)col.Length;
        }

        return start;
    }
}