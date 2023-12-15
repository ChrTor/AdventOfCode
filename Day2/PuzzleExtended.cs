using System.Text.RegularExpressions;
using Xunit;

namespace AdventOfCode.Day2;

public class PuzzleExtended
{
    [Fact]
    public void Part1Dev()
    {

        var text = ReadLinesFromFile(
            "C:\\Users\\christoffer.t\\Desktop\\AdventOfCode\\AdventOfCode\\Day2\\input.Dev.txt");

        
        var ammount = GetPossibleGames(text);
        
        var path = "C:\\Users\\christoffer.t\\Desktop\\digits.txt";
        using var writer = new StreamWriter(path);
        writer.WriteLine();
    }
    
    [Fact]
    public void Part1()
    {
        var text = ReadLinesFromFile("C:\\Users\\christoffer.t\\Desktop\\AdventOfCode\\AdventOfCode\\Day2\\input.txt");
        
        var ammount = GetPossibleGames(text);
        
        var path = "C:\\Users\\christoffer.t\\Desktop\\digits.txt";
        using var writer = new StreamWriter(path);
        writer.WriteLine();
    }
    private static int GetPossibleGames(IEnumerable<string> text)
    {
        var games = new List<Game>();
        
        foreach (var currentGame in text)
        {
            var rounds = currentGame.Trim().Split(':', ';');
            var newGame = new Game();
            bool shouldSave = true;
            foreach (var currentRound in rounds)
            {
                if (currentRound.Contains("Game"))
                {
                    var amountString = "";
                    foreach (var character in currentRound)
                    {
                        if (Char.IsDigit(character))
                        {
                            amountString += character;
                        }
                    }
                    newGame.Id = int.Parse(amountString);
                    continue;
                }

                var cubes = currentRound.Trim().Split(',');
                
                
                foreach (var cube in cubes)
                {
                    var currentLine = cube.Trim();
                    var amountString = "";
                    foreach (var character in currentLine)
                    {
                        if (Char.IsDigit(character))
                        {
                            amountString += character;
                        }
                    }
                    
                    var amount = int.Parse(amountString);
                    switch (currentLine)
                    {
                        case string s when s.Contains("red"):
                            if (amount > newGame.Red)
                            {
                                newGame.Red = amount;
                            }
                            break;
                        case string s when s.Contains("blue"):
                            if (amount > newGame.Blue)
                            {
                                newGame.Blue = amount;
                            }
                            break;
                        case string s when s.Contains("green"):
                            if (amount > newGame.Green)
                            {
                                newGame.Green = amount;
                            }
                            break;
                    }
                }
            }
            games.Add(newGame);
        }

        
        int sum = 0;
        foreach (var game in games)
        {
            sum += (game.Red * game.Blue * game.Green);
        }
        
        return sum;
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

    public class AllowedCubes
    {
        public int Red { get; set; }
        public int Blue { get; set; }
        public int  Green { get; set; }
    }
    
    class Game
    {
        public int Id { get; set; }
        public int Red { get; set; } = 0;
        public int Blue { get; set; } = 0;
        public int Green { get; set; } = 0;
    }
}