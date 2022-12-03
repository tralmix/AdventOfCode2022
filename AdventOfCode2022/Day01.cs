namespace AdventOfCode2022.Day_01
{
    public class Day01
    {
        private static readonly string FileName = "Inputs/Day01.txt";
        public static async Task Run()
        {
            Console.WriteLine("Day 1");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The elf with the most is carrying {part1Answer} calories.");

            var part2Answer = await Part2(FileName);
            Console.WriteLine($"The three elves carrying the most hold a combined {part2Answer} calories");

            Console.WriteLine();
        }

        public static async Task<long> Part1(string fileName)
        {
            var elves = await ParseFile(fileName);

            var elfCarryingTheMost = GetElfWithMostCalories(elves);

            return elfCarryingTheMost.TotalCalories;
        }
        public static async Task<long> Part2(string fileName)
        {
            var elves = await ParseFile(fileName);

            var elvesCarryingTheMost = GetThreeElvesWithMostCalories(elves);

            return elvesCarryingTheMost.Sum(e=>e.TotalCalories);
        }

        public static async Task<List<Elf>> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);
            var elves = new List<Elf>();
            var elf = new Elf();
            foreach (var line in linesOfInput)
            {
                if(string.IsNullOrEmpty(line))
                {
                    elves.Add(elf);
                    elf = new Elf();
                    continue;
                }

                elf.FoodCalories.Add(long.Parse(line));
            }

            elves.Add(elf);

            return elves;
        }

        public static Elf GetElfWithMostCalories(List<Elf> elves)
        {
            return elves.First(e => e.TotalCalories == elves.Max(o => o.TotalCalories));
        }

        public static List<Elf> GetThreeElvesWithMostCalories(List<Elf>elves)
        {
            return elves.OrderByDescending(e => e.TotalCalories).Take(3).ToList();
        }
    }

    public class Elf
    {
        public List<long> FoodCalories { get; set; } = new List<long>();

        public long TotalCalories => FoodCalories.Sum();
    }
}
