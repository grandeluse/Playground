using CSharpDeepDive.OOP.Interfaces;

Motorcycle motorcycle = new();
motorcycle.StartEngine();
Console.WriteLine(motorcycle.IsEngineRunning);

motorcycle.StopEngine();
Console.WriteLine(motorcycle.IsEngineRunning);

motorcycle.StopEngine();
Console.WriteLine(motorcycle.IsEngineRunning);

IMotorized motorized = motorcycle;
motorized.StartEngine();
Console.WriteLine(motorized.IsEngineRunning);

Motorcycle motorcycle2 = (Motorcycle)motorized;
Console.WriteLine(motorcycle2.IsEngineRunning);
motorcycle2.StopEngine();
Console.WriteLine(motorcycle2.IsEngineRunning);