using BenchmarkDotNet.Attributes;

namespace RandomHack.LoopPerformance;

[MemoryDiagnoser(false)]
public class LoopPerformance
{
    private const int Size = 1_000_000;
    private readonly string[] _list = new string[Size];

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(420);
        for (var i = 0; i < Size; i++)
        {
            _list[i] = random.Next().ToString();
        }
    }

    [Benchmark]
    public string For()
    {
        var result = string.Empty;
        var size = _list.Length;
        for (var i = 0; i < size; i++)
        {
            result = _list[i];
        }

        return result;
    }

    [Benchmark]
    public string Foreach()
    {
        var result = string.Empty;
        foreach (var item in _list)
        {
            return result;
        }

        return result;
    }
}