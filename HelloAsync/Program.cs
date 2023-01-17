using System.Globalization;
using CsvHelper;

const int X = 1;
const int Y = 2;
var result = await SlowAddAsync(X, Y);
System.Console.WriteLine(result);

using (var reader = new StreamReader(@"C:\temp\CSharpForTesters-2023-01\HelloAsync\file.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    await foreach (var record in csv.GetRecordsAsync<Foo>())
    {
        Console.WriteLine(record.Id);
        Console.WriteLine(record.Name);
    }
}

async Task<int> SlowAddAsync(int x, int y)
{
    // Simulate working with e.g. machine, DB, file, etc.
    await Task.Delay(3000);

    return x + y;
}

public class Foo
{
    public int Id { get; set; }
    public string Name { get; set; }
}