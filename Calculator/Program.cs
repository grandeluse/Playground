using Calculator;
using Calculator.Services;

var console = new ConsoleManager();
var calculator = new MyCalculator(console);

calculator.Start();
