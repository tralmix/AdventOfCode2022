namespace AdventOfCode2022.Day_01
{
    public class ParseFile
    {
        private const string FileName = "Day01/Input.txt";

        [Fact]
        public async Task ShouldYieldFiveElves()
        {
            var elves = await Day01.ParseFile(FileName);

            elves.Count.Should().Be(5);
        }

        [Theory]
        [InlineData(0, 6000)]
        [InlineData(1, 4000)]
        [InlineData(2, 11000)]
        [InlineData(3, 24000)]
        [InlineData(4, 10000)]
        public async Task ElfHasExpectedCalories(int elf, long calories)
        {
            var elves = await Day01.ParseFile(FileName);

            elves[elf].TotalCalories.Should().Be(calories);
        }
    }
}
