using System.Collections.Concurrent;

namespace CSharpDeepDive.OOP.Interfaces;

public interface IHasDoor
{
    int NumberOfDoors { get; }
    void OpenDoor(int doorIndex);
    void CloseDoor(int doorIndex);
    bool IsDoorOpen(int doorIndex);
}

public interface IMotorized 
{
    bool IsEngineRunning { get; }
    void StartEngine();
    void StopEngine();
}

public class Bicycle
{
    
}

public class Motorcycle : IMotorized
{
    public bool IsEngineRunning { get; private set; }
    public void StartEngine()
    {
        if (IsEngineRunning)
        {
            return;
        }

        IsEngineRunning = true;
        Console.WriteLine("Engine started!");
    }

    public void StopEngine()
    {
        if (!IsEngineRunning)
        {
            return;
        }

        IsEngineRunning = false;
        Console.WriteLine("Engine Stopped!");
    }
}

public class Room : IHasDoor
{
    private readonly bool[] _doors;

    public Room(int numberOfDoors)
    {
        _doors = new bool[numberOfDoors];
    }

    public int NumberOfDoors => _doors.Length;
    
    public void OpenDoor(int doorIndex)
    {
        _doors[doorIndex] = true;
    }

    public void CloseDoor(int doorIndex)
    {
        _doors[doorIndex] = false;
    }

    public bool IsDoorOpen(int doorIndex)
    {
        return _doors[doorIndex];
    }
}

public class Car : IHasDoor, IMotorized
{
    private readonly bool[] _doors;

    public Car(int numberOfDoors)
    {
        _doors = new bool[numberOfDoors];
    }

    public int NumberOfDoors => _doors.Length;
    
    public void OpenDoor(int doorIndex)
    {
        _doors[doorIndex] = true;
    }

    public void CloseDoor(int doorIndex)
    {
        _doors[doorIndex] = false;
    }

    public bool IsDoorOpen(int doorIndex)
    {
        return _doors[doorIndex];
    }

    public bool IsEngineRunning { get; private set; }
    public void StartEngine()
    {
        if (IsEngineRunning)
        {
            return;
        }

        IsEngineRunning = true;
        Console.WriteLine("Engine Started!");
    }

    public void StopEngine()
    {
        if (!IsEngineRunning)
        {
            return;
        }

        IsEngineRunning = false;
        Console.WriteLine("Engine Stopped!");
    }
}