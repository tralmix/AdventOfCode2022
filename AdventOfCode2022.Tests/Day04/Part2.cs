namespace AdventOfCode2022.Day_04
{
    public class Part2
    {
        private const string FileName = "Day04/Input.txt";

        [Fact]
        public async Task ShouldFindFourOverlappingSets()
        {
            var subsets = await Day04.Part2(FileName);

            subsets.Should().Be(4);
        }
    }
}
