
var monday = (int)DaysOfWeek.Monday;
Console.WriteLine($"Enum value Directly: {DaysOfWeek.Monday}");
Console.WriteLine($"Enum value Casted: {(int)DaysOfWeek.Monday}");

string mondayString = DaysOfWeek.Monday.ToString();

DaysOfWeek mondayEnum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Monday");
DaysOfWeek mondayEnum2 = Enum.Parse<DaysOfWeek>("Monday");

DaysOfWeek mondayEnum3;
bool parseSucceeded = Enum.TryParse("Monday", out mondayEnum3);
Console.WriteLine($"Enum {(parseSucceeded ? "Was parsed" : "Was not parsed")}: {mondayEnum3}");

Console.WriteLine();

DaysOfWeek2 fridayEnum2;
bool parseSucceeded2 = Enum.TryParse("friday", out fridayEnum2);
Console.WriteLine($"Enum2 {(parseSucceeded2 ? "Was parsed" : "Was not parsed")}: {fridayEnum2}");

Console.WriteLine("All Enum values:");
foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
{
    Console.WriteLine($"Enum Value: {day}");
}

Console.WriteLine("All Enum Names");
foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
{
    Console.WriteLine($"Enum Name: {day}");
}

enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

enum DaysOfWeek2
{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}


