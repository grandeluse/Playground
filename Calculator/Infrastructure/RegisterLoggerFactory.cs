using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Calculator.Infrastructure;

public static class RegisterLoggerFactory
{
    public static IServiceCollection AddLoggerFactory(this IServiceCollection serviceCollection)
    {
        var loggerFactory = LoggerFactory.Create(
            builder => builder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Debug));
        
        serviceCollection.AddSingleton(loggerFactory);
        
        return serviceCollection;
    }
}