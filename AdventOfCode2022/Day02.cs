namespace AdventOfCode2022.Day_02
{
    public class Day02
    {
        private static readonly string FileName = "Inputs/Day02.txt";
        public static async Task Run()
        {
            Console.WriteLine("Day 1");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The score for all rounds is {part1Answer}.");

            //var part2Answer = await Part2(FileName);
            //Console.WriteLine($"The three elves carrying the most hold a combined {part2Answer} calories");

            Console.WriteLine();
        }

        public static async Task<int> Part1(string fileName)
        {
            var rounds = await ParseFile(fileName);

            return rounds.Sum(r => r.Score);
        }

        public static async Task<List<Round>> ParseFile(string fileName, bool part1 = true)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            var rounds = new List<Round>();

            foreach (var line in linesOfInput)
                if (part1) rounds.Add(BuildRound_Part1(line));
                else
                {

                }

            return rounds;
        }

        private static Round BuildRound_Part1(string line)
        {
            var throws = line.Split(' ');
            var round = new Round
            {
                Opponent = throws[0] switch
                {
                    "A" => Throw.Rock,
                    "B" => Throw.Paper,
                    "C" => Throw.Scissors,
                    _ => throw new NotImplementedException()
                },
                Self = throws[1] switch
                {
                    "X" => Throw.Rock,
                    "Y" => Throw.Paper,
                    "Z" => Throw.Scissors,
                    _ => throw new NotImplementedException()
                }
            };
            return round;
        }
    }

    public class Round
    {
        public Throw Opponent { get; set; }
        public Throw Self { get; set; }

        public bool IsADraw => Opponent == Self;

        public bool IsAWin
        {
            get
            {
                if (Opponent == Throw.Rock && Self == Throw.Paper)
                    return true;
                if (Opponent == Throw.Paper && Self == Throw.Scissors)
                    return true;
                if (Opponent == Throw.Scissors && Self == Throw.Rock)
                    return true;
                return false;
            }
        }

        public int Score
        {
            get
            {
                var score = Self switch
                {
                    Throw.Rock => 1,
                    Throw.Paper => 2,
                    Throw.Scissors => 3,
                    _ => throw new NotImplementedException()
                };

                if (IsAWin) score += 6;
                if (IsADraw) score += 3;

                return score;
            }
        }
    }

    public enum Throw
    {
        Rock,
        Paper,
        Scissors
    }
}
