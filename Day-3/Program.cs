Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

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

static int SecondPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    return OxygenGeneratorRating() * CO2ScrubberRating();
}

static int OxygenGeneratorRating()
{
    var data = GetPuzzleInput("input.txt");
    int binaryLength = data[0].Length;
    while(data.Count != 1)
    {
        for (int i = 0; i < binaryLength; i++)
        {
            int zerosCounter = 0;
            int onesCounter = 0;
            foreach (var binary in data)
            {
                if (binary[i] == '0')
                {
                    zerosCounter++;
                }
                else
                {
                    onesCounter++;
                }
            }
            if (onesCounter >= zerosCounter)
            {
                data.RemoveAll(x => x[i] == '0');
            }
            else
            {
                data.RemoveAll(x => x[i] == '1');
            }
        }
    }
    return Convert.ToInt32(data.FirstOrDefault(), 2);
}

static int CO2ScrubberRating()
{
    var data = GetPuzzleInput("input.txt");
    int i = 0;
    while (data.Count() != 1)
    {
        int zerosCounter = 0;
        int onesCounter = 0;
        for(int j = 0; j < data.Count(); j++)
        {
            if (data[j][i] == '0')
            {
                zerosCounter++;
            }
            else
            {
                onesCounter++;
            }
        }

        if (zerosCounter <= onesCounter)
        {
            data.RemoveAll(x => x[i] == '1');
        }
        else
        {
            data.RemoveAll(x => x[i] == '0');
        }
        if(data.Count == 1)
        {
            break;
        }
        if (i == data[0].Length)
        {
            i = 0;
        }
        else
        {
            i++;
        }
    }

    Console.WriteLine(Convert.ToInt32(data.FirstOrDefault(), 2));
    return Convert.ToInt32(data.FirstOrDefault(), 2);
}

static List<string> GetPuzzleInput(string fileName)
{
    return File.ReadAllLines(fileName).ToList();
}