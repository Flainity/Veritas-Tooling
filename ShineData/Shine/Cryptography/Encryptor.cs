namespace ShineData.Shine.Cryptography;

public class Encryptor
{
    internal static void Encrypt(byte[] data, int startIndex, int length)
    {
        if ((startIndex < 0) | (length < 1) | (startIndex + length > data.Length))
        {
            throw new IndexOutOfRangeException();
        }

        var xorBy = (byte) length;
        for (var i = length - 1; i >= 0; i--)
        {
            data[i] = (byte) (data[i] ^ xorBy);
            var xorByNext = (byte) i;
            xorByNext = (byte) (xorByNext & 15);
            xorByNext = (byte) (xorByNext + 85);
            xorByNext = (byte) (xorByNext ^ (byte) ((byte) i * 11));
            xorByNext = (byte) (xorByNext ^ xorBy);
            xorByNext = (byte) (xorByNext ^ 170);
            xorBy = xorByNext;
        }
    }
}