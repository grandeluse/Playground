using System;
namespace Calculator.Services
{
	public class ConsoleService : InputOutputServiceBase
	{
		public ConsoleService()
		{

		}

        public override void PrintPresentation(Dictionary<string,string> operations)
        {
            WriteLine();
            WriteLine("Welcome to Calculator");

            WriteLine();
            WriteLine("Insert the operation");
            WriteLine($"Allowed opearations are: {string.Join(", ", operations.Values)}");
        }

        public override string ReadLine()
        {
            return Console.ReadLine();
        }

        public override void WriteLine()
        {
            Console.WriteLine();
        }

        public override void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}

