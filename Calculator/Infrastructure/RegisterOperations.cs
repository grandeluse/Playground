using Calculator.Services;
using Calculator.Services.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Infrastructure;

public static class RegisterOperations
{
    public static IServiceCollection AddOperations(this IServiceCollection services)
    {
        var operations = typeof(IOperation).Assembly
            .GetTypes()
            .Where(type => type.GetInterfaces()
                .Contains(typeof(IOperation)))
            .ToList();
        
        operations.ForEach(operation=> services.AddTransient(typeof(IOperation),operation));

        return services;
    }
}