using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Bmp;

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
            throw new Exception("Invalid file format");

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

    public void ExportScreenshot(string path)
    {


        
    }

    private Image<Rgb24> CreateBitmapRGB()
    {
        if (ScreenshotData is null)
            throw new Exception("Screenshot data is null");

        using var image = new Image<Rgb24>((int)Header.ShotWidth, (int)Header.ShotHeight);
        image.ProcessPixelRows(accessor =>
        {
            int offset = 0;
            for (int y = 0; y < Header.ShotHeight; y++)
            {
                Span<Rgb24> row = accessor.GetRowSpan(y);
                for(int x = 0; x < Header.ShotWidth; x++)
                {
                    row[x] = new Rgb24
                    (
                        ScreenshotData[offset + 0],
                        ScreenshotData[offset + 1],
                        ScreenshotData[offset + 2]
                    );
                    offset += 3;
                }
            }
        });
        return image;
    }
}

    private Image<Rgba32> CreateBitmapRGBA()
    {
        if (ScreenshotData is null)
            throw new Exception("Screenshot data is null");

        using var image = new Image<Rgba32>((int)Header.ShotWidth, (int)Header.ShotHeight);
        image.ProcessPixelRows(accessor =>
        {
            int offset = 0;
            for (int y = 0; y < Header.ShotHeight; y++)
            {
                Span<Rgba32> row = accessor.GetRowSpan(y);
                for(int x = 0; x < Header.ShotWidth; x++)
                {
                    row[x] = new Rgba32
                    (
                        ScreenshotData[offset + 0],
                        ScreenshotData[offset + 1],
                        ScreenshotData[offset + 2],
                        ScreenshotData[offset + 3]
                    );
                    offset += 4;
                }
            }
        });
        return image;
    }
}