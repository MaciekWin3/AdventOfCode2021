Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

static int FirstPuzzle(string fileName)
{
    // 1, 4, 7, 8
    // c, f - 1 (2)
    // b, c, d, f - 4 (4)
    // a, c, f - 7 (3)
    // a, b, c, d, e, f, g - 8 (7)
    var input = File.ReadAllLines(fileName).ToList();
    int counter = 0;
    foreach (var line in input)
    {
        string[] parts = line.Split("| ");
        var signalPatterns = parts[0].Split(" ");
        var output = parts[1].Split(" ");

        foreach (var digits in output)
        {
            foreach (var signal in signalPatterns)
            {
                if (signal.Length == digits.Length && signal.Length is 2 or 3 or 4 or 7)
                {
                    counter++;
                }
            }
        }
    }
    return counter;
}

static int SecondPuzzle(string fileName)
{
    var input = File.ReadAllLines(fileName).ToList();
    int counter = 0;
    foreach (var line in input)
    {
        Dictionary<int, string> numbers = new Dictionary<int, string>()
        {
            { 9, string.Empty },
            { 8, string.Empty },
            { 7, string.Empty },
            { 6, string.Empty },
            { 5, string.Empty },
            { 4, string.Empty },
            { 3, string.Empty },
            { 2, string.Empty },
            { 1, string.Empty },
            { 0, string.Empty },
        };
        string number = "";
        string[] parts = line.Split("| ");
        var signalPatterns = parts[0].Split(" ");
        var output = parts[1].Split(" ");
        foreach (var digits in signalPatterns)
        {
            if (digits.Length is 2)
            {
                numbers[1] = digits;
            }
            if (digits.Length is 3)
            {
                numbers[7] = digits;
            }
            if (digits.Length is 4)
            {
                numbers[4] = digits;
            }
            if (digits.Length is 7)
            {
                numbers[8] = digits;
            }
        }
        foreach (var digits in signalPatterns.Where(x => x.Length == 5))
        {
            if (digits.Contains(numbers[1][0]) && digits.Contains(numbers[1][1]))
            {
                numbers[3] = digits;
            }
        }
        foreach (var digits in signalPatterns.Where(x => x.Length == 5 && (!x.Contains(numbers[1][0]) || !x.Contains(numbers[1][1]))))
        {
            int digitsCounter = 0;
            if (digits.Contains(numbers[4][0]))
            {
                digitsCounter++;
            }
            if (digits.Contains(numbers[4][1]))
            {
                digitsCounter++;
            }
            if (digits.Contains(numbers[4][2]))
            {
                digitsCounter++;
            }
            if (digits.Contains(numbers[4][3]))
            {
                digitsCounter++;
            }
            if (digitsCounter == 2)
            {
                numbers[2] = digits;
            }
            if (digitsCounter == 3)
            {
                numbers[5] = digits;
            }
        }
        foreach (var digits in signalPatterns.Where(x => x.Length == 6))
        {
            if (digits.Contains(numbers[1][0]) && digits.Contains(numbers[1][1]))
            {
                int digitsCounter = 0;
                if (digits.Contains(numbers[4][0]))
                {
                    digitsCounter++;
                }
                if (digits.Contains(numbers[4][1]))
                {
                    digitsCounter++;
                }
                if (digits.Contains(numbers[4][2]))
                {
                    digitsCounter++;
                }
                if (digits.Contains(numbers[4][3]))
                {
                    digitsCounter++;
                }
                if (digitsCounter == 3)
                {
                    numbers[0] = digits;
                }
                else
                {
                    numbers[9] = digits;
                }
            }
            else
            {
                numbers[6] = digits;
            }
        }
        foreach (var item in output)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (String.Concat(numbers[i].OrderBy(x => x)) == String.Concat(item.OrderBy(x => x)))
                {
                    number += i.ToString();
                    continue;
                }
            }
        }

        Console.WriteLine(number);
        counter += int.Parse(number);
    }
    return counter;
}