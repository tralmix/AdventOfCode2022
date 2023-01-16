namespace AdventOfCode2022.Day_05;

public class ParseFile
{
    private const string FileName = "Day05/Input.txt";

    [Fact]
    public async Task ShouldHave3Stacks()
    {
        var ship = await Day05.ParseFile(FileName);

        ship.Stacks.Should().HaveCount(3);
    }

    [Fact]
    public async Task ShouldHave4Instructions()
    {
        var ship = await Day05.ParseFile(FileName);

        ship.Instructions.Should().HaveCount(4);
    }

    [Theory]
    [InlineData(0, 2)]
    [InlineData(1, 3)]
    [InlineData(2, 1)]
    public async Task StacksShouldContainExpectedQuantity(int stack, int count)
    {
        var ship = await Day05.ParseFile(FileName);

        ship.Stacks[stack].Containers.Should().HaveCount(count);
    }

    [Theory]
    [InlineData(0, 1, 2, 1)]
    [InlineData(1, 3, 1, 3)]
    [InlineData(2, 2, 2, 1)]
    [InlineData(3, 1, 1, 2)]

    public async Task InstructionsShouldBeAsExpected(int instruction, int count, int source, int target)
    {
        var ship = await Day05.ParseFile(FileName);

        ship.Instructions[instruction].CountToMove.Should().Be(count);
        ship.Instructions[instruction].SourceStack.Should().Be(source);
        ship.Instructions[instruction].TargetStack.Should().Be(target);
    }
}