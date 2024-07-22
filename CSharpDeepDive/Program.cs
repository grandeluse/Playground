﻿List<string> ourList = new()
{
    "Hello",
    "World"
};

void DoSomethingWithReference(List<string> list)
{
    list.Add("From");
    list.Add("Nick");
}

Console.WriteLine("Reference Before:");
foreach (var item in ourList)
{
    Console.WriteLine(item);
}

DoSomethingWithReference(ourList);

Console.WriteLine("Reference After:");
foreach (var item in ourList)
{
    Console.WriteLine(item);
}

string ourString = "Hello World!";

void DoSomethingWithValue(string value)
{
    value = "Goodbye World!";
}

Console.Write("Value Before: ");
Console.WriteLine(ourString);

DoSomethingWithValue(ourString);

Console.Write("Value After: ");
Console.WriteLine(ourString);

void DoSomethingWithValueByRef(ref string value)
{
    value = "Goodbye World!";
}

Console.Write("Value Before By Ref: ");
Console.WriteLine(ourString);

DoSomethingWithValueByRef(ref ourString);

Console.Write("Value After By Ref: ");
Console.WriteLine(ourString);

