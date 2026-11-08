using adventofcode.Util.Interfaces;
using adventofcode.Util.Models;
using System.Reflection;

namespace adventofcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** advent of code **");

            ChallengeDate challengeDate;
            if (args != null && args.Any())
            {
                challengeDate = ParseArgs(args);
            }
            else
            {
                Console.WriteLine("(optional launch args: --year=<year> --day=<day>)");
                challengeDate = PromptArgs();
            }

            LaunchChallenge(challengeDate);
        }

        private static ChallengeDate ParseArgs(string[] args)
        {
            if (args.Length != 2 ||
                !args[0].Contains("--year=") ||
                !args[1].Contains("--day="))
            {
                throw new ArgumentException("Args must be in format --year=<year> --day=<day> (Ex. --year=2026 --day=1");
            }

            return new ChallengeDate
            {
                Year = int.Parse(args[0].Split("--year=")[1]),
                Day = int.Parse(args[1].Split("--day=")[1])
            };
        }

        private static ChallengeDate PromptArgs()
        {
            Console.Write("Year: ");
            var year = Console.ReadLine();

            Console.Write("Day: ");
            var day = Console.ReadLine();

            return new ChallengeDate
            {
                Year = int.Parse(year),
                Day = int.Parse(day)
            };
        }

        private static void LaunchChallenge(ChallengeDate challengeDate)
        {
            Console.WriteLine($"Searching for challenge {challengeDate.ToString()}...");

            var iChallengeType = typeof(IChallenge);
            var challenges = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type =>
                    iChallengeType.IsAssignableFrom(type) &&
                    type.IsClass &&
                    !type.IsAbstract)
            .Select(c => (IChallenge)Activator.CreateInstance(c)!)
            .SingleOrDefault(c =>
                c.Year == challengeDate.Year &&
                c.Day == challengeDate.Day);
                

            if (challenges == null)
            {
                Console.WriteLine("Couldn't locate challenge!");
            }

            Console.WriteLine($"Launching challenge {challengeDate.ToString()}");

            var instance = (IChallenge)Activator.CreateInstance((challenges!.GetType()))!;
            instance.Run();
        }
    }
}
