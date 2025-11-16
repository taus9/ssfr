namespace SSFR;

public readonly struct Header
{
    public uint Version { get; init; }
    public uint SaveNumber { get; init; }
    public string PlayerName { get; init; }
    public uint PlayerLevel { get; init; }
    public string PlayerLocation { get; init; }
    public string GameDate { get; init; }
    public string PlayerRaceEditorID { get; init; }
    public ushort PlayerSex { get; init; }
    public float PlayerCurrentExp { get; init; }
    public float PlayerLevelUpExp { get; init; }
    public FileTime FileTime { get; init; }
    public uint ShotWidth { get; init; }
    public uint ShotHeight { get; init; }
    public ushort CompressionType { get; init; }

    public Header(BinaryReader reader)
    {
        Version = reader.ReadUInt32();
        if (Version < 7 && Version > 9 && Version != 12)
            throw new Exception("Not a supported verison");

        SaveNumber = reader.ReadUInt32();
        PlayerName = reader.ReadWString();
        PlayerLevel = reader.ReadUInt32();
        PlayerLocation = reader.ReadWString();
        GameDate = reader.ReadWString();
        PlayerRaceEditorID = reader.ReadWString();
        PlayerSex = reader.ReadUInt16();
        PlayerCurrentExp = reader.ReadSingle();
        PlayerLevelUpExp = reader.ReadSingle();
        FileTime = reader.ReadFileTime();
        ShotWidth = reader.ReadUInt32();
        ShotHeight = reader.ReadUInt32();
        CompressionType = Version == 12 ? reader.ReadUInt16() : (ushort)0;
    }
}