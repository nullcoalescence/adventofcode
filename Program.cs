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

            var iChallengeType = typeof(IChallenge);
            var adventOfCodeChallenges = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => iChallengeType.IsAssignableFrom(type)
                    && type.IsClass
                    && !type.IsAbstract);

            var matchingChallenge = adventOfCodeChallenges
                .FirstOrDefault(day =>
                    day.Namespace!.Contains(challengeYear)
                    && day.Name.Equals(challengeDay));

            if (matchingChallenge == null)
            {
                Console.WriteLine($"Could not find '{challengeDay}' in namespace '{challengeYear}'");
                return;
            }
            
            var challenge = (IChallenge)Activator.CreateInstance(matchingChallenge)!;
            challenge.Run();
        }

    }
}
