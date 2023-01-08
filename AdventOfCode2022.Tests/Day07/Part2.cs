namespace AdventOfCode2022.Day_07;

public class Part2
{
    private const string FileName = "Day07/Input.txt";
    private const int Expected = 24933642;

    [Fact]
    public async Task ShouldBeExpected()
    {
        var answer = await Day07.Part2(FileName);

        answer.Should().Be(Expected);
    }
}