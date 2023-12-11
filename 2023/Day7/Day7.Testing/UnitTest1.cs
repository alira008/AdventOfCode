namespace Day7.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

        Assert.Equal(6440, Common.Solution.PartOne(input));
    }

    // [Fact]
    public void Test2()
    {
        var input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

        Assert.Equal(5905, Common.Solution.PartTwo(input));
    }

    [Fact]
    public void Test3()
    {
        var input = @"J2345 100
JJ345 200
JJJ45 300
JJJJ5 400
JJJJJ 500";

        Assert.Equal(5500, Common.Solution.PartTwo(input));
    }
}
