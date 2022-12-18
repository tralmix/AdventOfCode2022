namespace AdventOfCode2022.Day_05
{
    public class Part1
    {
        private const string FileName = "Day05/Input.txt";
        private const string Expected = "CMZ";

        [Fact]
        public async Task ShouldBeExpected()
        {
            var answer = await Day05.Part1(FileName);

            answer.Should().Be(Expected);
        }
    }
}
