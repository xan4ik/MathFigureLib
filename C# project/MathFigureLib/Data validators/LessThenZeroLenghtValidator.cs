using MathFigureLib.Exceptions;

namespace MathFigureLib.Validators;

public class LessThenZeroLenghtValidator:  IDataValidator<double>, IDataValidator<double[]>
{
    public void Validate(double[] data)
    {
        var hasWrongValues = data.Any(x => x<0);
        if (hasWrongValues) 
        {
            var wrongValue = data.First(x => x < 0);
            throw new WrongLengthException(wrongValue);
        }
    }

    public void Validate(double data)
    {
        if(data < 0) 
        {
            throw new WrongLengthException(data);
        }
    }

}
