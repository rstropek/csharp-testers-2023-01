namespace MyFirstUnitTests;

public class TestBasicMath
{
    [Fact]
    public void Add()
    {
        var result = BasicMath.Add(1, 2);
        Assert.Equal(3, result);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2000, 3000, 5000)]
    public void AddTheory(int x, int y, int expected)
    {
        var result = BasicMath.Add(x, y);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddWithOverflow()
    {
        Assert.Throws<OverflowException>(
            () => BasicMath.Add(int.MaxValue, 1));
    }
}
