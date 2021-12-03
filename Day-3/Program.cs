Console.WriteLine(FirstPuzzle("input.txt"));

static int FirstPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    string gammaRate = "";
    string epsilonRate = "";

    for (int i = 0; i < data[0].Length; i++)
    {
        int zerosCounter = 0;
        int onesCounter = 0;
        foreach (var binary in data)
        {
            if (binary[i] == '0')
            {
                zerosCounter++;
            }
            if (binary[i] == '1')
            {
                onesCounter++;
            }
        }

        if (zerosCounter > onesCounter)
        {
            gammaRate += '0';
            epsilonRate += '1';
        }
        else
        {
            gammaRate += '1';
            epsilonRate += '0';
        }
    }

    return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
}

static List<string> GetPuzzleInput(string fileName)
{
    return File.ReadAllLines(fileName).ToList();
}