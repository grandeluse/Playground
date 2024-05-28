namespace Calculator.Services;

public class ConsoleManager : IConsoleManager
{
    public void WriteLine()
    {
        Console.WriteLine();
    }

    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }

    public string? ReadLine()
    {
        var value = Console.ReadLine();
        return value;
    }
}