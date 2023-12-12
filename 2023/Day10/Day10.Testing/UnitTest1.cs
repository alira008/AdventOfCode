namespace Day10.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = @"-L|F7
7S-7|
L|7||
-L-J|
L|-JF";

        Assert.Equal(4, Common.Solution.PartOne(input));
    }

    // [Fact]
    public void Test2()
    {
        var input = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";

        Assert.Equal(8, Common.Solution.PartOne(input));
    }

    // [Fact]
    public void Test3()
    {
        var input = @"";

        Assert.Equal(8, Common.Solution.PartTwo(input));
    }
}
