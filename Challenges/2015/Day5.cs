using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015;

public class Day5 : IChallenge
{
    public int Year { get; } = 2015;
    public int Day { get; } = 5;

    private readonly char[] _vowels;
    private readonly string[] _invalidStrings;

    public Day5()
    {
        _vowels = ['a', 'e', 'i', 'o', 'u'];
        _invalidStrings = ["ab", "cd", "pq", "xy"];
    }
    
    public void Run()
    {
        var contents = File.ReadAllLines("input/2015/day5.txt");
        var numNiceStringsPart1 = 0;
        
        foreach (var line in contents)
        {
            bool isStringNicePart1 = ContainsAtLeast3Vowels(line) && 
                                     ContainsAtLeastOneLetterThatAppearsTwiceInARow(line) &&
                                     DoesNotContainInvalidStrings(line);

            if (isStringNicePart1)
            {
                numNiceStringsPart1++;
            }
        }
        
        Console.WriteLine($"{numNiceStringsPart1} nice strings.");
    }
    
    private bool ContainsAtLeast3Vowels(string line)
    {
        char[] lineSplit = line.ToCharArray();

        int vowelCount = lineSplit
            .Count(letter => _vowels.Contains(letter));

        if (vowelCount >= 3)
        {
            return true;
        }

        return false;
    }

    private bool ContainsAtLeastOneLetterThatAppearsTwiceInARow(string line)
    {
        char[] lineSplit = line.ToCharArray();

        for (int i = 0; i < lineSplit.Length - 1; i++)
        {
            int nextIndex = i + 1;
            if (nextIndex > lineSplit.Length)
            {
                return false;
            }

            if (lineSplit[i] == lineSplit[nextIndex])
            {
                return true;
            }
        }

        return false;
    }

    private bool DoesNotContainInvalidStrings(string line)
    {
        foreach (var invalidString in _invalidStrings)
        {
            if (line.Contains(invalidString))
            {
                return false;
            }
        }

        return true;
    }

    private bool ContainsAtLeastTwoNonOverlappingStrings(string line)
    {
        char[] lineSplit = line.ToCharArray();

        for (int i = 0; i < lineSplit.Length - 1; i++)
        {
            int nextIndex = i + 1;
            if (nextIndex > lineSplit.Length)
            {
                return false;
            }

            string letters = string.Concat(lineSplit[i], lineSplit[nextIndex]);
            // TODO...
        }
    }
}