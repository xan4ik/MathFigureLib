using static System.Math;
using MathFigureLib.Validators;

namespace MathFigureLib;

public class Triangle : ValidatableFigure<double[]>
{
    public Triangle(params double[] edges) : base(edges)
    { }

    public IEnumerable<double> Sides => Data; 

    public override double CalculatePerimeter()
    {
        return Data.Sum();
    }

    public override double CalculateArea()
    {
        var halfOfperimetr = CalculatePerimeter() / 2;
        var halfMinusA = halfOfperimetr - Data[0];
        var halfMinusB = halfOfperimetr - Data[1];
        var halfMinusC = halfOfperimetr - Data[2];
        return Sqrt(halfOfperimetr * halfMinusA * halfMinusB * halfMinusC);
    }

    public bool IsRightTriangle()
    {
        const int digitsAfterPoint = 2;

        var sorted = Data.OrderBy(x => x).ToArray();
        double aSquare = Pow(sorted[0], 2);
        double bSquare = Pow(sorted[1], 2);
        double cSquare = Pow(sorted[2], 2);
        double cathetSquareSum = aSquare + bSquare;

        return Round(cathetSquareSum, digitsAfterPoint) == Round(cSquare, digitsAfterPoint);
    }

    protected override IDataValidator<double[]> GetValidator()
    {
        return new TriangleExistingValidator(
                    new AgrumentCountValidator(
                        new LessThenZeroLenghtValidator(),3));
    }
}

