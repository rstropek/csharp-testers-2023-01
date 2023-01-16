namespace UnitTestingBasics;

public static class BasicMath
{
    public static int Add(int x, int y)
    {
        checked
        {
            return x + y;
        }
    }

    // Expression-bodied members
    // public static int Add(int x, int y) => x + y;
}
