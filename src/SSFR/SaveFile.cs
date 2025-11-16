using System.Text;

namespace SSFR;

public class SaveFile
{
    private readonly byte[] _magic = Encoding.ASCII.GetBytes("TESV_SAVEGAME");

    public uint HeaderSize { get; private set; }
    public Header Header { get; private set; }

    public byte[]? ScreenshotData { get; private set; }

    public void LoadFile(string filePath)
    {
        using var stream = File.OpenRead(filePath);
        using var reader = new BinaryReader(stream);
        
        byte[] magic = reader.ReadBytes(_magic.Length);
        if (!_magic.SequenceEqual(magic))
        {
            throw new Exception("Invalid file format");
        }

        HeaderSize = reader.ReadUInt32();
        Header = new(reader);

        if (IsHeaderCorrupt())
           throw new Exception("Header is corrupt");

        uint ssDataLength = Header.Version == 12 ?
            4 * Header.ShotWidth * Header.ShotHeight :
            3 * Header.ShotWidth * Header.ShotHeight ;

        ScreenshotData = reader.ReadBytes((int)ssDataLength); 
    }

    private bool IsHeaderCorrupt()
    {
        int baseSize = Header.Version == 12 ? 48 : 46;
        int stringSize = 
            Header.PlayerName.Length + 
            Header.PlayerLocation.Length +
            Header.GameDate.Length +
            Header.PlayerRaceEditorID.Length;

        if ((baseSize + stringSize) != HeaderSize)
            return true;
        else
            return false;
    }

}
