namespace MathFigureLib.AsyncFigures;

public interface IAsyncFigure : IFigure
{
    public Task<double> CalculatePerimeterAsync();
    public Task<double> CalculatePerimeterAsync(CancellationToken token);
    public Task<double> CalculateAreaAsync();
    public Task<double> CalculateAreaAsync(CancellationToken token);
}
