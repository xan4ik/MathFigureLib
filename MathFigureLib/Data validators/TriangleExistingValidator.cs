using MathFigureLib.Exceptions;

namespace MathFigureLib.Validators;

internal class TriangleExistingValidator : ValidationDecorator<double[]>
{
    public TriangleExistingValidator(IDataValidator<double[]>? validator) : base(validator)
    { }

    public TriangleExistingValidator() : base(null)
    { }

    protected override void OnValidateData(double[] data)
    {
        if(data.Length != 3) 
        {
            throw new WrongArgumentNumberException(data.Length, 3);
        }


        var isNotExist = data[0] + data[1] < data[2] ||
                         data[0] + data[2] < data[1] ||
                         data[1] + data[2] < data[0];

        if (isNotExist)
        {
            throw new ArgumentException("Triangle with those sides, not exist");
        }
    }
}
