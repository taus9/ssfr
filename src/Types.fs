namespace ssfr

type Header = {
    Version: uint32
    SaveNumber: uint32
    PlayerName: string
    PlayerLevel: uint32
    PlayerLocation: string
    GameDate: string
    PlayerRaceEditorID: string
    PlayerSex: uint16
    PlayerCurrentExp: float32
    PlayerLevelUpExp: float32
    //Filetime: FILETIME
    ShotWidth: uint32
    ShotHeight: uint32
    CompressionType: uint16
}


type SaveFile = {
    HeaderSize: uint32
    Header: Header
}