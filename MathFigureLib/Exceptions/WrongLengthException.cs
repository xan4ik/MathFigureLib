namespace MathFigureLib.Exceptions;

public class WrongLengthException : Exception
{
    public WrongLengthException(double value) : base($"some side has wrong length: {value}")
    { }
}
