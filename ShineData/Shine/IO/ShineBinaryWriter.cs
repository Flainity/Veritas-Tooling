using System.Text;

namespace ShineData.Shine.IO;

public class ShineBinaryWriter : BinaryWriter
{
    public long Length => BaseStream.Length;
    
    public ShineBinaryWriter(Stream output) : base(output)
    {
    }

    public static void Write(string value, int length)
    {
        
    }
}