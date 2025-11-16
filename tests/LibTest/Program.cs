using SSFR;
string path = "/home/baker/SkySaves/SkySave Test/saves/quicksave.ess";

Console.WriteLine("SSFR Example Console");

SaveFile saveFile = new();

try
{
    saveFile.LoadFile(path);
    
    Console.WriteLine($"Name: {saveFile.Header.PlayerName}");
    Console.WriteLine($"Level: {saveFile.Header.PlayerLevel.ToString()}");
    Console.WriteLine($"Location: {saveFile.Header.PlayerLocation}");
    Console.WriteLine($"Race: {saveFile.Header.PlayerRaceEditorID}");

    string sex = saveFile.Header.PlayerSex == 0 ? "Male" : "Female";
    Console.WriteLine($"Sex: {sex}");
} 
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}
