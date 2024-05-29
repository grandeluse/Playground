
using System.Reflection.Metadata.Ecma335;
using Calculator.Services;

namespace Calculator;

public class MyCalculator(IConsoleManager console) : ICalculator
{
    private readonly IConsoleManager _console = console ?? throw new ArgumentNullException(nameof(console));

    private readonly Dictionary<string, string> _operations= new()
    {
        {"+","[+] sum" },
        {"/","[/] division" },
        {"ESC", "[ESC] exit" }
    };

    public void Start()
    {
        string operation = string.Empty;
        do
        {
            try
            {
                PrintPresentation();

                operation = _console.ReadLine();
                if (!_operations.TryGetValue(operation, out string operationValue))
                {
                    _console.WriteLine("Wrong operation, Calculator restart ...");
                    continue;
                }
                _console.WriteLine($"You choose: {operationValue}");

                if (operation.Equals("ESC"))
                    return;

                _console.WriteLine();
                _console.WriteLine("Type the first operator");
                if (!int.TryParse(Console.ReadLine(), out int firstOperator))
                {
                    _console.WriteLine("Wrong operator, Calculator restart ...");
                    continue;
                }
                _console.WriteLine($"First operator: {firstOperator}");

                _console.WriteLine();
                _console.WriteLine("Type the second operator");
                if (!int.TryParse(Console.ReadLine(), out int secondOperator))
                {
                    _console.WriteLine("Wrong operator, Calculator restart ...");
                    continue;
                }
                _console.WriteLine($"Second operator: {secondOperator}");

                int result = operation switch
                {
                    "+" => firstOperator + secondOperator,
                    "/" => firstOperator / secondOperator,
                    _ => throw new InvalidOperationException("Operation not allowed")
                };
                _console.WriteLine();
                _console.WriteLine($"The result of : {firstOperator} {operation} {secondOperator} is {result}");
            }
            catch (DivideByZeroException e)
            {
                _console.WriteLine($"The second operator must not be 0 ... {e.StackTrace}");
            }
            catch (Exception e)
            {
                _console.WriteLine($"Generic error ...  {e.StackTrace}");
                throw;
            }
        } while (operation != _operations["ESC"]);

    }
    internal void PrintPresentation()
    {
        _console.WriteLine();
        _console.WriteLine("Welcome to Calculator");

        _console.WriteLine();
        _console.WriteLine("Insert the operation");
        _console.WriteLine($"Allowed operations are: {string.Join(", ", _operations.Values)}");
    }
}