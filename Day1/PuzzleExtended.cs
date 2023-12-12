using System.Configuration;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day1;

public partial class PuzzleExtended
{
    [Fact]
    public void Part1Dev()
    {
        var digits = DetermineFirstAndLastNumber(
            ReadLinesFromFile("C:\\Users\\christoffer.t\\Desktop\\AdventOfCode\\AdventOfCode\\Day1\\input.Dev.Extended.txt"));
        
        var enumerable = digits.ToList();
        var sum = enumerable.Sum();

        var path = "C:\\Users\\christoffer.t\\Desktop\\digits.txt";

        using StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(sum);
    }
    
    [Fact]
    public void Part1()
    {
        var digits = DetermineFirstAndLastNumber(
            ReadLinesFromFile("C:\\Users\\christoffer.t\\Desktop\\AdventOfCode\\AdventOfCode\\Day1\\input.txt"));

        var enumerable = digits.ToList();
        var sum = enumerable.Sum();

        var path = "C:\\Users\\christoffer.t\\Desktop\\digits.txt";
        using StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(sum);
    }
    private static int GetAllDigitsAndTextFromEachChar(string input)
    {
        var allDigits = new List<int>();
        
        var chars = input.ToCharArray();

        var counter = 0;
        foreach (var currentSymbol in chars)
        {
            counter++;
            
            if (char.IsDigit(currentSymbol))
            {
                allDigits.Add(int.Parse(currentSymbol.ToString()));
                continue;
            }

            var sublist = chars.Skip(counter - 1).ToList();
            var currentString = "";
            foreach (var t in sublist)
            {
                currentString += char.ToString(t);
                if (!IsDigitWord(currentString)) continue;
                
                allDigits.Add(CreateIntFromTextNumber(currentString));
                break;
            }
            
        }
        
        var firstAndLast = allDigits.First() + allDigits.Last().ToString();
        return int.Parse(firstAndLast);
    }
    static bool IsDigitWord(string s)
    {
        var pattern = @"\b(?:zero|one|two|three|four|five|six|seven|eight|nine)\b";
        return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
    }
    static int CreateIntFromTextNumber(string number)
    {
        return number.ToLower() switch
        {
            "zero" => 0,
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private static IEnumerable<int> DetermineFirstAndLastNumber(IEnumerable<string> text)
    {
        return text.Select(GetAllDigitsAndTextFromEachChar).ToList();
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
}