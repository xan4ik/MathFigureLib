using MathFigureLib.Validators;

namespace MathFigureLib;

public abstract class ValidatableFigure<T> : IFigure
{
    private IDataValidator<T> validator;
    private T data;

    public ValidatableFigure(T data)
    {
        validator = GetValidator();
        validator.Validate(data);

        this.data = data;
    }

    protected T Data 
    {
        get => data;
        set 
        {
            validator.Validate(value);
            this.data = value;
        }
    }

    protected abstract IDataValidator<T> GetValidator();

    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}
