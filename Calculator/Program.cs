﻿using Calculator;
using Calculator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(
    builder => builder
        .AddConsole()
        .AddDebug()
        .SetMinimumLevel(LogLevel.Debug)
);

var serviceProvider = new ServiceCollection()
    .AddSingleton(loggerFactory)
    .AddSingleton<IConsoleManager, ConsoleManager>()
    .AddSingleton<ICalculator, MyCalculator>()
    .BuildServiceProvider();

var calculator = serviceProvider.GetService<ICalculator>();
calculator.Start();
