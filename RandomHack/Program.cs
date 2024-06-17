// See https://aka.ms/new-console-template for more information


/*
 ================================ USE THIS FOR LoopPerformance.cs =========================
using BenchmarkDotNet.Running;
using RandomHack.LoopPerformance;

BenchmarkRunner.Run<LoopPerformance>();
*/


using RandomHack.FluentBuilderDesignPatter;

Console.WriteLine("Fluent Builder pattern");

var order = OrderBuilder.Empty()
    .WithNumber(12)
    .CreatedOn(DateTime.UtcNow)
    .ShippedTo(b => b
        .Street("Piazza Muraccio 3")
        .City("Locarno")
        .Zip("6600")
        .State("Ticino")
        .Country("Switzerland"))
    .Build();

Console.WriteLine(order);

var mamyOrder = OrderBuilder.Empty()
    .WithNumber(975)
    .CreatedOn(DateTime.UtcNow.AddDays(-1).AddHours(-2).AddMinutes(-34))
    .ShippedTo(s => s
        .Street("Via Morty 2")
        .City("Paese della Fantasia")
        .Zip("235")
        .State("Luzer")
        .Country("Switzerland"))
    .Build();

Console.WriteLine(mamyOrder.ToString());
    