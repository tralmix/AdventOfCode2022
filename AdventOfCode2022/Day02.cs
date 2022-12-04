namespace AdventOfCode2022.Day_02
{
    public class Day02
    {
        private static readonly string FileName = "Inputs/Day02.txt";
        public static async Task Run()
        {
            Console.WriteLine("Day 2");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The score for all rounds is {part1Answer}.");

            var part2Answer = await Part2(FileName);
            Console.WriteLine($"The score for all rounds is {part2Answer}.");

            Console.WriteLine();
        }

        public static async Task<int> Part1(string fileName)
        {
            var rounds = await ParseFile(fileName);

            return rounds.Sum(r => r.Score);
        }

        public static async Task<int> Part2(string fileName)
        {
            var rounds = await ParseFile(fileName, false);

            return rounds.Sum(r => r.Score);
        }

        public static async Task<List<Round>> ParseFile(string fileName, bool part1 = true)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            var rounds = new List<Round>();

            foreach (var line in linesOfInput)
                if (part1) rounds.Add(BuildRound(line, part1));
                else rounds.Add(BuildRound(line, part1));

            return rounds;
        }

        private static Round BuildRound(string line, bool part1)
        {
            var throws = line.Split(' ');
            var round = new Round
            {
                Opponent = GetThrowValue(throws[0]),
                Self = part1 ? GetThrowValue(throws[1]) :
                    GetThrowValueBasedOnOpponentAndExpectedOutcome(throws)
            };
            return round;
        }

        private static Throw GetThrowValueBasedOnOpponentAndExpectedOutcome(string[] throws)
        {
            return throws[1] switch
            {
                "X" => GetThrowToLose(GetThrowValue(throws[0])),
                "Y" => GetThrowToDraw(GetThrowValue(throws[0])),
                "Z" => GetThrowToWin(GetThrowValue(throws[0])),
                _ => throw new NotImplementedException()
            };
        }

        private static Throw GetThrowToLose(Throw opponentThrow)
        {
            return opponentThrow switch
            {
                Throw.Rock => Throw.Scissors,
                Throw.Paper => Throw.Rock,
                Throw.Scissors => Throw.Paper,
                _ => throw new NotImplementedException()
            };
        }

        private static Throw GetThrowToWin(Throw opponentThrow)
        {
            return opponentThrow switch
            {
                Throw.Rock => Throw.Paper,
                Throw.Paper => Throw.Scissors,
                Throw.Scissors => Throw.Rock,
                _ => throw new NotImplementedException()
            };
        }

        private static Throw GetThrowToDraw(Throw opponentThrow) => opponentThrow;

        private static Throw GetThrowValue(string input)
        {
            return input switch
            {
                "A" => Throw.Rock,
                "B" => Throw.Paper,
                "C" => Throw.Scissors,
                "X" => Throw.Rock,
                "Y" => Throw.Paper,
                "Z" => Throw.Scissors,
                _ => throw new NotImplementedException()
            };
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
