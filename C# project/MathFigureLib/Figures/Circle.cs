using static System.Math;
using MathFigureLib.Validators;

namespace MathFigureLib;

public class Circle : ValidatableFigure<double>
{
    public Circle(double radius) : base(radius)
    { }

    public double Radius 
    {
        get => Data;
        set => Data = value;
    }

    public override double CalculateArea()
    {
        return PI * Pow(Data, 2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * PI * Data;
    }

    protected override IDataValidator<double> GetValidator()
    {
        return new LessThenZeroLenghtValidator();
    }
}
