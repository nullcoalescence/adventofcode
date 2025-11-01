using adventofcode.Util.Interfaces;

namespace adventofcode.Challenges._2015;

public class Day3 : IChallenge
{
    private const char Up = '^';
    private const char Down = 'v';
    private const char Left = '<';
    private const char Right = '>';

    private readonly List<Coordinates> _map = new List<Coordinates>();

    private readonly List<Coordinates> _santaMap = new List<Coordinates>();
    private readonly List<Coordinates> _robotSantaMap = new List<Coordinates>();

    public void Run()
    {
        // Start at 0,0 and add starting position to the map
        int xStartPos = 0;
        int yStartPos = 0;

        int xPos = xStartPos;
        int yPos = yStartPos;

        _map.Add(new Coordinates
        {
            X = xPos,
            Y = yPos,
            TimesVisited = 1
        });

        var contents = File.ReadAllText("input/2015/day3.txt");
        var directions = contents.ToCharArray();

        foreach (var direction in directions)
        {
            switch (direction)
            {
                case Up:
                    yPos += 1;
                    break;
                case Down:
                    yPos -= 1;
                    break;
                case Left:
                    xPos -= 1;
                    break;
                case Right:
                    xPos += 1;
                    break;
                default:
                    throw new Exception("Invalid direction");
            }

            // now add coords, or append TimesVisited
            UpdateCoordinateMap(_map, xPos, yPos);

        }

        // any house that has received a present will exist in the _map so just do a .Count()
        int housesThatReceivedAtLeastOnePresent = _map.Count();
        Console.WriteLine($"Part 1: Houses that received multiple presents: {housesThatReceivedAtLeastOnePresent}");

        // --------------
        // part 2 - robot:
        // --------------
        // they start at the same location, so add both to their respective maps
        int xSantaPos = xStartPos;
        int ySantaPos = yStartPos;

        int xRobotSantaPos = xStartPos;
        int yRobotSantaPos = yStartPos;

        _santaMap.Add(new Coordinates
        {
            X = xSantaPos,
            Y = ySantaPos,
            TimesVisited = 1
        });

        _robotSantaMap.Add(new Coordinates
        {
            X = xRobotSantaPos,
            Y = yRobotSantaPos,
            TimesVisited = 1
        });

        var currentSanta = CurrentlyMoving.Santa;

        foreach (var direction in directions)
        {
            switch (direction)
            {
                case Up:
                    if (currentSanta == CurrentlyMoving.Santa)
                    {
                        ySantaPos += 1;
                        UpdateCoordinateMap(_santaMap, xSantaPos, ySantaPos);
                    }

                    if (currentSanta == CurrentlyMoving.RobotSanta)
                    {
                        yRobotSantaPos += 1;
                        UpdateCoordinateMap(_robotSantaMap, xRobotSantaPos, yRobotSantaPos);
                    }
                    break;
                case Down:
                    if (currentSanta == CurrentlyMoving.Santa)
                    {
                        ySantaPos -= 1;
                        UpdateCoordinateMap(_santaMap, xSantaPos, ySantaPos);
                    }

                    if (currentSanta == CurrentlyMoving.RobotSanta)
                    {
                        yRobotSantaPos -= 1;
                        UpdateCoordinateMap(_robotSantaMap, xRobotSantaPos, yRobotSantaPos);
                    }
                    break;;
                case Left:
                    if (currentSanta == CurrentlyMoving.Santa)
                    {
                        xSantaPos -= 1;
                        UpdateCoordinateMap(_santaMap, xSantaPos, ySantaPos);
                    }

                    if (currentSanta == CurrentlyMoving.RobotSanta)
                    {
                        xRobotSantaPos -= 1;
                        UpdateCoordinateMap(_robotSantaMap, xRobotSantaPos, yRobotSantaPos);
                    }
                    break;
                case Right:
                    if (currentSanta == CurrentlyMoving.Santa)
                    {
                        xSantaPos += 1;
                        UpdateCoordinateMap(_santaMap, xSantaPos, ySantaPos);
                    }

                    if (currentSanta == CurrentlyMoving.RobotSanta)
                    {
                        xRobotSantaPos += 1;
                        UpdateCoordinateMap(_robotSantaMap, xRobotSantaPos, yRobotSantaPos);
                    }
                    break;
                default:
                    throw new Exception("Invalid direction");
            }
            
            // now flip currentlyMoving
            currentSanta = currentSanta == CurrentlyMoving.Santa
                ? CurrentlyMoving.RobotSanta
                : CurrentlyMoving.Santa;
        }

        var withoutIntersecting = new List<Coordinates>();

        foreach (var santaCoord in _santaMap)
        {
            if (_robotSantaMap.FirstOrDefault(coord => coord.X == santaCoord.X && coord.Y == santaCoord.Y) != null)
            {
                
            }
        }
        
        Console.WriteLine($"Part 2: total houses: {});
    }

    // should have used a better data structure than a list. oh well this is simple at least.
    private void UpdateCoordinateMap(List<Coordinates> toUpdate, int xNewPos, int yNewPos)
    {
        var matching = toUpdate.FirstOrDefault(coord =>
            coord.X == xNewPos
            && coord.Y == yNewPos);

        // if it exists, just remove it and re-add it with the appended TimesVisited
        if (matching != null)
        {
            var newCoord = new Coordinates
            {
                X = xNewPos,
                Y = yNewPos,
                TimesVisited = matching.TimesVisited + 1
            };

            toUpdate.Remove(matching);
            toUpdate.Add(newCoord);
        }
        // if it doesn't exist, add it with TimesVisited of 1
        else
        {
            toUpdate.Add(new Coordinates
            {
                X = xNewPos,
                Y = yNewPos,
                TimesVisited = 1
            });
        }
    }
}

internal class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public int TimesVisited { get; set; }
}

enum CurrentlyMoving
{
    Santa = 1,
    RobotSanta = 2
}