using MathFigureLib.Exceptions;

namespace MathFigureLib.Validators;

public class AgrumentCountValidator : ValidationDecorator<double[]>
{
    public AgrumentCountValidator(IDataValidator<double[]> validator, int argsCount) : base(validator)
    {
        ArgsCount = argsCount; 
    }

    public AgrumentCountValidator(int argsCount)
    {
        ArgsCount = argsCount;
    }

    public int ArgsCount { get; init; }

    protected override void OnValidateData(double[] data)
    {
        if (data.Length != ArgsCount)
        {
            throw new WrongArgumentNumberException(data.Length, ArgsCount);
        }
    }
}
