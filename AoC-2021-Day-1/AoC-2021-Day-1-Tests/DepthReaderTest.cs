using AoC_2021_Day_1;

namespace AoC_2021_Day_1_Tests
{
    public class DepthReaderTest
    {
        [Fact]
        public async Task Part1()
        {
            var numbers = await DepthReader.ReadDepthValuesAsync("depth.txt");
            var result = DepthReader.Analyze(numbers);
            Assert.Equal(7, result);
        }

        [Fact]
        public async Task ReadDepthValues()
        {
            var numbers = await DepthReader.ReadDepthValuesAsync("DepthTest1.txt");
            Assert.Equal(new[] { 1, 2, 3 }, numbers);
        }

        [Fact]
        public void Analyze()
        {
            var result = DepthReader.Analyze(new[] { 1, 2, 3, 2, 3 });
            Assert.Equal(3, result);
        }

        [Fact]
        public void AnalyzeTooFewNumbers()
        {
            Assert.Throws<ArgumentException>(() => DepthReader.Analyze(new[] { 0 }));
        }
    }
}
