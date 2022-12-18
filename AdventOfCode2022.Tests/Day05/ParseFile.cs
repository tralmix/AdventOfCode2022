namespace AdventOfCode2022.Day_05
{
    public class ParseFile
    {
        private const string FileName = "Day05/Input.txt";

        [Fact]
        public async Task ShouldHave3Stacks()
        {
            var ship = await Day05.ParseFile(FileName);

            ship.Stacks.Should().HaveCount(3);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,1)]
        [InlineData(3,4)]
        public async Task StacksShouldContainExpectedQuantity(int stack, int count)
        {
            var ship = await Day05.ParseFile(FileName);

            ship.Stacks[stack].Containers.Should().HaveCount(count);
        }
    }
}
