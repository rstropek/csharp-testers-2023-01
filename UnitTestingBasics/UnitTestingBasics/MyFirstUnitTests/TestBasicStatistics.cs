namespace MyFirstUnitTests;

public class TestBasicStatistics
{
    [Fact]
    public void Sum()
    {
        var result = BasicStatistics.Sum(new[] { 1, 2, 3 });
        Assert.Equal(6, result);
    }

    [Fact]
    [Trait("TestType", "Integration")]
    public async Task SumNumbersFromFile()
    {
        var reader = new NumbersFileReader();
        var result = await BasicStatistics.Sum(reader);
        Assert.Equal(15, result);
    }
}
