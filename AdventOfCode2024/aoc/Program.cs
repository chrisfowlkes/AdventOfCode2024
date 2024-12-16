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
    case "4A":
        data = File.ReadAllLines(".\\Data\\4.txt");
        result = AdventOfCode.WordSearch(data);
        break;
    case "4B":
        data = File.ReadAllLines(".\\Data\\4.txt");
        result = AdventOfCode.WordSearchX(data);
        break;
    case "5A":
        data = File.ReadAllLines(".\\Data\\5.txt");
        result = AdventOfCode.CheckSafetyManualUpdate(data);
        break;
    case "5B":
        data = File.ReadAllLines(".\\Data\\5.txt");
        result = AdventOfCode.FixSafetyManualUpdate(data);
        break;
    case "6A":
        data = File.ReadAllLines(".\\Data\\6.txt");
        result = AdventOfCode.CountLabLocationsChecked(data);
        break;
    case "6B":
        data = File.ReadAllLines(".\\Data\\6.txt");
        result = AdventOfCode.CountLoopLocations(data);
        break;
    case "7A":
        data = File.ReadAllLines(".\\Data\\7.txt");
        result = AdventOfCode.CheckEquations(data, false);
        break;
    case "7B":
        data = File.ReadAllLines(".\\Data\\7.txt");
        result = AdventOfCode.CheckEquations(data, true);
        break;
    case "8A":
        data = File.ReadAllLines(".\\Data\\8.txt");
        result = AdventOfCode.CountAntinodes(data, false);
        break;
    case "8B":
        data = File.ReadAllLines(".\\Data\\8.txt");
        result = AdventOfCode.CountAntinodes(data, true);
        break;
    case "9A":
        data = File.ReadAllLines(".\\Data\\9.txt");
        result = AdventOfCode.CompressDisk(data[0], true);
        break;
    case "9B":
        data = File.ReadAllLines(".\\Data\\9.txt");
        result = AdventOfCode.CompressDisk(data[0], false);
        break;
    case "10A":
        data = File.ReadAllLines(".\\Data\\10.txt");
        result = AdventOfCode.SumTrailScores(data);
        break;
    case "10B":
        data = File.ReadAllLines(".\\Data\\10.txt");
        result = AdventOfCode.SumTrailRatings(data);
        break;
    default:
        result = "Error";
        break;
}

Console.WriteLine(result);
Console.ReadLine();
