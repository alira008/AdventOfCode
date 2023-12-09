namespace Day6.Common;

public static class Solution
{
    public static int PartOne(string input)
    {
        var numbers = input
            .Split(Environment.NewLine)
            .Where(line => line.Count() > 0)
            .Select(line =>
            {
                int colonIndex = line.IndexOf(':') + 1;
                return line[colonIndex..]
                    .Trim()
                    .Split(" ")
                    .Where(line => line.Count() > 0)
                    .Select(str => int.Parse(str));
            });

        var times = numbers.First().ToList();
        var distances = numbers.Last().ToList();
        var waysToWinForTimes = new List<int>();

        for (int i = 0; i < times.Count() && i < distances.Count(); i++)
        {
            var time = times[i];
            var distance = distances[i];
            var waysToWin = 0;
            for (int speed = 0; speed < time; ++speed)
            {
                var calculatedDistance = Math.Abs(time - speed) * speed;
                if (calculatedDistance > distance)
                {
                    waysToWin += 1;
                }
            }
            waysToWinForTimes.Add(waysToWin);
        }

        return waysToWinForTimes.Aggregate((acc, curr) => acc * curr);
    }

    public static int PartTwo(string input)
    {
        var numbers = input
            .Split(Environment.NewLine)
            .Where(line => line.Count() > 0)
            .Select(line =>
            {
                int colonIndex = line.IndexOf(':') + 1;
                return long.Parse(line[colonIndex..].Trim().Replace(" ", ""));
            });

        var time = numbers.First();
        var distance = numbers.Last();

        var waysToWin = 0;
        for (int speed = 0; speed < time; ++speed)
        {
            var calculatedDistance = Math.Abs(time - speed) * speed;
            if (calculatedDistance > distance)
            {
                waysToWin += 1;
            }
        }

        return waysToWin;
    }
}
