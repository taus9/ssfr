namespace SSFR;

public readonly struct FileTime(uint lowDateTime, uint highDateTime)
{
    public readonly uint LowDateTime { get; init; } = lowDateTime;
    public readonly uint HighDateTime { get; init; } = highDateTime;
}