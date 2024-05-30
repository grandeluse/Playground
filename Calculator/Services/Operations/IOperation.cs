namespace Calculator.Services.Operations;

public interface IOperation
{
    int Calculate(int firstOperator, int secondOperator);
    bool CanHandle(string symbol);
}