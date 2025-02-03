using System.Text;

namespace ShineData.Shine.Extension;

public static class BinaryWriterExtension
{
    public static void Write(this BinaryWriter writer, string value, int length)
    {
        var buffer = Encoding.ASCII.GetBytes(value);

        writer.Write(buffer);

        for (var i = 0; i < length - buffer.Length; i++)
        {
            writer.Write((byte) 0);
        }
    }
    
    public static void WriteString(this BinaryWriter writer, string value, int length)
    {
        if (length == -1)
        {
            writer.Write(Encoding.Default.GetBytes(value));
            writer.Write((byte)0);
            return;
        }

        writer.Write(Encoding.Default.GetBytes(value));

        for (var i = value.Length; i < length; i++)
        {
            writer.Write((byte)0x00);
        }
    }
    
    public static void Fill(this BinaryWriter writer, int length)
    {
        for (var i = 0; i < length; i++)
        {
            writer.Write((byte) 0);
        }
    }
}