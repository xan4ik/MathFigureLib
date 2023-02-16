namespace MathFigureLib.Exceptions;

public class WrongArgumentNumberException : Exception
{
    public readonly int Expected;
    public readonly int Actual;

    public WrongArgumentNumberException(int expected, int actual)
        : base($"Expected {expected} arguments, given {actual}")
    {
        Expected = expected;
        Actual = actual;
    }
}
