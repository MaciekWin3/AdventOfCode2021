Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

static int SecondPuzzle(string fileName)
{
    List<Coordinate> coordinates = new List<Coordinate>();
    var data = GetPuzzleInput(fileName);
    foreach (var line in data)
    {
        // x up, y up +
        if (line.start.x < line.finish.x && line.start.y < line.finish.y)
        {
            int y = line.start.y;
            for (int x = line.start.x; x <= line.finish.x; x++)
            {
                coordinates.Add(new Coordinate(x, y));
                y++;
            }
            continue;
        }
        // x down, y down
        if (line.start.x > line.finish.x && line.start.y > line.finish.y)
        {
            int y = line.start.y;
            for (int x = line.start.x; x >= line.finish.x; x--)
            {
                coordinates.Add(new Coordinate(x, y));
                y--;
            }
            continue;
        }
        // x up, y down +
        if (line.start.x < line.finish.x && line.start.y > line.finish.y)
        {
            int y = line.start.y;
            for (int x = line.start.x; x <= line.finish.x; x++)
            {
                coordinates.Add(new Coordinate(x, y));
                y--;
            }
            continue;
        }
        // x down, y up +
        if (line.start.x > line.finish.x && line.start.y < line.finish.y)
        {
            int y = line.start.y;
            for (int x = line.start.x; x >= line.finish.x; x--)
            {
                coordinates.Add(new Coordinate(x, y));
                y++;
            }
            continue;
        }

        if (line.start.x != line.finish.x)
        {
            if (line.start.x < line.finish.x)
            {
                for (int i = line.start.x; i <= line.finish.x; i++)
                {
                    coordinates.Add(new Coordinate(i, line.start.y));
                }
            }
            else
            {
                for (int i = line.finish.x; i <= line.start.x; i++)
                {
                    coordinates.Add(new Coordinate(i, line.start.y));
                }
            }
        }
        else
        {
            if (line.start.y < line.finish.y)
            {
                for (int i = line.start.y; i <= line.finish.y; i++)
                {
                    coordinates.Add(new Coordinate(line.start.x, i));
                }
            }
            else
            {
                for (int i = line.finish.y; i <= line.start.y; i++)
                {
                    coordinates.Add(new Coordinate(line.start.x, i));
                }
            }
        }
    }

    return coordinates.GroupBy(c => new { c.x, c.y }).Where(c => c.Count() > 1).Count();
}

static int FirstPuzzle(string fileName)
{
    List<Coordinate> coordinates = new List<Coordinate>();
    var data = GetPuzzleInput(fileName);
    foreach (var line in data)
    {
        if (line.start.x == line.finish.x || line.start.y == line.finish.y)
        {
            if (line.start.x != line.finish.x)
            {
                if (line.start.x < line.finish.x)
                {
                    for (int i = line.start.x; i <= line.finish.x; i++)
                    {
                        coordinates.Add(new Coordinate(i, line.start.y));
                    }
                }
                else
                {
                    for (int i = line.finish.x; i <= line.start.x; i++)
                    {
                        coordinates.Add(new Coordinate(i, line.start.y));
                    }
                }
            }
            else
            {
                if (line.start.y < line.finish.y)
                {
                    for (int i = line.start.y; i <= line.finish.y; i++)
                    {
                        coordinates.Add(new Coordinate(line.start.x, i));
                    }
                }
                else
                {
                    for (int i = line.finish.y; i <= line.start.y; i++)
                    {
                        coordinates.Add(new Coordinate(line.start.x, i));
                    }
                }
            }
        }
    }
    return coordinates.GroupBy(c => new { c.x, c.y }).Where(c => c.Count() >= 2).Count();
}

static List<Line> GetPuzzleInput(string fileName)
{
    var input = File.ReadAllLines(fileName).ToList();
    List<Line> lines = new List<Line>();
    foreach (var line in input)
    {
        Coordinate[] lineCoordinates = new Coordinate[2];
        var modifiedLine = line.Replace(" -> ", ",");
        int[] numbers = modifiedLine.Split(',').Select(Int32.Parse).ToArray();
        var start = new Coordinate(numbers[0], numbers[1]);
        var finish = new Coordinate(numbers[2], numbers[3]);
        lines.Add(new Line(start, finish));
    }
    return lines;
}

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int x;
    public int y;
    static int points;
}

public struct Line
{
    public Line(Coordinate start, Coordinate finish)
    {
        this.start = start;
        this.finish = finish;
    }
    public Coordinate start;
    public Coordinate finish;
    static int points;
}
