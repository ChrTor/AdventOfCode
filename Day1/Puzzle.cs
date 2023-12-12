using System.Text.RegularExpressions;
using Xunit;

namespace AdventOfCode.Day1;

public partial class Puzzle
{
    [Fact]
    public void Part1Dev()
    {
        var text = ReadLinesFromFile(
            "C:\\Users\\christoffer.t\\Desktop\\AdventOfCode\\AdventOfCode\\Day1\\input.Dev.txt");
        var digits = DetermineFirstAndLastNumber(text);
        
        var enumerable = digits.ToList();
        var sum = enumerable.Sum();

        var path = "C:\\Users\\christoffer.t\\Desktop\\digits.txt";

        using var writer = new StreamWriter(path);
        writer.WriteLine(sum);
    }
    
    [Fact]
    public void Part1()
    {
        var text = ReadLinesFromFile("C:\\Users\\christoffer.t\\Desktop\\AdventOfCode\\AdventOfCode\\Day1\\input.txt");
        var digits = DetermineFirstAndLastNumber(text);

        var enumerable = digits.ToList();
        var sum = enumerable.Sum();

        var path = "C:\\Users\\christoffer.t\\Desktop\\digits.txt";
        using var writer = new StreamWriter(path);
        writer.WriteLine(sum);
    }
    private static IEnumerable<string?> ReadLinesFromFile(string filePath)
    {
        var lines = new List<string?>();

        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            lines.Add(line);
        }

        return lines;
    }
    private static IEnumerable<int> DetermineFirstAndLastNumber(IEnumerable<string?> text)
    {
        return text.Select(GetAllDigits).ToList();
    }
    private static int GetAllDigits(string input)
    {
        var matches = Regex.Matches(input, @"(\d)", RegexOptions.IgnoreCase);
        var allDigits = new List<int>();

        foreach (Match match in matches)
        {
            if (match.Groups[1].Success) // Numeric digit
            {
                allDigits.Add(int.Parse(match.Value));
            }
        }
        
        var firstAndLast = allDigits.First().ToString() + allDigits.Last().ToString();
        return int.Parse(firstAndLast);
        

        // Handle the case where there are not enough digits
        return -1; // or throw an exception or handle the error as needed
    }
}