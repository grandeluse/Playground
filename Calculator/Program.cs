using Calculator;
using Calculator.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConsoleManager, ConsoleManager>()
    .AddSingleton<ICalculator, MyCalculator>()
    .BuildServiceProvider();

var calculator = serviceProvider.GetService<ICalculator>();
calculator.Start();
