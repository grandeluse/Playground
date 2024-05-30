namespace Calculator.Services.Operations;

public class DivisionOperation : IOperation
{
    public int Calculate(int firstOperator, int secondOperator)
    {
        return firstOperator / secondOperator;
    }
    
    public bool CanHandle(string symbol) => symbol == "/";
}