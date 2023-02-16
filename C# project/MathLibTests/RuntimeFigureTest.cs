using static System.Reflection.BindingFlags;

namespace MathLibTests;

public class RuntimeFigureTest
{
    [Theory]
    [InlineData(typeof(Circle), 5)]
    [InlineData(typeof(Triangle), new double[]{3,4,5})]
    public void TestFigureRuntime(Type type, object args) 
    {
        var figure = CreateInstance(type, args);
        var area = figure.CalculateArea();
        var perimeter = figure.CalculatePerimeter();
    }

    private IFigure CreateInstance(Type type, object args)
    {
        var constructor = type.GetConstructor(Public | Instance, new Type[] { args.GetType() });
        var result = constructor.Invoke(new object[] { args });

        if (result is IFigure figure) 
        {
            return figure;
        }
        throw new ArgumentException("Can't create figure");
    }
}
