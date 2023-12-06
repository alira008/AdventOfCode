namespace Day3.Testing;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
";

        Assert.Equal(4361, Common.Solution.PartOne(input));
    }

    [Fact]
    public void Test2()
    {
        var input = @"467..114..
...*......
..35..633.
...2..#...
617*4....
...3.+.58.
..592.....
...1......
...$.*....
..755.598.";

        Assert.Equal(467835, Common.Solution.PartTwo(input));
    }
}
