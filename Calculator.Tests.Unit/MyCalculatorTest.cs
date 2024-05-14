namespace Calculator.Tests.Unit;

public class MyCalculatorTest
{
    private readonly MyCalculator _sut;

    public MyCalculatorTest()
    {
        _sut = new();
    }

    [Fact]
    public void MyCalculatorShouldStart()
    {
        _sut.Start();
    }
}
