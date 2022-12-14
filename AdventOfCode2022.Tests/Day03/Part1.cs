using FluentAssertions;

namespace AdventOfCode2022.Day_03
{
    public class Part1
    {
        private const string FileName = "Day03/Input.txt";

        [Fact]
        public async Task PrioritySumShouldBe157()
        {
            var sum = await Day03.Part1(FileName);

            sum.Should().Be(157);
        }
    }
}
