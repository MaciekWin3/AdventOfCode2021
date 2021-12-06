// First Puzzle
Console.WriteLine(SolvePuzzle("input.txt", 80));

// Second Puzzle
Console.WriteLine(SolvePuzzle("input.txt", 256));

static long SolvePuzzle(string fileName, int days)
{
    var data = GetPuzzleInput(fileName);
    long numberOfFishes = 0;
    for (int i = 0; i < data.Count(); i++)
    {
        numberOfFishes += LanternFishCounter(days, data[i]);
    }
    return numberOfFishes;
}

static long LanternFishCounter(int numberOfDays, byte fishNumber)
{
    Dictionary<int, int> fishes = new Dictionary<int, int>()
    {
        { 8, 0 },
        { 7, 0 },
        { 6, 0 },
        { 5, 0 },
        { 4, 0 },
        { 3, 0 },
        { 2, 0 },
        { 1, 0 },
        { 0, 0 },
    };

    fishes[fishNumber] = fishes[fishNumber] + 1;
    int beforeTmp = 0;
    int afterTmp = 0;

    for (int i = 1; i <= numberOfDays; i++)
    {
        beforeTmp = 0;
        afterTmp = 0;
        for (int j = 8; j >= 0; j--)
        {
            if (j == 0 && fishes[j] != 0)
            {
                fishes[6] = fishes[6] + fishes[0];
                fishes[8] = fishes[0];
                fishes[0] = 0;
            }
            afterTmp = fishes[j];
            fishes[j] = beforeTmp;
            beforeTmp = afterTmp;
        }
    }

    long result = 0;

    foreach (var item in fishes)
    {
        result += item.Value;
    }

    return result;
}

static IList<byte> GetPuzzleInput(string fileName)
{
    var input = File.ReadAllText(fileName).Split(",").Select(byte.Parse).ToArray();
    return input;
}