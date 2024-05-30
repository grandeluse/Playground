using System.Diagnostics;

namespace Calculator.Services;

public class OperationFactory : IOperationFactory
{
    public IOperation GetOperation(string symbol)
    {
        IOperation operation = symbol switch
        {
            "+" => new AdditionOperation(),
            "/" => new DivisionOperation(),
            _ => throw new NotSupportedException()
        };
        return operation;
    }
}