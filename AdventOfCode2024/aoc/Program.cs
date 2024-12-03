﻿// See https://aka.ms/new-console-template for more information
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
        result = AdventOfCode.CountSafeReports(data);
        break;
    default:
        result = "Error";
        break;
}

Console.WriteLine(result);
Console.ReadLine();
