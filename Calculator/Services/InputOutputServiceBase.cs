using System;
namespace Calculator.Services
{
	public abstract class InputOutputServiceBase : IInputOutputService
	{
        public abstract string ReadLine();

        public abstract void WriteLine();

        public abstract void WriteLine(string value);

        public abstract void PrintPresentation(Dictionary<string, string> oprations);
        
    }
}

