namespace Day9.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

        Assert.Equal(114, Common.Solution.PartOne(input));
    }

    [Fact]
    public void Test2()
    {
        var input = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

        Assert.Equal(2, Common.Solution.PartTwo(input));
    }
}
