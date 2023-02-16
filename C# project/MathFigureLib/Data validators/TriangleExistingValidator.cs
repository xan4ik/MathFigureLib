namespace MathFigureLib.Validators;

internal class TriangleExistingValidator : ValidationDecorator<double[]>
{
    public TriangleExistingValidator(IDataValidator<double[]> validator) : base(validator)
    { }

    public TriangleExistingValidator()
    { }

    protected override void OnValidateData(double[] data)
    {
        var isNotExist = data[0] + data[1] < data[2] ||
                         data[0] + data[2] < data[1] ||
                         data[1] + data[2] < data[0];

        if (isNotExist)
        {
            throw new ArgumentException("Triangle with those sides, not exist");
        }
    }
}
