using static System.Math;
using MathFigureLib.Validators;

namespace MathFigureLib;

public class Circle : ValidatableFigure<double>
{
    public Circle(double radius) : base(radius)
    { }

    public double Radius => data;

    public override double CalculateArea()
    {
        return PI * Pow(data, 2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * PI * data;
    }

    protected override IDataValidator<double> GetValidator()
    {
        return new LessThenZeroLenghtValidator();
    }
}
