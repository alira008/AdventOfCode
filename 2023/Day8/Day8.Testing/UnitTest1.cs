namespace Day8.Testing;

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

    [Fact]
    public void Test2()
    {
        var input = @"";

        Assert.Equal(8, Common.Solution.PartTwo(input));
    }
}
