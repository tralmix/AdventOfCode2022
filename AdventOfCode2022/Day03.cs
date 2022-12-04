﻿namespace AdventOfCode2022.Day_03
{
    public class Day03
    {
        private static readonly string FileName = "Inputs/Day03.txt";

        private static IDictionary<char, int> Priority { get => priority.Value; }
        private static Lazy<IDictionary<char, int>> priority = new(() =>
        {
            var keys = Enumerable.Range('a', 'z' - 'a' + 1).Select(x=>(char)x).ToList();
            keys.AddRange(Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => (char)x));

            var values = Enumerable.Range(1, 52);

            return keys.Zip(values).ToDictionary(x=> x.First, y=>y.Second);
        });

        public static async Task Run()
        {
            Console.WriteLine("Day 3");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The priority sum of common items in each sack is {part1Answer}.");

            //var part2Answer = await Part2(FileName);
            //Console.WriteLine($"The score for all rounds is {part2Answer}.");

            Console.WriteLine();
        }

        public static async Task<int> Part1(string fileName)
        {
            var rucksacks = await ParseFile(fileName);

            return rucksacks.Sum(r => Priority[r.CommonItem]);
        }

        public static async Task<List<Rucksack>> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            var results = linesOfInput.Select(BuildRucksack).ToList();

            return results;
        }

        public static Rucksack BuildRucksack(string input)
        {
            return new Rucksack
            {
                PocketOne = input[..((int)input.Length / 2)].ToList(),
                PocketTwo = input[(input.Length / 2)..].ToList(),
            };
        }
    }

    public class Rucksack
    {
        public List<char> PocketOne { get; set; } = new();
        public List<char> PocketTwo { get; set; } = new ();

        public char CommonItem => PocketOne.FirstOrDefault(s => PocketTwo.Contains(s));
    }
}
