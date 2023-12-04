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
}

def main [] {}
