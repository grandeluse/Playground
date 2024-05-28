
namespace Calculator
{
	public class MyCalculator : ICalculator
	{
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
                    Console.WriteLine();
                    Console.WriteLine("Welcome to Calculator");

                    Console.WriteLine();
                    Console.WriteLine("Insert the operation");
                    Console.WriteLine($"Allowed opearations are: {string.Join(", ", _operations.Values)}");

                    operation = Console.ReadLine();
                    if (!_operations.TryGetValue(operation, out string operationValue))
                    {
                        Console.WriteLine("Wrong operation, Calculator restart ...");
                        continue;
                    }
                    Console.WriteLine($"You choose: {operationValue}");

                    if (operation.Equals("ESC"))
                        return;

                    Console.WriteLine();
                    Console.WriteLine("Type the first operator");
                    if (!int.TryParse(Console.ReadLine(), out int firstOperator))
                    {
                        Console.WriteLine("Wrong operator, Calculator restart ...");
                        continue;
                    }
                    Console.WriteLine($"First operator: {firstOperator}");

                    Console.WriteLine();
                    Console.WriteLine("Type the second operator");
                    if (!int.TryParse(Console.ReadLine(), out int secondOperator))
                    {
                        Console.WriteLine("Wrong operator, Calculator restart ...");
                        continue;
                    }
                    Console.WriteLine($"Second operator: {secondOperator}");

                    int result = operation switch
                    {
                        "+" => firstOperator + secondOperator,
                        "/" => firstOperator / secondOperator,
                        _ => throw new InvalidOperationException("Operation not allowed")
                    };
                    Console.WriteLine();
                    Console.WriteLine($"The result of : {firstOperator} {operation} {secondOperator} is {result}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine($"The second operator must not be 0 ... {e.StackTrace}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Generic error ...  {e.StackTrace}");
                    throw;
                }
            } while (operation != _operations["ESC"]);

        }
    }
}

