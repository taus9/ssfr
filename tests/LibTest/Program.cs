using SSFR;

string path = "/home/baker/SkySaves/SkySave Test/saves/quicksave.ess";

SaveFile saveFile = new();
saveFile.LoadFile(path);

// See https://aka.ms/new-console-template for more information
Console.WriteLine(saveFile.HeaderSize.ToString());