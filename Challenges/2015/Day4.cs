using adventofcode.Util.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace adventofcode.Challenges._2015;

public class Day4 : IChallenge
{
    public int Year { get; } = 2015;
    public int Day { get; } = 4;
    public void Run()
    {
        var input = "iwrupvqb";

        var num = 1;
        int part1 = 0;
        int part2 = 0;
        bool part1Done = false;
        bool part2Done = false;
        
        while (!part1Done || !part2Done)
        {
            var hashInput = $"{input}{num}";
            var encoded = new UTF8Encoding().GetBytes(hashInput);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);
            var converted = Convert.ToHexString(hash);
            
            Console.WriteLine($"{hashInput} -> {converted}");
            
            if (!part1Done && converted.StartsWith("00000"))
            {
                part1 = num;
                part1Done = true;
            }

            if (!part2Done && converted.StartsWith("000000"))
            {
                part2 = num;
                part2Done = true;
            }

            num++;
        }
        
        Console.WriteLine($"lowest positive number to produce md5 starting with 5 0s: {part1}");
        Console.WriteLine($"lowest positive number to produce md5 starting with 6 0s: {part2}");
    }
}