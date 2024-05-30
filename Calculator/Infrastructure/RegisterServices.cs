using System.Reflection.Metadata.Ecma335;
using Calculator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection AddMainServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IConsoleManager, ConsoleManager>();
        serviceCollection.AddSingleton<ICalculator, MyCalculator>();
        serviceCollection.AddSingleton<IOperationFactory, OperationFactory>();
        return serviceCollection;
    }
}