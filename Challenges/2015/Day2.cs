using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015
{
    internal class Day2 : IChallenge
    {
        public int Year => 2015;

        public int Day => 2;

        public void Run()
        {
            var totalWrappingPaper = 0;
            var totalRibbon = 0;

            foreach (var line in File.ReadAllLines(@"input/2015/day2.txt"))
            {
                var box = new Box(line);
                totalWrappingPaper += box.CalculateWrappingPaperRequired();
                totalRibbon += box.CalculateRibbonLength();
            }

            Console.WriteLine($"Total wrapping paper required {totalWrappingPaper}");
            Console.WriteLine($"Total ribbon required {totalRibbon}");
        }

        class Box
        {
            private const string Seperator = "x";

            public Box(string inputLine)
            {
                var split = inputLine.Split(Seperator);
                Length = int.Parse(split[0]);
                Width = int.Parse(split[1]);
                Height = int.Parse(split[2]);
            }

            public int Length { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int CalculateWrappingPaperRequired()
            {
                var lwArea = Length * Width;
                var whArea = Width * Height;
                var hlArea = Height * Length;

                var surfaceArea = (2 * lwArea) + (2 * whArea) + (2 * hlArea);

                var smallestSide = new List<int> { lwArea, whArea, hlArea }.Min();

                return surfaceArea + smallestSide;
            }

            public int CalculateRibbonLength()
            {
                var lwPerimeter = (Length * 2) + (Width * 2);
                var whPerimeter = (Width * 2) + (Height * 2);
                var hlPerimeter = (Height * 2) + (Length * 2);

                var volume = Length * Width * Height;

                var smallestPerimter = new List<int> { lwPerimeter, whPerimeter, hlPerimeter }.Min();

                return volume + smallestPerimter;
            }
        }
    }
}
