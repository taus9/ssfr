using System.Text;

namespace SSFR;

public static class BinaryReaderExtensions
{
    public static string ReadWString(this BinaryReader reader)
    {
        ushort stringLength = reader.ReadUInt16();
        if (stringLength <= 0)
        {
            return string.Empty;
        }

        byte[] wString = reader.ReadBytes((int)stringLength);
        return Encoding.ASCII.GetString(wString);
    }

    public static FileTime ReadFileTime(this BinaryReader reader)
    {
        uint lowDateTime = reader.ReadUInt32();
        uint highDateTime = reader.ReadUInt32();
        return new(lowDateTime, highDateTime);
    }
}