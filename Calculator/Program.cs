using Calculator;
using Calculator.Services;

ConsoleService inputOuptService = new();
var calculator = new MyCalculator(inputOuptService);

calculator.Start();
