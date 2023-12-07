namespace Day4.Common;

public static class Solution
{
    public static double PartOne(string input)
    {
        var cards = new List<double>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var numbersStart = line.IndexOf(":");
            if (numbersStart == -1)
            {
                continue;
            }
            var card = line[(numbersStart + 2)..].Split("|");
            var winningNumbers = card[0]
                .Split(" ")
                .Where(str => str.Length > 0)
                .Select(str => int.Parse(str));
            var myNumbers = card[1]
                .Split(" ")
                .Where(str => str.Length > 0)
                .Select(str => int.Parse(str));

            var wins = 0;

            foreach (var myNumber in myNumbers)
            {
                if (winningNumbers.Contains(myNumber))
                {
                    wins++;
                }
            }

            if (wins == 0)
            {
                cards.Add(0);
            }
            else
            {
                cards.Add(Math.Pow(2.0, wins - 1));
            }
        }

        return cards.Sum();
    }

    public static double PartTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var copies = new List<int>(lines.Count());
        for (var i = 0; i < lines.Count(); ++i)
        {
            copies.Add(0);
        }

        for (var i = 0; i < lines.Count(); ++i)
        {
            var line = lines[i];
            var numbersStart = line.IndexOf(":");
            if (numbersStart == -1)
            {
                continue;
            }
            var card = line[(numbersStart + 2)..].Split("|");
            var winningNumbers = card[0]
                .Split(" ")
                .Where(str => str.Length > 0)
                .Select(str => int.Parse(str));
            var myNumbers = card[1]
                .Split(" ")
                .Where(str => str.Length > 0)
                .Select(str => int.Parse(str));

            var wins = 0;

            foreach (var myNumber in myNumbers)
            {
                if (winningNumbers.Contains(myNumber))
                {
                    wins++;
                }
            }

            // increment original
            for (var j = 0; j <= wins; ++j)
            {
                copies[i + j] += 1;
            }

            // increment copies
            for (var j = 0; j < copies[i] - 1; ++j)
            {
                for (var k = 1; k <= wins; ++k)
                {
                    copies[i + k] += 1;
                }
            }
        }

        return copies.Sum();
    }
}
