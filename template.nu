def "main csharp" [day: string] {
    mkdir ($day)
    cd ($day)

    # make projects
    dotnet new sln
    dotnet new gitignore
    dotnet new console -o $"($day).Core"
    dotnet new xunit -o $"($day).Testing"
    dotnet new classlib -o $"($day).Common"

    # add projects to solution
    dotnet sln add $"($day).Core"
    dotnet sln add $"($day).Common"
    dotnet sln add $"($day).Testing"

    # add references
    dotnet add $"($day).Core" reference $"($day).Common"
    dotnet add $"($day).Testing" reference $"($day).Common"

    # clean files
    rm $"($day).Core/Program.cs"
    rm $"($day).Common/Class1.cs"
    rm $"($day).Testing/UnitTest1.cs"

    # add code to files
    # add code for solution.cs
    echo $"namespace ($day).Common;

public static class Solution
{
    public static int PartOne\(string input){

        return -1;
    }

    public static int PartTwo\(string input){
        return -1;
    }
}
" | save --raw $"($day).Common/Solution.cs"

    # add code for program.cs
    echo $"using ($day).Common;

var input1 = File.ReadAllText\(\"input1\");
var part1 = Solution.PartOne\(input1);
Console.WriteLine\($\"Part 1: {part1}\");

var input2 = File.ReadAllText\(\"input2\");
var part2 = Solution.PartTwo\(input2);
Console.WriteLine\($\"Part 2: {part2}\");
" | save --raw $"($day).Core/Program.cs"

    # add code for unit test
    echo $"namespace ($day).Testing;

public class UnitTest1
{
    [Fact]
    public void Test1\()
    {
        var input = @\"\";

        Assert.Equal\(8, Common.Solution.PartOne\(input));
    }

    [Fact]
    public void Test2\()
    {
        var input = @\"\";

        Assert.Equal\(8, Common.Solution.PartTwo\(input));
    }
}
" | save --raw $"($day).Testing/UnitTest1.cs"
}

def main [] {}
