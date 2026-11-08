using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015
{
    internal class Day1 : IChallenge
    {
        public int Year => 2015;
        public int Day => 1;

        public void Run()
        {
            var startingPos = 0;
            var basementPos = -1;
            var currentPos = startingPos;

            var hasEnteredBasement = false;
            var enteredBasementAtCharPos = 0;

            var counter = 0;

            var contents = File.ReadAllText(@"input/2015/day1.txt");
            foreach (var direction in contents.ToCharArray())
            {
                switch (direction)
                {
                    case '(':
                        currentPos++;
                        break;
                    case ')':
                        currentPos--;
                        break;
                    default:
                        throw new Exception("Invalid input");
                }

                counter++;

                if (!hasEnteredBasement && currentPos == basementPos)
                {
                    hasEnteredBasement = true;
                    enteredBasementAtCharPos = counter;
                }
            }

            Console.WriteLine($"Final floor: {currentPos}");
            Console.WriteLine($"Entered basement at character: {enteredBasementAtCharPos}");
        }
    }
}
