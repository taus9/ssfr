using System.Text;

namespace SSFR;

public class SaveFile
{
    private readonly byte[] _magic = Encoding.ASCII.GetBytes("TESV_SAVEGAME");

    public uint HeaderSize { get; private set; }

    public void LoadFile(string filePath)
    {
        using var stream = File.OpenRead(filePath);
        using var reader = new BinaryReader(stream);
        
        byte[] magic = reader.ReadBytes(_magic.Length);
        if (magic != _magic)
        {
            throw new Exception("Invalid file format");
        }

        HeaderSize = reader.ReadUInt32();

    }

}
