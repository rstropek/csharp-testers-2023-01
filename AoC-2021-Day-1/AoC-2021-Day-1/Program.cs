using AoC_2021_Day_1;

var numbers = await DepthReader.ReadDepthValuesAsync("depth.txt");
var result = DepthReader.Analyze(numbers);

Console.WriteLine(result);
