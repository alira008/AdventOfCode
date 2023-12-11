namespace Day9.Common;

public static class Solution
{
    public static int PartOne(string input)
    {
        return input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                List<List<int>> sequences = [line.Split(" ").Select(c => int.Parse(c)).ToList()];

                // fill until last sequence is filled with zeros
                var sequenceIndex = 0;
                while(sequences.Last().Any())
                {
                    List<int> sequence = new();
                    for(var i = 1; i < sequences[sequenceIndex].Count(); i++)
                    {
                        sequence.Add(sequences[sequenceIndex][i] - sequences[sequenceIndex][i - 1]);
                    }
                    sequences.Add(sequence);
                    ++sequenceIndex;
                }

                int nextValue = 0;
                while(sequenceIndex != 0)
                {
                    nextValue += sequences[sequenceIndex - 1].Last();
                    --sequenceIndex;
                }
                return nextValue;
            })
            .Sum();
    }

    public static int PartTwo(string input)
    {
        return input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                List<List<int>> sequences = [line.Split(" ").Select(c => int.Parse(c)).ToList()];

                // fill until last sequence is filled with zeros
                var sequenceIndex = 0;
                while(sequences.Last().Any())
                {
                    List<int> sequence = new();
                    var currentSequence = sequences[sequenceIndex];
                    for(var i = currentSequence.Count() - 2; i >= 0; --i)
                    {
                        sequence.Add(currentSequence[i + 1] - currentSequence[i]);
                    }
                    sequence.Reverse();
                    sequences.Add(sequence);
                    ++sequenceIndex;
                }

                int nextValue = 0;
                while(sequenceIndex != 0)
                {
                    nextValue = sequences[sequenceIndex - 1].First() - nextValue;
                    --sequenceIndex;
                }
                return nextValue;
            })
            .Sum();
    }
}
