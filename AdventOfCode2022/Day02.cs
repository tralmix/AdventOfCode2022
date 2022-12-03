namespace AdventOfCode2022.Day_02
{
    public class Day02
    {
        public static async Task<List<Round>> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            var rounds = new List<Round>();

            foreach(var line in linesOfInput)
                rounds.Add(BuildRound(line));

            return rounds;
        }

        private static Round BuildRound(string line)
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
