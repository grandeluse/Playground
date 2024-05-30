namespace Calculator.Services;

public interface IOperationFactory
{
    IOperation GetOperation(string symbol);
}