namespace Calculator.Services;

public interface IConsoleManager
{
    void WriteLine();
    void WriteLine(string value);
    string? ReadLine();
}