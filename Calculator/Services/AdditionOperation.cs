namespace Calculator.Services;

public class AdditionOperation : IOperation
{
    public int Calculate(int firstOperator, int secondOperator)
    {
        return firstOperator + secondOperator;
    }
}