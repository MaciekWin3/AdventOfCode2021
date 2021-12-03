Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

static int FirstPuzzle(string fileName)
{
    var input = GetPuzzleInput(fileName);
    int depth = 0;
    int horizontalPosition = 0;
    for (int i = 0; i < input.Count(); i++)
    {
        if (input[i].direction == "forward")
        {
            horizontalPosition += input[i].units;
        }
        if (input[i].direction == "up")
        {
            depth -= input[i].units;
        }
        if (input[i].direction == "down")
        {
            depth += input[i].units;
        }
    }
    return horizontalPosition * depth;
}

static int SecondPuzzle(string fileName)
{
    var input = GetPuzzleInput(fileName);
    int depth = 0;
    int horizontalPosition = 0;
    int aim = 0;
    for (int i = 0; i < input.Count(); i++)
    {
        if (input[i].direction == "forward")
        {
            horizontalPosition += input[i].units;
            depth += aim * input[i].units;
        }
        if (input[i].direction == "up")
        {
            aim -= input[i].units;
        }
        if (input[i].direction == "down")
        {
            aim += input[i].units;
        }
    }
    return horizontalPosition * depth;
}


static List<(string direction, int units)> GetPuzzleInput(string fileName)
{
    var input = File.ReadAllLines(fileName).ToList();
    List<(string, int)> data = new List<(string, int)>();
    foreach (var command in input)
    {
        string[] s = command.Split(" ");
        var x = (s[0], int.Parse(s[1]));
        data.Add(x);
    }
    return data;
}
