namespace Day2.Common;

public static class Solution
{
    class Hand
    {
        public int Blue { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
    }

    public static int PartOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var games = new List<List<Hand>>();

        foreach (var line in lines)
        {
            // get the index of the first the first input after the game number
            var inputIndex = line.IndexOf(':') + 1;

            string colorAmountString = "";
            string colorString = "";
            var hand = new Hand();
            var hands = new List<Hand>();

            for (var i = inputIndex; i < line.Count(); ++i)
            {
                // character tells us how many we have of a color
                if (char.IsDigit(line[i]))
                {
                    colorAmountString += line[i];
                }

                // character is the color
                if (char.IsLetter(line[i]))
                {
                    colorString += line[i];
                }

                // if we hit a comma, we will be looking at a different color
                if (line[i] == ',' || line[i] == ';' || i == line.Count() - 1)
                {
                    // parse the color amount
                    switch (colorString)
                    {
                        case "blue":
                            hand.Blue = int.Parse(colorAmountString);
                            break;
                        case "red":
                            hand.Red = int.Parse(colorAmountString);
                            break;
                        case "green":
                            hand.Green = int.Parse(colorAmountString);
                            break;
                    }

                    // reset values
                    colorAmountString = "";
                    colorString = "";
                }

                // this means we are at the end of the hand
                if (line[i] == ';' || i == line.Count() - 1)
                {
                    hands.Add(hand);
                    hand = new Hand();
                }
            }

            if (hands.Count() > 0)
            {
                games.Add(hands);
            }
        }

        var sum = 0;
        for (var i = 0; i < games.Count(); ++i)
        {
            if (games[i].Where(hand => hand.Red > 12).Any())
            {
                continue;
            }
            if (games[i].Where(hand => hand.Green > 13).Any())
            {
                continue;
            }
            if (games[i].Where(hand => hand.Blue > 14).Any())
            {
                continue;
            }

            sum += i + 1;
        }
        return sum;
    }

    public static int PartTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var games = new List<List<Hand>>();

        foreach (var line in lines)
        {
            // get the index of the first the first input after the game number
            var inputIndex = line.IndexOf(':') + 1;

            string colorAmountString = "";
            string colorString = "";
            var hand = new Hand();
            var hands = new List<Hand>();

            for (var i = inputIndex; i < line.Count(); ++i)
            {
                // character tells us how many we have of a color
                if (char.IsDigit(line[i]))
                {
                    colorAmountString += line[i];
                }

                // character is the color
                if (char.IsLetter(line[i]))
                {
                    colorString += line[i];
                }

                // if we hit a comma, we will be looking at a different color
                if (line[i] == ',' || line[i] == ';' || i == line.Count() - 1)
                {
                    // parse the color amount
                    switch (colorString)
                    {
                        case "blue":
                            hand.Blue = int.Parse(colorAmountString);
                            break;
                        case "red":
                            hand.Red = int.Parse(colorAmountString);
                            break;
                        case "green":
                            hand.Green = int.Parse(colorAmountString);
                            break;
                    }

                    // reset values
                    colorAmountString = "";
                    colorString = "";
                }

                // this means we are at the end of the hand
                if (line[i] == ';' || i == line.Count() - 1)
                {
                    hands.Add(hand);
                    hand = new Hand();
                }
            }

            if (hands.Count() > 0)
            {
                games.Add(hands);
            }
        }

        var sum = 0;
        foreach (var hands in games)
        {
            int greenMax = hands.Max(hand => hand.Green);
            int redMax = hands.Max(hand => hand.Red);
            int blueMax = hands.Max(hand => hand.Blue);
            
            sum += greenMax * redMax * blueMax;
        }
        return sum;
    }
}
