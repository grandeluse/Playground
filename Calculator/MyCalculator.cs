
using System.Reflection.Metadata.Ecma335;
using Calculator.Services;
using Microsoft.Extensions.Logging;

namespace Calculator;

public class MyCalculator : ICalculator
{
    private readonly IConsoleManager _console;
    private readonly IOperationFactory _operationFactory;
    private readonly ILogger _logger;

    public MyCalculator(IConsoleManager console, IOperationFactory operationFactory, ILoggerFactory loggerFactory)
    {
        _console = console ?? throw new ArgumentNullException(nameof(console));
        _operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
        ArgumentNullException.ThrowIfNull(loggerFactory, nameof(loggerFactory));
        _logger = loggerFactory.CreateLogger<MyCalculator>();
    }
    
    private readonly Dictionary<string, string> _operations= new()
    {
        {"+","[+] sum" },
        {"/","[/] division" },
        {"ESC", "[ESC] exit" }
    };

    public void Start()
    {
        _logger.LogDebug("Calculator started ...");
        var operation = string.Empty;
        do
        {
            try
            {
                PrintPresentation();

                (operation, var operationValue, var operationCorrectlyRead) = TryReadOperation();
                if (operationCorrectlyRead is not true)
                    continue;
                
                _console.WriteLine($"You choose: {operationValue}");

                if (operation!.Equals("ESC"))
                {
                    _logger.LogDebug("Calculator finished, thank you!");
                    return;
                }

                _console.WriteLine();
                _console.WriteLine("Type the first operator");
                if (!int.TryParse(_console.ReadLine(), out int firstOperator))
                {
                    _console.WriteLine("Wrong operator, Calculator restart ...");
                    continue;
                }
                _console.WriteLine($"First operator: {firstOperator}");

                _console.WriteLine();
                _console.WriteLine("Type the second operator");
                if (!int.TryParse(_console.ReadLine(), out int secondOperator))
                {
                    _console.WriteLine("Wrong operator, Calculator restart ...");
                    continue;
                }
                _console.WriteLine($"Second operator: {secondOperator}");

                var operationCalculator = _operationFactory.GetOperation(operation);
                var result = operationCalculator.Calculate(firstOperator, secondOperator);
                
                _console.WriteLine();
                _console.WriteLine($"The result of : {firstOperator} {operation} {secondOperator} is {result}");
            }
            catch (DivideByZeroException e)
            {
                _console.WriteLine($"The second operator must not be 0 in division operation ...");
            }
            catch (Exception e)
            {
                _console.WriteLine($"Generic error ...  {e.StackTrace}");
                throw;
            }
        } while (operation != _operations["ESC"]);
    }

    internal (string? operation, string? operationValue, bool result) TryReadOperation()
    {
        var operation = _console.ReadLine();
        
        if (operation is null || !_operations.TryGetValue(operation, out string operationValue))
        {
            _console.WriteLine("Wrong operation, Calculator restart ...");
            return (null, null, false);
        }
        
        return (operation, operationValue, true);
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
