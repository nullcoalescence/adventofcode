using adventofcode.Util.Interfaces;

namespace adventofcode.Years._2024
{
    internal class Day1 : IDay
    {
        public void Run()
        {
            // Part 1
            var lines = File.ReadAllLines("input/2024/day1.txt");

            var column1 = new List<int>();
            var column2 = new List<int>();

            var seperator = "   ";
            foreach (var line in lines)
            {
                column1.Add(int.Parse(line.Split(seperator)[0]));
                column2.Add(int.Parse(line.Split(seperator)[1]));
            }

            column1 = column1
                .OrderBy(num => num)
                .ToList();

            column2 = column2
                .OrderBy(num => num)
                .ToList();

            var total = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                total += Math.Abs(column1[i] - column2[i]);
            }

            Console.WriteLine($"Total: {total}");

            // Part 2
            var similarityScore = 0;
            foreach (int num in column1)
            {
                int timesOccursInSecondCol = column2.Count(n => n == num);
                similarityScore += num * timesOccursInSecondCol;
            }

            Console.WriteLine($"Similarity score: {similarityScore}");
        }
    }
}
