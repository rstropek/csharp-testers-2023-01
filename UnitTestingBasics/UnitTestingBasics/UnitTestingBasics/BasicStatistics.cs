namespace UnitTestingBasics;

public interface INumbersReader
{
    Task<IEnumerable<int>> ReadNumbersAsync();
}

public class NumbersFileReader : INumbersReader
{
    public async Task<IEnumerable<int>> ReadNumbersAsync()
    {
        var fileContent = await File.ReadAllTextAsync("numbers.txt");
        return fileContent.Split(',').Select(int.Parse);
    }
}

public static class BasicStatistics
{
    public static int Sum(IEnumerable<int> numbers)
    {
        return numbers.Sum(); // Linq
    }

    // Implement a function that calculates the sum of numbers.
    // The numbers must be read from any source. The source could be
    // a file, a database, or even a sensor.
    public static async Task<int> Sum(INumbersReader reader)
    {
        var numbers = await reader.ReadNumbersAsync();
        return Sum(numbers);
    }
}
