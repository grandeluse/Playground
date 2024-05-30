using System.Reflection.Metadata.Ecma335;
using Calculator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection AddMainServices(this IServiceCollection services)
    {
        services.AddSingleton<IConsoleManager, ConsoleManager>();
        services.AddSingleton<ICalculator, MyCalculator>();
        services.AddSingleton<IOperationFactory, OperationFactory>();
        return services;
    }
}