
string path = "/home/baker/SkySaves/SkySave Test/saves/quicksave.ess";

ssfr.SaveFile saveFile = new ssfr.Skyrim().LoadFile(path);

// See https://aka.ms/new-console-template for more information
Console.WriteLine(saveFile.HeaderSize.ToString());

