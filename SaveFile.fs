namespace ssfr

type SaveFile() =

    member _.LoadFile(path: string) =
        Parser.loadFile path