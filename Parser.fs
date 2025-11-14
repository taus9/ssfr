namespace ssfr
open System.IO
open System.Text

module Parser =

    type ParseError = 
        | InvalidFile

    let _magic = "TESV_SAVEGAME"

    let loadFile path : SaveFile =
        use fileStream = File.Open(path, FileMode.Open, FileAccess.Read)
        use reader = new BinaryReader(fileStream)

        let magic = 
            Encoding.ASCII.GetString(reader.ReadBytes(_magic.Length))
        
        if magic <> _magic then failwith "Not a valid Skyrim save file."

        let headerSize = reader.ReadUInt32()
        
        { HeaderSize = headerSize }
