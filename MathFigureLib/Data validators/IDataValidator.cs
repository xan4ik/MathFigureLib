namespace MathFigureLib.Validators;

public interface IDataValidator<T> 
{
    public void Validate(T data); 
}