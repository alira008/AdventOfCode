namespace Day11.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = @"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....";

        Assert.Equal(8, Common.Solution.PartOne(input));
    }

    [Fact]
    public void Test2()
    {
        var input = @"";

        Assert.Equal(8, Common.Solution.PartTwo(input));
    }
}
