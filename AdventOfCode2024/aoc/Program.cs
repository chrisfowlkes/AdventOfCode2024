// See https://aka.ms/new-console-template for more information
using Classes.Services;

var input = Console.ReadLine();
string[] data;
string result;

switch (input)
{
    case "1":
        data = File.ReadAllLines(".\\Data\\1.txt");
        result = AdventOfCode.CalculateTotalDifference(data);
        break;
    default:
        result = "Error";
        break;
}

Console.WriteLine(result);
Console.ReadLine();
