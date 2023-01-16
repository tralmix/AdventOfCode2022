using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day_05;

public class Day05
{
    private static readonly string FileName = "Inputs/Day05.txt";
    private static readonly Regex Spaces = new(@"^\s$");

    public static async Task Run()
    {
        Console.WriteLine("Day 5");

        var part1Answer = await Part1(FileName);
        Console.WriteLine($"The top containers are {part1Answer}.");

        var part2Answer = await Part2(FileName);
        Console.WriteLine($"The top containers are {part2Answer}.");

        Console.WriteLine();
    }

    public static async Task<string> Part1(string fileName)
    {
        var ship = await ParseFile(fileName);

        foreach (var instruction in ship.Instructions)
        {
            var source = ship.Stacks.First(s => s.Number == instruction.SourceStack);
            var target = ship.Stacks.First(s => s.Number == instruction.TargetStack);

            for (var count = instruction.CountToMove; count > 0; count--)
                target.Containers.Push(source.Containers.Pop());
        }
        string result = GetTopContainers(ship);

        return result;
    }

    public static async Task<string> Part2(string fileName)
    {
        var ship = await ParseFile(fileName);

        foreach (var instruction in ship.Instructions)
        {
            var source = ship.Stacks.First(s => s.Number == instruction.SourceStack);
            var target = ship.Stacks.First(s => s.Number == instruction.TargetStack);

            var beingMoved = new List<char>();
            for (var count = instruction.CountToMove; count > 0; count--)
                beingMoved.Insert(0, source.Containers.Pop());

            foreach (var container in beingMoved)
                target.Containers.Push(container);
        }
        string result = GetTopContainers(ship);

        return result;
    }

    public static async Task<Ship> ParseFile(string fileName)
    {
        var linesOfInput = await File.ReadAllLinesAsync(fileName);

        var inputParts = SplitInput(linesOfInput);

        var ship = BuildShip(inputParts.Item1);

        ship.Instructions = BuildInstructions(inputParts.Item2);

        return ship;
    }

    private static Tuple<List<string>, List<string>> SplitInput(params string[] input)
    {
        var shipInput = new List<string>();
        var instructionsInput = new List<string>();

        var isShipInput = true;
        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                isShipInput = false;
                continue;
            }

            if (isShipInput) shipInput.Add(line);
            else instructionsInput.Add(line);
        }

        return new Tuple<List<string>, List<string>>(shipInput, instructionsInput);
    }

    private static Ship BuildShip(List<string> input)
    {
        var ship = new Ship();

        BuildShipContainers(input, ship);

        return ship;
    }

    private static void BuildShipContainers(List<string> input, Ship ship)
    {
        var rows = BuildRows(input);

        var stacks = input.Last()
            .Where(s => !Spaces.IsMatch(s.ToString()))
            .Select(s => new ContainerStack { Number = int.Parse(s.ToString()) });

        ship.Stacks.AddRange(stacks);

        for (var rowCount = rows.Count - 1; rowCount >= 0; rowCount--)
        {
            var row = rows[rowCount];

            for (var index = 0; index < row.Count; index++)
            {
                var container = row[index];

                if (container is null) continue;

                ship.Stacks[index].Containers.Push(container.Value);
            }
        }
    }

    private static List<List<char?>> BuildRows(List<string> input)
    {
        var rows = new List<List<char?>>();

        // skip last row which is stack numbers
        foreach (var line in input.SkipLast(1))
        {
            List<char?> row = BuildRow(line);

            rows.Add(row);
        }
        return rows;
    }

    private static List<char?> BuildRow(string line)
    {
        var row = new List<char?>();

        for (var index = 0; index < line.Length; index++)
        {
            if (index % 4 != 1) continue;

            if (Spaces.IsMatch(line[index].ToString()))
                row.Add(null);
            else
                row.Add(line[index]);
        }

        return row;
    }

    private static List<Instruction> BuildInstructions(List<string> input)
    {
        var instructions = new List<Instruction>();

        foreach (var line in input)
        {
            int[] numbers = line.Split(' ')
                .Where(s => int.TryParse(s, out _))
                .Select(s => int.Parse(s))
                .ToArray();

            if (numbers.Length != 3) throw new Exception($"Invalid instruction set {line}");

            instructions.Add(new Instruction
            {
                CountToMove = numbers[0],
                SourceStack = numbers[1],
                TargetStack = numbers[2]
            });

        }
        return instructions;
    }

    private static string GetTopContainers(Ship ship)
    {
        var result = new StringBuilder();
        foreach (var stack in ship.Stacks)
        {
            if (stack.Containers.TryPeek(out var container))
                result.Append(container);
        }

        return result.ToString();
    }
}

public class Ship
{
    public List<ContainerStack> Stacks { get; set; } = new();

    public List<Instruction> Instructions { get; set; } = new();
}

public class ContainerStack
{
    public int Number { get; set; }
    public Stack<char> Containers { get; set; } = new();
}

public class Instruction
{
    public int CountToMove { get; set; }
    public int SourceStack { get; set; }
    public int TargetStack { get; set; }
}