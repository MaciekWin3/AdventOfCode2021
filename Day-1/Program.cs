
Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

static int FirstPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    int increasesCounter = 0;

    for (int i = 0; i + 1 < data.Count(); i++)
    {
        if (data[i] < data[i + 1])
        {
            increasesCounter++;
        }
    }

    return increasesCounter;
}

static int SecondPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    int increasesCounter = 0;

    for (int i = 0; i + 3 < data.Count(); i++)
    {
        int a = data[i] + data[i + 1] + data[i + 2];
        int b = data[i + 1] + data[i + 2] + data[i + 3];

        if (a < b)
        {
            increasesCounter++;
        }
    }

    return increasesCounter;
}

static List<int> GetPuzzleInput(string fileName)
{
    var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
    List<string> input = File.ReadAllLines(path).ToList();
    return input.ConvertAll(l => int.Parse(l));
}



