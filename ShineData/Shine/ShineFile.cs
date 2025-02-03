using System.Data;
using ShineData.Shine.Cryptography;
using ShineData.Shine.IO;
using ShineData.Shine.Extension;

namespace ShineData.Shine;

public class ShineFile : IDisposable
{
    public DataTable Table { get; set; }
    public byte[] ChecksumData { get; set; }
    private byte[] CryptHeader { get; set; }
    private uint DataHeader { get; set; }
    private uint DefaultRowLength { get; set; }

    private readonly string file_name;

    public ShineFile(string path)
    {
        file_name = path;
        Table = new DataTable(Path.GetFileName(path));

        PopulateTable();
    }

    public void Dispose()
    {
        Table.Dispose();
    }

    private void PopulateTable()
    {
        if (!File.Exists(file_name))
        {
            return;
        }

        byte[] buffer;
        ChecksumData = File.ReadAllBytes(file_name);

        using (var file = File.OpenRead(file_name))
        using (var reader = new BinaryReader(file))
        {
            CryptHeader = reader.ReadBytes(32);

            var length = reader.ReadInt32();
            buffer = reader.ReadBytes(length - 0x24);

            Encryptor.Encrypt(buffer, 0, buffer.Length);
        }

        using (var stream = new MemoryStream(buffer))
        using (var reader = new ShineBinaryReader(stream))
        {
            DataHeader = reader.ReadUInt32();

            var rowCount = reader.ReadUInt32();
            DefaultRowLength = reader.ReadUInt32();
            var columnCount = reader.ReadUInt32();

            ReadColumns(reader, columnCount);
            ReadRows(reader, rowCount);
        }
    }

    public void SaveFile()
    {
        var stream = new MemoryStream();
        using var writer = new ShineBinaryWriter(stream);

        writer.Write(DataHeader);
        writer.Write(Table.Rows.Count);
        writer.Write(CalculateDefaultRecordLength());
        writer.Write(Table.Columns.Count);

        foreach (var column in Table.Columns.Cast<ShineColumn>())
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

        foreach (var row in Table.Rows.Cast<DataRow>())
        {
            var position = writer.BaseStream.Position;
            writer.Write((ushort) 0);

            foreach (var column in Table.Columns.Cast<ShineColumn>())
            {
                var value = row.ItemArray[column.Ordinal];
                value ??= "0";

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

        using var w = new BinaryWriter(File.Create(file_name));

        w.Write(CryptHeader.ToArray());
        w.Write(destinationArray.Length + 0x24);
        w.Write(destinationArray);
    }

    private void ReadColumns(ShineBinaryReader reader, uint columnCount)
    {
        var unkColumnCount = 0;

        for (var i = 0; i < columnCount; i++)
        {
            var name = reader.ReadString(48);
            var type = reader.ReadUInt32();
            var length = reader.ReadInt32();

            var column = new ShineColumn(name, type, length);

            if (name.Trim().Length < 2)
            {
                column.ColumnName = $"UnkCol{unkColumnCount++}";
            }

            Table.Columns.Add(column);
        }
    }

    private void ReadRows(ShineBinaryReader reader, uint rowCount)
    {
        for (var i = 0; i < rowCount; i++)
        {
            var row = Table.NewRow();
            var rowLength = reader.ReadUInt16();

            foreach (var column in Table.Columns.Cast<ShineColumn>())
            {
                row[column] = ReadCell(reader, column, rowLength);
            }

            Table.Rows.Add(row);
        }
    }

    private object ReadCell(ShineBinaryReader reader, ShineColumn column, ushort rowLength)
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
                return reader.ReadString(rowLength - (int) DefaultRowLength + 1);
            case 29:
                var bytes = reader.ReadBytes(column.Length);

                var val1 = BitConverter.ToUInt32(bytes, 0);
                var val2 = BitConverter.ToUInt32(bytes, 4);

                return new Tuple<uint, uint>(val1, val2);
            default:
                throw new Exception("Unknown column type.");
        }
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
        foreach (ShineColumn col in Table.Columns)
        {
            start += (uint)col.Length;
        }

        return start;
    }
}