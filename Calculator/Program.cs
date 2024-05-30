using Calculator;
using Calculator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddLoggerFactory()
    .AddOperations()
    .AddMainServices()
    .BuildServiceProvider();

var calculator = serviceProvider.GetService<ICalculator>();
calculator.Start();
