using MathFigureLib.Validators;
using static System.Math;

namespace MathFigureLib.AsyncFigures;


internal readonly record struct TriangleSides(double a, double b, double c)
{
    public static TriangleSides FromArray(double[] sides)
    {
        return new TriangleSides(sides[0], sides[1], sides[2]);
    }
}


public class TriangleThreadSafe : ValidatableFigure<double[]>, IAsyncFigure
{
    public TriangleThreadSafe(params double[] data) : base(data)
    { }

    public double[] Sides 
    {
        get => Data;
        set => Data = value;
    }

    public override double CalculateArea()
    {
        TriangleSides sides = TriangleSides.FromArray(Data);
        var halfOfperimetr = (sides.a + sides.b + sides.c) / 2;
        var halfMinusA = halfOfperimetr - sides.a;
        var halfMinusB = halfOfperimetr - sides.b;
        var halfMinusC = halfOfperimetr - sides.c;
        return Sqrt(halfOfperimetr * halfMinusA * halfMinusB * halfMinusC);
    }

    public override double CalculatePerimeter()
    {
        TriangleSides sides = TriangleSides.FromArray(Data);
        return sides.a + sides.b + sides.c;
    }


    public async Task<double> CalculateAreaAsync()
    {
        return await Task.Run(CalculateArea)
                         .ConfigureAwait(false);
    }

    public async Task<double> CalculateAreaAsync(CancellationToken token)
    {
        return await Task.Run(CalculateArea, token)
                         .ConfigureAwait(false);
    }

    public async Task<double> CalculatePerimeterAsync()
    {
        return await Task.Run(CalculatePerimeter)
                         .ConfigureAwait(false);
    }

    public async Task<double> CalculatePerimeterAsync(CancellationToken token)
    {
        return await Task.Run(CalculatePerimeter, token)
                         .ConfigureAwait(false);
    }

    protected override IDataValidator<double[]> GetValidator()
    {
        return new TriangleExistingValidator(
                   new AgrumentCountValidator(
                       new LessThenZeroLenghtValidator(), 3));
    }
}
