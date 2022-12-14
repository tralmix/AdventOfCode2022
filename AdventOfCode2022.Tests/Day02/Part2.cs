namespace AdventOfCode2022.Day_02
{
    public class Part2
    {
        private const string FileName = "Day02/Input.txt";

        [Fact]
        public async Task ScoreShouldBe12()
        {

            var score = await Day02.Part2(FileName);

            score.Should().Be(12);
        }
    }
}
