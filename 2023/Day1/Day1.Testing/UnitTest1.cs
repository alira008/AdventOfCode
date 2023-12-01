using Day1.Common;

namespace Day1.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input =
            @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet";

        var result = Solution.Part1(input);

        Assert.Equal(142, result);
    }

    [Fact]
    public void Test2()
    {
        var input =
            @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";

        var result = Solution.Part2(input);

        Assert.Equal(281, result);
    }
}
