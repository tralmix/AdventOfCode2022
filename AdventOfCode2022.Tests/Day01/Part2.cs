namespace AdventOfCode2022.Day_01
{
    public class Part2
    {
        private const string FileName = "Day01/Input.txt";

        [Fact]
        public async Task Part2_ShouldReturn24000()
        {
            const long expected = 45000;

            var result = await Day01.Part2(FileName);

            result.Should().Be(expected);
        }
    }
}
