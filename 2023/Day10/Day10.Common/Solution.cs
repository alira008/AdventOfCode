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
        StartingPoint,
        Oh,
        Aye
    }

    static bool IsPipe(List<List<Pipe>> pipes, Tuple<int, int> position)
    {
        return position.Item1 >= 0 && position.Item1 < pipes.Count && position.Item2 >= 0 && position.Item2 < pipes[position.Item1].Count;
    }

    static Pipe? GetPipe(List<List<Pipe>> pipes, Tuple<int, int> position)
    {
        return IsPipe(pipes, position) ? pipes[position.Item1][position.Item2] : null;
    }

    static List<Tuple<int, int>> GetNextPipe(List<List<Pipe>> pipes, Tuple<int, int> currentPosition)
    {
        var nextPipes = new List<Tuple<int, int>>();
        // check above, below, left, right
        var above = Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
        var below = Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
        var left = Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
        var right = Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);

        var currentPipe = GetPipe(pipes, currentPosition);
        switch(currentPipe)
        {
           case Pipe.Vertical:
               if (GetPipe(pipes, above) == Pipe.NorthWest ||
                       GetPipe(pipes, above) == Pipe.NorthEast ||
                       GetPipe(pipes, above) == Pipe.Vertical ||
                       GetPipe(pipes, above) == Pipe.StartingPoint)
               {
                   nextPipes.Add(above);
               }
               if (GetPipe(pipes, below) == Pipe.SouthWest ||
                       GetPipe(pipes, below) == Pipe.SouthEast ||
                       GetPipe(pipes, below) == Pipe.Vertical ||
                       GetPipe(pipes, below) == Pipe.StartingPoint)
               {
                   nextPipes.Add(below);
               }
               break;
            case Pipe.Horizontal:
               if (GetPipe(pipes, left) == Pipe.NorthEast ||
                       GetPipe(pipes, left) == Pipe.SouthEast ||
                       GetPipe(pipes, left) == Pipe.Horizontal ||
                       GetPipe(pipes, left) == Pipe.StartingPoint)
               {
                   nextPipes.Add(left);
               }
               if (GetPipe(pipes, right) == Pipe.NorthWest ||
                       GetPipe(pipes, right) == Pipe.SouthWest ||
                       GetPipe(pipes, right) == Pipe.Horizontal ||
                       GetPipe(pipes, right) == Pipe.StartingPoint)
               {
                   nextPipes.Add(right);
               }
               break;
            case Pipe.NorthEast:
               if (GetPipe(pipes, below) == Pipe.Vertical ||
                       GetPipe(pipes, below) == Pipe.SouthEast ||
                       GetPipe(pipes, below) == Pipe.SouthWest ||
                       GetPipe(pipes, below) == Pipe.StartingPoint)
               {
                   nextPipes.Add(below);
               }
               if (GetPipe(pipes, right) == Pipe.Horizontal ||
                       GetPipe(pipes, right) == Pipe.NorthWest ||
                       GetPipe(pipes, right) == Pipe.SouthWest ||
                       GetPipe(pipes, right) == Pipe.StartingPoint)
               {
                   nextPipes.Add(right);
               }
               break;
            case Pipe.NorthWest:
               if (GetPipe(pipes, left) == Pipe.Horizontal ||
                       GetPipe(pipes, left) == Pipe.SouthEast ||
                       GetPipe(pipes, left) == Pipe.NorthEast ||
                       GetPipe(pipes, left) == Pipe.StartingPoint)
               {
                   nextPipes.Add(left);
               }
               if (GetPipe(pipes, below) == Pipe.SouthWest ||
                       GetPipe(pipes, below) == Pipe.SouthEast ||
                       GetPipe(pipes, below) == Pipe.Vertical ||
                       GetPipe(pipes, below) == Pipe.StartingPoint)
               {
                   nextPipes.Add(below);
               }
               break;
            case Pipe.SouthEast:
               if (GetPipe(pipes, above) == Pipe.Vertical ||
                       GetPipe(pipes, above) == Pipe.NorthWest ||
                       GetPipe(pipes, above) == Pipe.NorthEast ||
                       GetPipe(pipes, above) == Pipe.StartingPoint)
               {
                   nextPipes.Add(above);
               }
               if (GetPipe(pipes, right) == Pipe.NorthWest ||
                       GetPipe(pipes, right) == Pipe.SouthWest ||
                       GetPipe(pipes, right) == Pipe.Horizontal ||
                       GetPipe(pipes, right) == Pipe.StartingPoint)
               {
                   nextPipes.Add(right);
               }
               break;
            case Pipe.SouthWest:
               if (GetPipe(pipes, left) == Pipe.NorthEast ||
                       GetPipe(pipes, left) == Pipe.SouthEast ||
                       GetPipe(pipes, left) == Pipe.Horizontal ||
                       GetPipe(pipes, left) == Pipe.StartingPoint)
               {
                   nextPipes.Add(left);
               }
               if (GetPipe(pipes, above) == Pipe.NorthEast ||
                       GetPipe(pipes, above) == Pipe.NorthWest ||
                       GetPipe(pipes, above) == Pipe.Vertical ||
                       GetPipe(pipes, above) == Pipe.StartingPoint)
               {
                   nextPipes.Add(above);
               }
               break;
            case Pipe.StartingPoint:
               if (GetPipe(pipes, left) == Pipe.NorthEast ||
                       GetPipe(pipes, left) == Pipe.Horizontal ||
                       GetPipe(pipes, left) == Pipe.SouthEast)
               {
                   nextPipes.Add(left);
               }
               if (GetPipe(pipes, right) == Pipe.NorthWest ||
                       GetPipe(pipes, right) == Pipe.SouthWest ||
                       GetPipe(pipes, right) == Pipe.Horizontal)
               {
                   nextPipes.Add(right);
               }
               if (GetPipe(pipes, below) == Pipe.SouthEast ||
                       GetPipe(pipes, below) == Pipe.SouthWest ||
                       GetPipe(pipes, below) == Pipe.Vertical)
               {
                   nextPipes.Add(below);
               }
               if (GetPipe(pipes, above) == Pipe.NorthWest ||
                       GetPipe(pipes, above) == Pipe.NorthEast ||
                       GetPipe(pipes, above) == Pipe.Vertical)
               {
                   nextPipes.Add(above);
               }
               break;
        }

        return nextPipes;
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
                                    'L' => Pipe.SouthEast,
                                    'J' => Pipe.SouthWest,
                                    '7' => Pipe.NorthWest,
                                    'F' => Pipe.NorthEast,
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
        var prevPipe = path.Last();
        bool pathConnected = false;
        Tuple<int, int> currentPoint = startingPoint;
        while (!pathConnected)
        {
            var nextPipes = GetNextPipe(lines, currentPoint);

            if(nextPipes.Count < 2)
            {
                Console.WriteLine($"Next Pipes: {string.Join(", ", nextPipes)} Current Point: {currentPoint} Current Pipe: {GetPipe(lines, currentPoint)}");
                throw new Exception("Invalid amount of pipes");
            }

            // check if nextPipes contains prevPipe
            if(nextPipes[0].Item1 == prevPipe.Item1 && nextPipes[0].Item2 == prevPipe.Item2)
            {
                if(GetPipe(lines, nextPipes[1]) == Pipe.StartingPoint)
                {
                    pathConnected = true;
                    break;
                }
                path.Add(nextPipes[1]);
                prevPipe = currentPoint;
                currentPoint = nextPipes[1];
            }
            else 
            {
                if(GetPipe(lines, nextPipes[0]) == Pipe.StartingPoint)
                {
                    pathConnected = true;
                    break;
                }
                path.Add(nextPipes[0]);
                prevPipe = currentPoint;
                currentPoint = nextPipes[0];
            }
        }

        int steps = path.Count / 2;

        return steps;
    }

    public static int PartTwo(string input)
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
                                            'L' => Pipe.SouthEast,
                                            'J' => Pipe.SouthWest,
                                            '7' => Pipe.NorthWest,
                                            'F' => Pipe.NorthEast,
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
        var prevPipe = path.Last();
        bool pathConnected = false;
        Tuple<int, int> currentPoint = startingPoint;
        while (!pathConnected)
        {
            var nextPipes = GetNextPipe(lines, currentPoint);

            if(nextPipes.Count < 2)
            {
                Console.WriteLine($"Next Pipes: {string.Join(", ", nextPipes)} Current Point: {currentPoint} Current Pipe: {GetPipe(lines, currentPoint)}");
                throw new Exception("Invalid amount of pipes");
            }

            // check if nextPipes contains prevPipe
            if(nextPipes[0].Item1 == prevPipe.Item1 && nextPipes[0].Item2 == prevPipe.Item2)
            {
                if(GetPipe(lines, nextPipes[1]) == Pipe.StartingPoint)
                {
                    pathConnected = true;
                    break;
                }
                path.Add(nextPipes[1]);
                prevPipe = currentPoint;
                currentPoint = nextPipes[1];
            }
            else 
            {
                if(GetPipe(lines, nextPipes[0]) == Pipe.StartingPoint)
                {
                    pathConnected = true;
                    break;
                }
                path.Add(nextPipes[0]);
                prevPipe = currentPoint;
                currentPoint = nextPipes[0];
            }
        }

        // Green's theorem to calculate the area of a complex curve
        var area = 0;
        var prev = path.Last();
        foreach(var node in path)
        {
            area += (node.Item1 - prev.Item1) * (node.Item2 + prev.Item2);
            prev = node;
        }

        area = Math.Abs(area) / 2;

        // Pick's theorem to calculate the area of a polygon
        // A = i + b / 2 - 1
        // I is the number of lattice points inside the polygon,
        // B is the number of lattice points on the boundaries of the polygon.
        // so, I = A - B / 2 + 1
        return area - path.Count / 2 + 1;
    }
}
