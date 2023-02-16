namespace MathLibTests;

public class TriangleSuitTest
{

    [Theory]
    [InlineData(new double[] { 2, 3, 4 })]
    [InlineData(new double[] { 3, 5, 4 })]
    [InlineData(new double[] { 10, 10, 12 })]
    public void CreateWithoutException(double[] edges)
    {
        Triangle triangle = new Triangle(edges); 
    }

    [Theory]
    [InlineData(new double[] { 2, 3 })]
    [InlineData(new double[] { 3, 5, 4, 4 })]
    public void EdgeCountException(double[] edges)
    {
        Assert.Throws<WrongArgumentNumberException>(() =>
        {
            Triangle triangle = new Triangle(edges);
        });
    }

    [Theory]
    [InlineData(new double[] { 3, -1, 2 })]
    [InlineData(new double[] { -3, 21, 2 })]
    public void EdgeLengthException(double[] edges)
    {
        Assert.Throws<WrongLengthException>(() =>
        {
            Triangle triangle = new Triangle(edges);
        });
    }

    [Theory]
    [InlineData(new double[] { 2, 3, 9 })]
    [InlineData(new double[] { 3, 8, 2 })]
    public void TriangleNotExsitsException(double[] edges)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Triangle triangle = new Triangle(edges);
        });
    }


    [Theory]
    [InlineData(0.968, new double[] { 1, 2, 2 }, 0.001f)]
    public void TriangleAreaCalculation(double expectedArea, double[] edges, double delta)
    {
        Triangle triangle = new Triangle(edges);
        double result = triangle.CalculateArea();

        Assert.Equal(expectedArea, result, delta);
    }

    [Theory]
    [InlineData(new double[] { 2, 3, 4 })]
    public void CalculatePerimeter(double[] edges)
    {
        Triangle triangle = new Triangle(edges);
        var result = triangle.CalculatePerimeter();

        Assert.Equal(result, edges.Sum());
    }

    [Theory]
    [InlineData(new double[] { 3, 5, 4 })]
    [InlineData(new double[] { 5, 12, 13 })]
    public void TestRightTriangle(double[] edges)
    {
        Triangle triangle = new Triangle(edges);
        Assert.True(triangle.IsRightTriangle());
    }

    [Theory]
    [InlineData(new double[] { 3, 6, 4 })]
    [InlineData(new double[] { 7, 12, 13 })]
    public void TestNotRightTriangle(double[] edges)
    {
        Triangle triangle = new Triangle(edges);
        Assert.False(triangle.IsRightTriangle());
    }

}
