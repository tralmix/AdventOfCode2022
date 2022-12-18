namespace AdventOfCode2022.Day_05
{
    public class Day05
    {
        private static readonly string FileName = "Inputs/Day05.txt";

        public static async Task Run()
        {
            Console.WriteLine("Day 5");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The top containers are {part1Answer}.");

            Console.WriteLine();
        }

        public static async Task<string> Part1(string fileName)
        {
            var ship = await ParseFile(fileName);

            return string.Empty;
        }

        public static async Task<Ship> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            return new Ship();
        }
    }

    public class Ship
    {
        public List<ContainerStack> Stacks { get; set; } = new();
    }

    public class ContainerStack
    {
        public Stack<char> Containers { get; set; } = new();
    }
}
