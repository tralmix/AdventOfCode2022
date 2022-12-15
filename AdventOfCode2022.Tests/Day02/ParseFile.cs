namespace AdventOfCode2022.Day_02
{
    public class ParseFile
    {
        private const string FileName = "Day02/Input.txt";

        [Fact]
        public async Task ShouldYieldThreeRounds()
        {
            var rounds = await Day02.ParseFile(FileName);

            rounds.Count.Should().Be(3);
        }

        [Theory]
        [InlineData(0, true, false, 8)]
        [InlineData(1, false, false, 1)]
        [InlineData(2, false, true, 6)]
        public async Task ShouldHaveExpectedOutcomeAndScore(int round, bool isAWin, bool isADraw, int score)
        {
            var rounds = await Day02.ParseFile(FileName);

            rounds[round].IsAWin.Should().Be(isAWin);
            rounds[round].IsADraw.Should().Be(isADraw);
            rounds[round].Score.Should().Be(score);
        }
    }
}
