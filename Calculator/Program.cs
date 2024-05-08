
Dictionary<string, string> operations = new()
{
    {"+","[+] sum" },
    {"/","[/] divide" },
};


while (true)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to Calculator");

        Console.WriteLine();
        Console.WriteLine("Insert the operation");
        Console.WriteLine($"Allowed opearations are: {string.Join(", ", operations.Values)}");
        string operation = Console.ReadLine();
        if (!operations.TryGetValue(operation, out string operationValue))
        {
            Console.WriteLine("Wrong operation, Calculator restart ...");
            continue;
        }
        Console.WriteLine($"You choose: {operationValue}");

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
}



