Console.WriteLine(FirstPuzzle("input.txt"));
Console.WriteLine(SecondPuzzle("input.txt"));

static int SecondPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    var numbersToDraw = GetBingoNumbers(fileName);
    List<int[,]> boards = new List<int[,]>();
    int i = 0;
    while (i < data.Count())
    {
        int[,] board = new int[5, 5];
        for (int j = 0; j < board.GetLength(0); j++)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                board[j, x] = data[i];
                i++;
            }
        }
        boards.Add(board);
    }

    int result = 0;
    for (int j = 1; j < numbersToDraw.Count(); j++)
    {
        var numbersDrawn = numbersToDraw.Take(j).ToList();
        for (int z = 1; z < boards.Count(); z++)
        {
            result = DoesBoardHaveBingo(boards[z], numbersDrawn);
            if (result != 0)
            {
                boards.Remove(boards[z]);
            }
        }

        if (boards.Count() == 1)
        {
            return result * numbersDrawn.LastOrDefault();
        }
    }

    return 0;
}

static int FirstPuzzle(string fileName)
{
    var data = GetPuzzleInput(fileName);
    var numbersToDraw = GetBingoNumbers(fileName);
    List<int[,]> boards = new List<int[,]>();
    int i = 0;
    while (i < data.Count())
    {
        int[,] board = new int[5, 5];
        for (int j = 0; j < board.GetLength(0); j++)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                board[j, x] = data[i];
                i++;
            }
        }
        boards.Add(board);
    }

    for (int j = 1; j < numbersToDraw.Count(); j++)
    {
        var numbersDrawn = numbersToDraw.Take(j).ToList();
        foreach (var board in boards)
        {
            int result = DoesBoardHaveBingo(board, numbersDrawn);
            if (result != 0)
            {
                return result * numbersDrawn.LastOrDefault();
            }
        }
    }

    return 0;
}


static int DoesBoardHaveBingo(int[,] board, List<int> numbers)
{
    int[,] checkBoard = board;
    int sumOfMarkedNumbers = 0;
    for (int i = 0; i < board.GetLength(0); i++)
    {
        List<int> tmp = new List<int>();
        int counter = 0;
        sumOfMarkedNumbers = 0;
        for (int j = 0; j < board.GetLength(0); j++)
        {
            tmp.Add(board[i, j]);
        }
        foreach (var number in numbers)
        {
            if (tmp.Contains(number))
            {
                sumOfMarkedNumbers += number;
                counter++;
            }
        }
        if (counter == 5)
        {
            return checkBoard.Cast<int>().ToList().Except(numbers).Sum();
        }
        else
        {
            sumOfMarkedNumbers = 0;
            counter = 0;
        }
    }
    for (int i = 0; i < board.GetLength(0); i++)
    {
        List<int> tmp = new List<int>();
        int counter = 0;
        for (int j = 0; j < board.GetLength(0); j++)
        {
            tmp.Add(board[j, i]);
        }
        foreach (var number in numbers)
        {
            if (tmp.Contains(number))
            {
                sumOfMarkedNumbers += number;
                counter++;
            }
        }
        if (counter == 5)
        {
            return checkBoard.Cast<int>().ToList().Except(numbers).Sum();
        }
        else
        {
            sumOfMarkedNumbers = 0;
            counter = 0;
        }
    }

    return 0;
}

static List<int> GetPuzzleInput(string fileName)
{
    var input = File.ReadAllLines(fileName).ToList();
    input.RemoveAt(0);
    List<int> numbers = new List<int>();
    foreach (var line in input)
    {
        if (line != String.Empty)
        {
            var numberInLine = line.Trim().Split(' ').ToList();
            numberInLine.RemoveAll(x => x == String.Empty);
            numbers.AddRange(numberInLine.Select(Int32.Parse).ToList());

        }
    }
    return numbers;
}

static List<int> GetBingoNumbers(string fileName)
{
    return File.ReadLines(fileName).First().Split(',').Select(Int32.Parse).ToList();
}