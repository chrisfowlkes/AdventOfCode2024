// See https://aka.ms/new-console-template for more information
using Classes.Services;

var input = Console.ReadLine();
string[] data;
string result;

switch (input)
{
    case "1A":
        data = File.ReadAllLines(".\\Data\\1.txt");
        result = AdventOfCode.CalculateTotalDifference(data);
        break;
    case "1B":
        data = File.ReadAllLines(".\\Data\\1.txt");
        result = AdventOfCode.FindSimilarityScore(data);
        break;
    case "2A":
        data = File.ReadAllLines(".\\Data\\2.txt");
        result = AdventOfCode.CountSafeReports(data, false);
        break;
    case "2B":
        data = File.ReadAllLines(".\\Data\\2.txt");
        result = AdventOfCode.CountSafeReports(data, true);
        break;
    case "3A":
        data = File.ReadAllLines(".\\Data\\3.txt");
        result = AdventOfCode.ScanMemory(data, false);
        break;
    case "3B":
        data = File.ReadAllLines(".\\Data\\3.txt");
        result = AdventOfCode.ScanMemory(data, true);
        break;
    default:
        result = "Error";
        break;
}

Console.WriteLine(result);
Console.ReadLine();
