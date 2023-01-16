namespace AdventOfCode2022.Day_03;

public class ParseFile
{
    private const string FileName = "Day03/Input.txt";

    [Fact]
    public async Task ShouldContain6Rucksacks()
    {
        var rucksacks = await Day03.ParseFile(FileName);

        rucksacks.Count.Should().Be(6);
    }

    [Theory]
    [InlineData(0, 'p')]
    [InlineData(1, 'L')]
    [InlineData(2, 'P')]
    [InlineData(3, 'v')]
    [InlineData(4, 't')]
    [InlineData(5, 's')]
    public async Task ShouldContainExpectedCharcterInBothCompartments(int index, char expected)
    {
        var rucksacks = await Day03.ParseFile(FileName);

        rucksacks[index].CommonItem.Should().Be(expected);
    }
}