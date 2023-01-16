namespace AdventOfCode2022.Day_01;

public class Part1
{
    private const string FileName = "Day01/Input.txt";

    [Fact]
    public async Task Part1_ShouldReturn24000()
    {
        const long expected = 24000;

        var result = await Day01.Part1(FileName);

        result.Should().Be(expected);
    }
}