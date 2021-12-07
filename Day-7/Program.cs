Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

static int FirstPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    data.Sort();
    int median = 0;
    int fuel = 0;
    if (data.Count % 2 == 0)
    {
        median = (data[data.Count() / 2] + data[data.Count() / 2 + 1]) / 2;
    }
    else
    {
        median = data[data.Count() / 2];
    }

    foreach (var position in data)
    {
        fuel += Math.Abs(median - position);
    }
    return fuel;
}

static int SecondPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    data.Sort();
    int fuel = 0;
    int arithmeticMean = (int)data.Average();

    foreach (var position in data)
    {
        var crabSubmarineDistance = Math.Abs(arithmeticMean - position);
        for (int i = 1; i <= crabSubmarineDistance; i++)
        {
            fuel += i;
        }
    }
    return fuel;
}

static List<int> GetPuzzleInput(string fileName)
{
    return File.ReadAllText(fileName).Split(",").Select(int.Parse).ToList();
}