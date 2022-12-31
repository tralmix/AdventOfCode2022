namespace AdventOfCode2022.Day_07
{
    public class Day07
    {
        private static readonly string FileName = "Inputs/Day07.txt";

        public static async Task Run()
        {
            Console.WriteLine("Day 7");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The top containers are {part1Answer}.");

            var part2Answer = await Part2(FileName);
            Console.WriteLine($"The top containers are {part2Answer}.");

            Console.WriteLine();
        }
        public static async Task<int> Part1(string fileName)
        {
            var file = await ParseFile(fileName);
            return int.MinValue;

        }
        public static async Task<int> Part2(string fileName)
        {
            var file = await ParseFile(fileName);
            return int.MinValue;
        }
        public static async Task<object> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            foreach(var line in linesOfInput)
            {
                var parsedLine = ParseLine(line);
            }
            return string.Empty;
        }

        public static Input ParseLine(string line)
        {

        }
    }

    public abstract class Input
    {

    }
}
