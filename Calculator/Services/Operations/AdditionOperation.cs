namespace Calculator.Services.Operations;

public class AdditionOperation : IOperation
{
    public int Calculate(int firstOperator, int secondOperator)
    {
        return firstOperator + secondOperator;
    }

    public bool CanHandle(string symbol) => symbol == "+";
}