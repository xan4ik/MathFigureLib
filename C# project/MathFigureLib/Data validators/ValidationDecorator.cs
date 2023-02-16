namespace MathFigureLib.Validators;

public abstract class ValidationDecorator<T> : IDataValidator<T>
{
    private IDataValidator<T>? inner;
    public ValidationDecorator(IDataValidator<T>? validator)
    {
        inner = validator;
    }

    public void Validate(T data)
    {
        if(inner is not null) 
        {
            inner.Validate(data);
        }
        OnValidateData(data);
    }

    protected abstract void OnValidateData(T data);
}
