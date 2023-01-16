namespace AdventOfCode2022.Day_04;

public class Part1
{
    private const string FileName = "Day04/Input.txt";

    [Fact]
    public async Task ShouldFindTwoCompleteSubsets()
    {
        var subsets = await Day04.Part1(FileName);

        subsets.Should().Be(2);
    }
}