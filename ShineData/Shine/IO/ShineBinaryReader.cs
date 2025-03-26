using System.Text;

namespace ShineData.Shine.IO;

public class ShineBinaryReader : BinaryReader
{
    public long Length => BaseStream.Length;
    
    public ShineBinaryReader(Stream input) : base(input)
    {
    }

    public string ReadString(int length)
    {
        var ret = string.Empty;
        var offset = 0;
        var buffer = ReadBytes(length);

        while (offset < length && buffer[offset] != 0x00)
        {
            offset++;
        }

        if (length > 0)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            ret = encoding.GetString(buffer, 0, offset);
        }

        return ret;
    }

    public string ReadStringUntilZero()
    {
        var str = "";
        
        while (PeekChar() != 0)
        {
            str += (char)ReadByte();
        }

        return str;
    }
}