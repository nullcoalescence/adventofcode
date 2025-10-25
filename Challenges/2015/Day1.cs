using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015
{
    public class Day1 : IDay
    {
        public void Run()
        {
            string fileContents = File.ReadAllText("input/2015/day1.txt");

            const char Up = '(';
            const char Down = ')';
            
            const int StartingPosition = 0;
            const int BasementPosition = -1;
            
            int position = StartingPosition;
            int index = 0;
            bool alreadyEnteredBasement = false;
            
            foreach (var character in fileContents.ToCharArray())
            {
                index++;
                
                switch (character)
                {
                    case Up:
                        position++;
                        break;
                    case Down:
                        position--;
                        break;
                    default:
                        throw new Exception("Invalid char");
                }

                if (position == BasementPosition && !alreadyEnteredBasement)
                {
                    alreadyEnteredBasement = true;
                    Console.WriteLine($"Basement ({position}) entered at: {index}");
                }
            }
            
            Console.WriteLine($"Floor: {position}");
        }
    }
}
