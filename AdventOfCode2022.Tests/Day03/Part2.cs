namespace AdventOfCode2022.Day_03;

public class Part2
{
    private const string FileName = "Day03/Input.txt";

    [Fact]
    public async Task PrioritySumShouldBe70()
    {
        var sum = await Day03.Part2(FileName);

        sum.Should().Be(70);
    }
}