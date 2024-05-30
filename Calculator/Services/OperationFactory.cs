using System.Diagnostics;
using Calculator.Services.Operations;

namespace Calculator.Services;

public class OperationFactory(IEnumerable<IOperation> operations) : IOperationFactory
{
    private readonly IEnumerable<IOperation> _operations = operations ?? throw new ArgumentNullException(nameof(operations));

    public IOperation GetOperation(string symbol)
    {
        var operationCalculator = _operations.FirstOrDefault(x => x.CanHandle(symbol));
        if (operationCalculator is null)
            throw new NotSupportedException();
        return operationCalculator;
    }
}