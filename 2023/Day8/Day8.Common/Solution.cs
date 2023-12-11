namespace Day8.Common;

public static class Solution
{
    public static int PartOne(string input)
    {
        var lines = input.Split(Environment.NewLine).Where(x => !string.IsNullOrWhiteSpace(x));

        bool initPath = false;
        string currentNode = string.Empty;
        Dictionary<string, (string, string)> maps = new();
        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(" = ");
            var key = parts[0];
            var value = parts[1].TrimStart('(').TrimEnd(')').Split(", ");

            if (!initPath && key == "AAA")
            {
                currentNode = key;
                initPath = true;
            }
            maps.Add(key, (value[0], value[1]));
        }

        var instructions = lines.First();
        var currentInstruction = 0;
        var steps = 0;
        while (currentNode != "ZZZ")
        {
            if (currentInstruction >= instructions.Length)
            {
                currentInstruction = 0;
            }

            var (left, right) = maps[currentNode];

            if (instructions[currentInstruction] == 'R')
            {
                currentNode = right;
            }
            else
            {
                currentNode = left;
            }

            steps += 1;
            currentInstruction += 1;
        }

        return steps;
    }

    public static int PartTwo(string input)
    {
        var lines = input.Split(Environment.NewLine).Where(x => !string.IsNullOrWhiteSpace(x));

        List<string> currentNodes = new();
        Dictionary<string, (string, string)> maps = new();
        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(" = ");
            var key = parts[0];
            var value = parts[1].TrimStart('(').TrimEnd(')').Split(", ");

            if (key.Last() == 'A')
            {
                currentNodes.Add(key);
            }
            maps.Add(key, (value[0], value[1]));
        }

        var instructions = lines.First();
        var currentInstruction = 0;
        var steps = 0;
        while (currentNodes.Where(node => node.Last() == 'Z').Count() != currentNodes.Count())
        {
            if (currentInstruction >= instructions.Length)
            {
                currentInstruction = 0;
            }

            for (var i = 0; i < currentNodes.Count(); ++i)
            {
                var node = currentNodes[i];
                var (left, right) = maps[node];

                if (instructions[currentInstruction] == 'R')
                {
                    currentNodes[i] = right;
                }
                else
                {
                    currentNodes[i] = left;
                }
            }
            steps += 1;
            currentInstruction += 1;
        }

        return steps;
    }
}
