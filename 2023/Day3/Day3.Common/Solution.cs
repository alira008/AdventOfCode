namespace Day3.Common;

public static class Solution
{
    public static int PartOne(string input)
    {
        var grid = new List<List<char>>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            if (line.Length == 0)
            {
                continue;
            }

            var row = new List<char>();
            foreach (var c in line)
            {
                if (c == '.')
                {
                    row.Add(' ');
                }
                else
                {
                    row.Add(c);
                }
            }
            grid.Add(row);
        }

        var numbers = new List<int>();
        var strNumber = string.Empty;
        var touchingSymbol = false;
        for (var i = 0; i < grid.Count(); ++i)
        {
            for (var j = 0; j < grid[i].Count(); ++j)
            {
                if (char.IsDigit(grid[i][j]))
                {
                    strNumber += grid[i][j];

                    // check if surrounding cells have a symbol
                    for (var k = -1; k < 2; ++k)
                    {
                        // check if out of bounds
                        if (i + k < 0 || i + k >= grid.Count())
                        {
                            continue;
                        }

                        for (var l = -1; l < 2; ++l)
                        {
                            // check if out of bounds
                            if (j + l < 0 || j + l >= grid[i].Count())
                            {
                                continue;
                            }

                            if (
                                !char.IsWhiteSpace(grid[i + k][j + l])
                                && !char.IsDigit(grid[i + k][j + l])
                            )
                            {
                                touchingSymbol = true;
                            }
                        }
                    }
                }

                if (!char.IsDigit(grid[i][j]))
                {
                    if (touchingSymbol)
                    {
                        numbers.Add(int.Parse(strNumber));
                    }
                    touchingSymbol = false;
                    strNumber = string.Empty;
                }
            }
        }

        return numbers.Sum();
    }

    public static int PartTwo(string input)
    {
        var grid = new List<List<char>>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            if (line.Length == 0)
            {
                continue;
            }

            var row = new List<char>();
            foreach (var c in line)
            {
                if (c == '.')
                {
                    row.Add(' ');
                }
                else
                {
                    row.Add(c);
                }
            }
            grid.Add(row);
        }

        var numbers = new List<int>();
        var numbersToMultiply = new List<int>();
        for (var i = 0; i < grid.Count(); ++i)
        {
            for (var j = 0; j < grid[i].Count(); ++j)
            {
                if (grid[i][j] == '*')
                {
                    var numbersConnected = 0;
                    List<(int, int)> connectedChars = new();

                    // check if surrounding cells if we have two numbers connected to multiply symbol
                    for (var k = -1; k < 2; ++k)
                    {
                        // check if out of bounds
                        if (i + k < 0 || i + k >= grid.Count())
                        {
                            continue;
                        }

                        for (var l = -1; l < 2; ++l)
                        {
                            // check if out of bounds
                            if (j + l < 0 || j + l >= grid[i].Count())
                            {
                                continue;
                            }

                            if (char.IsDigit(grid[i + k][j + l]))
                            {
                                var isAlreadyConnected = false;

                                foreach (var (x, y) in connectedChars)
                                {
                                    if (
                                        (x == i + k && y == j + l + 1)
                                        || (x == i + k && y == j + l + 2 && char.IsDigit(grid[i + k][j + l + 1]))
                                        || (x == i + k && y == j + l - 2 && char.IsDigit(grid[i + k][j + l - 1]))
                                        || (x == i + k && y == j + l - 1)
                                    )
                                    {
                                        isAlreadyConnected = true;
                                        break;
                                    }
                                }

                                if (!isAlreadyConnected)
                                {
                                    numbersConnected++;
                                    connectedChars.Add((i + k, j + l));
                                }
                            }
                        }
                    }

                    if (numbersConnected != 2)
                    {
                        continue;
                    }

                    foreach (var (x, y) in connectedChars)
                    {
                        var number = grid[x][y].ToString();
                        // check left side
                        int left = 1;
                        while (y - left >= 0 && char.IsDigit(grid[x][y - left]))
                        {
                            number = grid[x][y - left] + number;
                            left++;
                        }
                        // check right side
                        int right = 1;
                        while (y + right < grid[x].Count() && char.IsDigit(grid[x][y + right]))
                        {
                            number += grid[x][y + right];
                            right++;
                        }
                        numbersToMultiply.Add(int.Parse(number));
                    }

                    numbers.Add(numbersToMultiply[0] * numbersToMultiply[1]);
                    numbersToMultiply.Clear();
                }
            }
        }

        return numbers.Sum();
    }
}
