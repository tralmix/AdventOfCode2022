namespace AdventOfCode2022.Day_07;

public class Part1
{
    private const string FileName = "Day07/Input.txt";
    private const int Expected = 95437;

    [Fact]
    public async Task ShouldBeExpected()
    {
        var answer = await Day07.Part1(FileName);

        answer.Should().Be(Expected);
    }
}