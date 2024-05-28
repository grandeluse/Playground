using System;
using Calculator.Services;

namespace Calculator
{
	public class MyCalculator : ICalculator
	{
        private readonly IInputOutputService _inputOutputService;
        private readonly Dictionary<string, string> _operations;
        
        public MyCalculator(IInputOutputService inputOutputService)
		{
            _operations = new()
            {
                {"+","[+] sum" },
                {"/","[/] division" },
                {"ESC", "[ESC] exit" }
            };

            _inputOutputService = inputOutputService ?? throw new ArgumentNullException(nameof(inputOutputService));
        }

		public void Start()
		{
            string operation = string.Empty;
            //do
            //{
            //    try
            //    {
                    _inputOutputService.PrintPresentation(_operations);
                    
                    //            operation = Console.ReadLine();
                    //            if (!operations.TryGetValue(operation, out string operationValue))
                    //            {
                    //                Console.WriteLine("Wrong operation, Calculator restart ...");
                    //                continue;
                    //            }
                    //            Console.WriteLine($"You choose: {operationValue}");

                    //            Console.WriteLine();
                    //            Console.WriteLine("Type the first operator");
                    //            if (!int.TryParse(Console.ReadLine(), out int firstOperator))
                    //            {
                    //                Console.WriteLine("Wrong operator, Calculator restart ...");
                    //                continue;
                    //            }
                    //            Console.WriteLine($"First operator: {firstOperator}");

                    //            Console.WriteLine();
                    //            Console.WriteLine("Type the second operator");
                    //            if (!int.TryParse(Console.ReadLine(), out int secondOperator))
                    //            {
                    //                Console.WriteLine("Wrong operator, Calculator restart ...");
                    //                continue;
                    //            }
                    //            Console.WriteLine($"Second operator: {secondOperator}");

                    //            int result = operation switch
                    //            {
                    //                "+" => firstOperator + secondOperator,
                    //                "/" => firstOperator / secondOperator,
                    //                _ => throw new InvalidOperationException("Operation not allowed")
                    //            };
                    //            Console.WriteLine();
                    //            Console.WriteLine($"The result of : {firstOperator} {operation} {secondOperator} is {result}");
            //    }
            //    catch (DivideByZeroException e)
            //    {
            //        Console.WriteLine($"The second operator must not be 0 ... {e.StackTrace}");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine($"Generic error ...  {e.StackTrace}");
            //        throw;
            //    }
            //} while (operation != _operations["ESC"]);

        }
    }
}

