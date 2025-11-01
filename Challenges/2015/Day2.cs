using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015
{
    public class Day2 : IChallenge
    {
        private const char Seperator = 'x';
    
        public void Run()
        {
            var contents = File.ReadAllLines("input/2015/day2.txt");

            int totalWrappingPaper = 0;
            int totalRibbon = 0;
        
            foreach (string line in contents)
            {
                var prism = ParseAndCreatePrism(line);
                var wrappingPaper = CalculatePaperNeeded(prism);
                var ribbon = CaclulateRibbonNeeded(prism);
            
                totalWrappingPaper += wrappingPaper.TotalPaperNeeded;
                totalRibbon += ribbon.TotalRibbonNeeded;
            }
        
            Console.WriteLine($"Total wrapping paper needed: {totalWrappingPaper}");
            Console.WriteLine($"Total ribbon needed: {totalRibbon}");
        }

        private RectangularPrism ParseAndCreatePrism(string line)
        {
            var splitAndParsed = line
                .Split(Seperator)
                .Select(int.Parse)
                .ToArray();

            return new RectangularPrism
            {
                Length = splitAndParsed[0],
                Width = splitAndParsed[1],
                Height = splitAndParsed[2]
            };
        }

        private PaperCalculation CalculatePaperNeeded(RectangularPrism prism)
        {
            int side1 = prism.Length * prism.Width;
            int side2 = prism.Width * prism.Height;
            int side3 = prism.Height * prism.Length;
        
            int smallest = int.Min(int.Min(side1, side2), side3);

            return new PaperCalculation
            {
                SurfaceArea = 2 *side1 + 2 * side2 + 2 * side3,
                SurfaceAreaOfSmallestSide = smallest
            };
        }

        private RibbonCalculation CaclulateRibbonNeeded(RectangularPrism prism)
        {
            int perimeterOfSide1 = prism.Length * 2 + prism.Width * 2;
            int perimeterOfSide2 = prism.Width * 2 + prism.Height * 2;
            int perimeterOfSide3 = prism.Height * 2 + prism.Length * 2;

            int shortest = int.Min(int.Min(perimeterOfSide1, perimeterOfSide2), perimeterOfSide3);
            int volume = prism.Length * prism.Width * prism.Height;

            return new RibbonCalculation
            {
                ShortestPerimeter = shortest,
                Bow = volume
            };
        }
    }

    internal class RectangularPrism
    {
        public int Length { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
    }

    internal class PaperCalculation
    {
        public int SurfaceArea { get; init; }
        public int SurfaceAreaOfSmallestSide { get; init; }
        public int TotalPaperNeeded => SurfaceArea + SurfaceAreaOfSmallestSide;
    }

    internal class RibbonCalculation
    {
        public int ShortestPerimeter { get; init; }
        public int Bow { get; init; }
        public int TotalRibbonNeeded => ShortestPerimeter + Bow;
    }
}