using System.Diagnostics;

namespace AoC_2021_Day_1
{
    public static class DepthReader
    {
        public static int Analyze(int[] numbers)
        {
            //Debug.Assert(numbers.Length > 1);
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Too few numbers", nameof(numbers));
            }

            var counter = 0;
            var previous = numbers[0];
            foreach(var number in numbers[1..])
            {
                if (number > previous)
                {
                    counter++;
                }

                previous = number;
            }

            return counter;
        }

        public static async Task<int[]> ReadDepthValuesAsync(string fileName)
        {
            var fileContent = await File.ReadAllTextAsync(fileName);
            return fileContent.Split(Environment.NewLine).Select(int.Parse).ToArray();
        }

        //public static int[] ReadDepthValues(string fileName)
        //{
        //    var fileContent = File.ReadAllText(fileName);
        //    return fileContent.Split(Environment.NewLine).Select(int.Parse).ToArray();
        //}
    }
}
