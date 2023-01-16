CalculateAndPrint(1, 2, Add);
CalculateAndPrint(1, 2, Sub);
CalculateAndPrint(2, 4, delegate (int x, int y) { return x * y; });
CalculateAndPrint(2, 4, (x, y) => x * y);
CalculateAndPrint(2, 4, (x, y) => x / y);
CalculateAndPrint(2, 4, (x, y) => (int)Math.Pow(x, y));

var numbers = new[] { 1, 1, 2, 3, 5, 8, 13 };
AggregateAndPrint(numbers, 0, Add);
AggregateAndPrint(numbers, 1, (x, y) => x * y);

Filter(numbers, n => n % 2 == 0);
Filter(numbers, n => n % 2 != 0);
Filter(numbers, n => n < 5);
Filter(numbers, n => n > 8);

var names = new[] { "Tim", "Tom", "Frank", "John", "Jane", "Mary", "Eve" };

Filter(names, n => n.StartsWith("T"));
// names.Where(n => n.StartsWith("T"));

"1,2,3,4,5".Split(",").Select(int.Parse).ToList();

Filter(names, GetPredicate());

#region Calculate and Print - Step 1
//static void CalculateAndPrint(int x, int y, Func<int, int, int> op)
static void CalculateAndPrint(int x, int y, MathOperation op)
{
    var result = op(x, y);
    Console.WriteLine(result);
}

static int Add(int x, int y)
{
    return x + y;
}

static int Sub(int x, int y)
{
    return x - y;
}
#endregion

#region Aggregate and Print - Step 2
static void AggregateAndPrint(IEnumerable<int> numbers, int initial, MathOperation op)
{
    var agg = initial;
    foreach (var n in numbers)
    {
        agg = op(agg, n);
    }

    Console.WriteLine(agg);
}
#endregion

#region Filter - Step 3
// static void Filter(IEnumerable<int> numbers, Func<int, bool> f)
//static void Filter(IEnumerable<int> numbers, Predicate f)
//{
//    // Print all even numbers
//    foreach (var n in numbers)
//    {
//        if (f(n))
//        {
//            Console.WriteLine(n);
//        }
//    }
//}
#endregion

#region Generic filter - Step 4
static void Filter<T>(IEnumerable<T> numbers, Func<T, bool> f)
{
    // Print all even numbers
    foreach (var n in numbers)
    {
        if (f(n))
        {
            Console.WriteLine(n);
        }
    }
}
#endregion

#region Closures - Step 5
Func<string, bool> GetPredicate()
{
    Console.Write("First letter of name for filter: ");
    string firstLetter = Console.ReadLine()!;
    return n => n.StartsWith(firstLetter);
}
#endregion

delegate int MathOperation(int x, int y);
delegate bool Predicate(int x);
delegate bool PredicateString(string x);