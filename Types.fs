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
    Magic:char[13]
    HeaderSize: uint32
    Header: Header
    ScreenshotData: LEScreenshot | SEScreenshot
    UncompressedLen: uint32
    CompressedLen: uint32
    FormVersion: uint8
    PluginInfoSize: uint32
    PluginInfo: PluginInfo
    LightPluginInfo: LightPluginInfo
    FileLocationTable: FileLocationTable
    GlobalDataTable1: GlobalData[]
    GlobalDataTable2: GlobalData[]
    ChangeForms: ChangeForm
    GlobalDataTable3: GlobalData[]
    FormIDArrayCount: uint32
    FormIDArray: FormId[]
    VisitedWorldspaceArrayCount: uint32
    VistedWorldspaceArray: FormID[]
    Unknown3TableSize: uint32
    Uknown3Table: Unknown3Table
}