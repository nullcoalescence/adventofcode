using adventofcode.Util.Interfaces;
using System.Reflection;

namespace adventofcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code");

            Console.Write("Year: ");
            var challengeYear = Console.ReadLine() ?? "";

            Console.Write("Day: ");
            var challengeDay = $"Day{Console.ReadLine()}";

            var idayType = typeof(IDay);
            var adventOfCodeChallenges = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => idayType.IsAssignableFrom(type)
                    && type.IsClass
                    && !type.IsAbstract);

            var matchingChallenges = adventOfCodeChallenges
                .Where(day =>
                    day.Namespace!.Contains(challengeYear)
                    && day.Name.Equals(challengeDay));

            if (!matchingChallenges.Any())
            {
                Console.WriteLine($"Could not find '{challengeDay}' in namespace '{challengeYear}'");
                return;
            }

            var day = (IDay)Activator.CreateInstance(matchingChallenges.First());
            day.Run();
        }

    }
}
