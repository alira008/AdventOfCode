namespace Day10.Common;

public static class Solution
{
    enum Pipe
    {
        Vertical,
        Horizontal,
        NorthEast,
        NorthWest,
        SouthWest,
        SouthEast,
        Ground,
        StartingPoint
    }

    public static int PartOne(string input)
    {
        var lines = input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(
                line =>
                    line.Select(
                            c =>
                                c switch
                                {
                                    '|' => Pipe.Vertical,
                                    '-' => Pipe.Horizontal,
                                    'L' => Pipe.NorthEast,
                                    'J' => Pipe.NorthWest,
                                    '7' => Pipe.SouthWest,
                                    'F' => Pipe.SouthWest,
                                    '.' => Pipe.Ground,
                                    'S' => Pipe.StartingPoint,
                                    _ => throw new Exception("Invalid character")
                                }
                        )
                        .ToList()
            )
            .ToList();

        Tuple<int, int> startingPoint = new(0, 0);
        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var startingPointIndex = line.IndexOf(Pipe.StartingPoint);
            if (startingPointIndex != -1)
            {
                startingPoint = new Tuple<int, int>(i, startingPointIndex);
                break;
            }
        }

        List<Tuple<int, int>> path = [startingPoint];
        bool pathConnected = false;
        Tuple<int, int> currentPoint = startingPoint;
        while (!pathConnected)
        {
            // check above, below, left, right
            // above
            Console.WriteLine($"Current point: {currentPoint}");
            Console.WriteLine($"Points: {string.Join(", ", path)}");
            if (
                currentPoint.Item1 - 1 >= 0
                && !path.Contains(new Tuple<int, int>(currentPoint.Item1 - 1, currentPoint.Item2))
                && (
                    lines[currentPoint.Item1 - 1][currentPoint.Item2] == Pipe.SouthEast
                    || lines[currentPoint.Item1 - 1][currentPoint.Item2] == Pipe.Vertical
                    || lines[currentPoint.Item1 - 1][currentPoint.Item2] == Pipe.SouthWest
                )
            )
            {
                Console.WriteLine(
                    $"Current point: {currentPoint} New point: {new Tuple<int, int>(currentPoint.Item1 - 1, currentPoint.Item2)} Last: {path.Last()}"
                );
                currentPoint = new Tuple<int, int>(currentPoint.Item1 - 1, currentPoint.Item2);
                path.Add(currentPoint);
                continue;
            }
            // below
            if (
                currentPoint.Item1 + 1 < lines.Count
                && !path.Contains(new Tuple<int, int>(currentPoint.Item1 + 1, currentPoint.Item2))
                && (
                    lines[currentPoint.Item1 + 1][currentPoint.Item2] == Pipe.NorthEast
                    || lines[currentPoint.Item1 + 1][currentPoint.Item2] == Pipe.Vertical
                    || lines[currentPoint.Item1 + 1][currentPoint.Item2] == Pipe.NorthWest
                )
            )
            {
                currentPoint = new Tuple<int, int>(currentPoint.Item1 + 1, currentPoint.Item2);
                path.Add(currentPoint);
                continue;
            }
            // left
            if (
                currentPoint.Item2 - 1 >= 0
                && lines[currentPoint.Item1][currentPoint.Item2] == Pipe.NorthEast
                && !path.Contains(new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 - 1))
                && (
                    lines[currentPoint.Item1][currentPoint.Item2 - 1] == Pipe.SouthEast
                    || lines[currentPoint.Item1][currentPoint.Item2 - 1] == Pipe.Horizontal
                    || lines[currentPoint.Item1][currentPoint.Item2 - 1] == Pipe.NorthEast
                )
            )
            {
                currentPoint = new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 - 1);
                path.Add(currentPoint);
                continue;
            }
            // right
            if (
                currentPoint.Item2 + 1 < lines[currentPoint.Item1].Count
                && !path.Contains(new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 + 1))
                && (
                    lines[currentPoint.Item1][currentPoint.Item2 + 1] == Pipe.SouthWest
                    || lines[currentPoint.Item1][currentPoint.Item2 + 1] == Pipe.Horizontal
                    || lines[currentPoint.Item1][currentPoint.Item2 + 1] == Pipe.NorthWest
                )
            )
            {
                currentPoint = new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 + 1);
                path.Add(currentPoint);
                continue;
            }

            // above
            if (
                currentPoint.Item1 - 1 >= 0
                && path.Last() != new Tuple<int, int>(currentPoint.Item1 - 1, currentPoint.Item2)
                && lines[currentPoint.Item1 - 1][currentPoint.Item2] == Pipe.StartingPoint
            )
            {
                pathConnected = true;
            }
            // below
            if (
                currentPoint.Item1 + 1 < lines.Count
                && path.Last() != new Tuple<int, int>(currentPoint.Item1 + 1, currentPoint.Item2)
                && lines[currentPoint.Item1 + 1][currentPoint.Item2] == Pipe.StartingPoint
            )
            {
                pathConnected = true;
            }
            // left
            if (
                currentPoint.Item2 - 1 >= 0
                && path.Last() != new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 - 1)
                && lines[currentPoint.Item1][currentPoint.Item2 - 1] == Pipe.StartingPoint
            )
            {
                pathConnected = true;
            }
            // right
            if (
                currentPoint.Item2 + 1 < lines[currentPoint.Item1].Count
                && path.Last() != new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 + 1)
                && lines[currentPoint.Item1][currentPoint.Item2 + 1] == Pipe.StartingPoint
            )
            {
                pathConnected = true;
            }
        }

        Console.WriteLine($"Points: {string.Join(", ", path)}");

        return -1;
    }

    public static int PartTwo(string input)
    {
        return -1;
    }
}
