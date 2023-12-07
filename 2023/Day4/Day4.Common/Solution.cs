namespace Day4.Common;

public static class Solution
{
    public static double PartOne(string input)
    {
        var cards = new List<double>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var numbersStart = line.IndexOf(":") + 2;
            var card = line[numbersStart..].Split("|");
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

    public static int PartTwo(string input)
    {
        return -1;
    }
}
