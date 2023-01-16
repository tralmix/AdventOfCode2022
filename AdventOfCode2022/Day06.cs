namespace AdventOfCode2022.Day_06;
public class Day06
{
    private static readonly string FileName = "Inputs/Day06.txt";
    private const int PartOneBufferSize = 4;
    private const int PartTwoBufferSize = 14;

    public static async Task Run()
    {
        Console.WriteLine("Day 6");

        var part1Answer = await Part1(FileName);
        Console.WriteLine($"The signal marker is at {part1Answer}.");

        var part2Answer = await Part2(FileName);
        Console.WriteLine($"The message marker is at {part2Answer}.");

        Console.WriteLine();
    }
    public static async Task<int> Part1(string fileName)
    {
        var input = await ParseFile(fileName);
        int marker = FindSignalMarker(input);
        return marker;
    }

    public static async Task<int> Part2(string fileName)
    {
        var input = await ParseFile(fileName);
        int marker = FindMessageMarker(input);
        return marker;
    }

    public static async Task<string> ParseFile(string fileName)
    {
        var linesOfInput = await File.ReadAllLinesAsync(fileName);

        return linesOfInput[0];
    }

    public static int FindSignalMarker(string input)
    {
        return FindMarker(input, PartOneBufferSize);
    }

    public static int FindMessageMarker(string input)
    {
        return FindMarker(input, PartTwoBufferSize);
    }

    private static int FindMarker(string input, int bufferSize)
    {
        var characterCount = bufferSize;
        var dictionary = input.Take(characterCount)
            .GroupBy(b => b).ToDictionary(k => k.Key, v => v.Count());

        while (true)
        {
            if (dictionary.Count() == bufferSize)
                break;

            if (characterCount > input.Length)
                throw new IndexOutOfRangeException("Character counter exceeded input length");

            var character = input[characterCount];

            ReduceOrRemoveFromDictionary(dictionary, input[characterCount - bufferSize]);

            if (!dictionary.TryAdd(character, 1))
                dictionary[character]++;

            characterCount++;
        }

        return characterCount;

    }

    private static void ReduceOrRemoveFromDictionary(Dictionary<char, int> dictionary, char character)
    {
        if (dictionary.TryGetValue(character, out var count))
            if (count == 1) dictionary.Remove(character);
            else dictionary[character]--;
    }
}