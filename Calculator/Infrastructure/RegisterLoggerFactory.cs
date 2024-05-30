using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Calculator.Infrastructure;

public static class RegisterLoggerFactory
{
    public static IServiceCollection AddLoggerFactory(this IServiceCollection services)
    {
        var loggerFactory = LoggerFactory.Create(
            builder => builder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Debug));
        
        services.AddSingleton(loggerFactory);
        
        return services;
    }
}