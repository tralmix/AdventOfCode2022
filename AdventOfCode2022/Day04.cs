namespace AdventOfCode2022.Day_04
{
    public class Day04
    {
        private static readonly char _delimiter = ',';
        private static readonly string FileName = "Inputs/Day04.txt";
        public static async Task Run()
        {
            Console.WriteLine("Day 4");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The number of complete subsets is {part1Answer}.");
        }
        public static async Task<int> Part1(string fileName)
        {
            var pairs = await ParseFile(fileName);

            var subsets = GetPairsWithCompleteSubsets(pairs);

            return subsets.Count;
        }

        public static async Task<List<Pair>> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            var pairs = linesOfInput.Select(l=>l.Split(_delimiter))
                .Select(l=> new Pair(l[0], l[1]))
                .ToList();

            return pairs;
        }

        public static List<Pair> GetPairsWithCompleteSubsets(List<Pair> input)
        {
            return input.Where(p => p.CompleteSubsetExists).ToList();
        }
    }

    public class Pair
    {
        private readonly char _delimiter = '-';
        public Pair(string firstRange, string secondRange)
        {
            var firstPoints = firstRange.Split(_delimiter);
            var secondPoints = secondRange.Split(_delimiter);

            First = new Elf
            {
                Start = int.Parse(firstPoints.First()),
                End = int.Parse(firstPoints.Last())
            };
            Second = new Elf
            {
                Start = int.Parse(secondPoints.First()),
                End = int.Parse(secondPoints.Last())
            };
        }

        public Elf First { get; set; }
        public Elf Second { get; set; }

        public bool CompleteSubsetExists
        {
            get
            {
                if (First.Sections.All(s => Second.Sections.Contains(s)))
                    return true;

                if (Second.Sections.All(s => First.Sections.Contains(s)))
                    return true;

                return false;
            }
        }
    }

    public class Elf
    {
        public int Start { get; set; }
        public int End { get; set; }

        public int[] Sections => Enumerable.Range(Start, End - Start + 1).ToArray();
    }

}
