using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015;

public class Day3 : IChallenge
{
    public int Year { get; } = 2015;
    public int Day { get; } = 3;

    class MoveDirections
    {
        public int XDelta { get; set; }
        public int YDelta { get; set; }
    }

    private record struct Position(int X, int Y);

    private readonly Dictionary<char, MoveDirections> _directionLookup;
    private readonly HashSet<Position> _visitedPositions;
    private readonly HashSet<Position> _partTwoVisitedPositions;
    
    private enum CurrentSanta
    {
        Santa,
        RobotSanta
    };

    public Day3()
    {
        _directionLookup = new Dictionary<char, MoveDirections>
        {
            { '^', new MoveDirections { XDelta = 0, YDelta = 1 } },
            { 'v', new MoveDirections { XDelta = 0, YDelta = -1 } },
            { '>', new MoveDirections { XDelta = 1, YDelta = 0 } },
            { '<', new MoveDirections { XDelta = -1, YDelta = 0 } }
        };

        _visitedPositions = new HashSet<Position>();
        _partTwoVisitedPositions = new HashSet<Position>();
    }
    
    public void Run()
    {
        // Part one
        var contents = File.ReadAllText("input/2015/day3.txt");
        var directions = contents.ToCharArray();

        var pos = new Position(0, 0);
        _visitedPositions.Add(pos);

        foreach (var direction in directions)
        {
            _directionLookup.TryGetValue(direction, out var moveDirection);
            if (moveDirection == null)
            {
                continue;
            }
            pos.X += moveDirection.XDelta;
            pos.Y += moveDirection.YDelta;

            _visitedPositions.Add(pos);
        }

        Console.WriteLine($"{_visitedPositions.Count} houses received at least one present");
        
        // Part 2
        var currentSanta = CurrentSanta.Santa;
        var startingPos = new Position(0, 0);
        var santaPos = startingPos;
        var robotSantaPos = startingPos;

        _partTwoVisitedPositions.Add(startingPos);

        foreach (var direction in directions)
        {
            _directionLookup.TryGetValue(direction, out var moveDirection);
            if (moveDirection == null)
            {
                continue;
            }

            if (currentSanta == CurrentSanta.Santa)
            {
                santaPos.X += moveDirection.XDelta;
                santaPos.Y += moveDirection.YDelta;

                _partTwoVisitedPositions.Add(santaPos);
                currentSanta = CurrentSanta.RobotSanta;
            }
            else
            {
                robotSantaPos.X += moveDirection.XDelta;
                robotSantaPos.Y += moveDirection.YDelta;

                _partTwoVisitedPositions.Add(robotSantaPos);
                currentSanta = CurrentSanta.Santa;
            }
        }
        
        Console.WriteLine($"Part 2: {_partTwoVisitedPositions.Count}");
    }
}