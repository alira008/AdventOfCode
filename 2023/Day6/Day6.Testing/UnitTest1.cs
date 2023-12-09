namespace Day6.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input =
            @"Time:      7  15   30
Distance:  9  40  200";

        Assert.Equal(288, Common.Solution.PartOne(input));
    }

    [Fact]
    public void Test2()
    {
        var input = @"Time:      7  15   30
Distance:  9  40  200";

        Assert.Equal(71503, Common.Solution.PartTwo(input));
    }
}
