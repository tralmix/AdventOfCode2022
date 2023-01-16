namespace AdventOfCode2022.Day_04;

public class ParseFile
{
    private const string FileName = "Day04/Input.txt";

    [Fact]
    public async Task ShouldYieldSixPairs()
    {
        var pairs = await Day04.ParseFile(FileName);

        pairs.Count.Should().Be(6);
    }
}