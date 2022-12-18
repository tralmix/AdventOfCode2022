namespace AdventOfCode2022.Day_05
{
    public  class Part2
    {
        private const string FileName = "Day05/Input.txt";
        private const string Expected = "MCD";

        [Fact]
        public async Task ShouldBeExpected()
        {
            var answer = await Day05.Part2(FileName);

            answer.Should().Be(Expected);
        }
    }
}
