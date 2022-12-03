using FluentAssertions;

namespace AdventOfCode2022.Day_02
{
    public class Part1
    {
        private const string FileName = "Day02/Input.txt";

        [Fact]
        public async Task ScoreShouldBe15()
        {
            var score = await Day02.Part1(FileName);

            score.Should().Be(15);
        }
    }
}
