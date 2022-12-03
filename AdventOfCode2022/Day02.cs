using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_02
{
    public class Day02
    {
        public static async Task<List<Round>> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            return Array.Empty<Round>().ToList();
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
