namespace MathLibTests;
public class CircleSuitTest
{
    [Theory]
    [InlineData(2)]
    [InlineData(0)]
    public void CreateWithoutException(double radius)
    {
        Circle circle = new Circle(radius);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(-2)]
    public void CreateWithException(double radius)
    {
        Assert.Throws<WrongLengthException>(() =>
        {
            Circle circle = new Circle(radius);
        });
    }

    [Theory]
    [InlineData(2, 12.566f, 0.001f)]
    public void CalculateArea(double radius, double perimeter, double delta)
    {
        Circle circle = new Circle(radius);
        var area = circle.CalculateArea();

        Assert.Equal(perimeter, area, delta);
    }

    [Theory]
    [InlineData(2, 12.566f, 0.001f)]
    public void CalculatePerimeter(double radius, double perimeter, double delta)
    {
        Circle circle = new Circle(radius);
        var result = circle.CalculatePerimeter();

        Assert.Equal(perimeter, result, delta);
    }
}