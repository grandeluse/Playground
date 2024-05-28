using System;
namespace Calculator.Services
{
	public interface IInputOutputService
	{
		public string ReadLine();
        public void WriteLine();
        public void WriteLine(string value);
        public void PrintPresentation(Dictionary<string, string> operations);
    }
}

