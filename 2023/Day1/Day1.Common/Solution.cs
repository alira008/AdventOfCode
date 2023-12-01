namespace Day1.Common;

public static class Solution
{
    public static int Part1(string input)
    {
        var numbers = input
            .Split(Environment.NewLine)
            .Select(line =>
            {
                try
                {
                    var firstNum = line.First(c => Char.IsDigit(c));
                    var secondNum = line.Last(c => Char.IsDigit(c));
                    return int.Parse($"{firstNum}{secondNum}");
                }
                catch (System.Exception)
                {
                    return 0;
                }
            });
        return numbers.Sum();
    }

    public static int Part2(string input)
    {
        var numbers = input
            .Split(Environment.NewLine)
            .Select(line =>
            {
                try
                {
                    var numbers = new List<int>();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (char.IsDigit(line[i]))
                        {
                            numbers.Add(int.Parse(line.Substring(i, 1)));
                            continue;
                        }
                        for (int j = line.Length - 1; j >= i; j--)
                        {
                            var substr = line.Substring(i, j - i + 1);

                            bool wordNumFound = true;

                            switch (substr)
                            {
                                case "one":
                                    numbers.Add(1);
                                    break;
                                case "two":
                                    numbers.Add(2);
                                    break;
                                case "three":
                                    numbers.Add(3);
                                    break;
                                case "four":
                                    numbers.Add(4);
                                    break;
                                case "five":
                                    numbers.Add(5);
                                    break;
                                case "six":
                                    numbers.Add(6);
                                    break;
                                case "seven":
                                    numbers.Add(7);
                                    break;
                                case "eight":
                                    numbers.Add(8);
                                    break;
                                case "nine":
                                    numbers.Add(9);
                                    break;
                                default:
                                    wordNumFound = false;
                                    break;
                            }

                            if (wordNumFound)
                                break;
                        }
                    }

                    var firstNum = numbers.First();
                    var secondNum = numbers.Last();
                    return int.Parse($"{firstNum}{secondNum}");
                }
                catch (Exception)
                {
                    return 0;
                }
            });
        return numbers.Sum();
    }

    public static string GetInput(string filename)
    {
        return File.ReadAllText(filename);
    }
}
