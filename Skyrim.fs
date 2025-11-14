namespace ssfr

type Skyrim() =

    member _.LoadFile(path: string) =
        Parser.loadFile path