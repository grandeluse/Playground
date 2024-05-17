using Moq;
using FluentAssertions;

namespace Calculator.UnitTests;

public class MyCalculatorTest
{
    private readonly ICalculator _sut;

    public MyCalculatorTest()
    {
        _sut = new MyCalculator();
    }

    [Fact]
    public void Start_ShouldCalled_WhenCalculatorStart()
    {
        // Arrange
        var mock = new Mock<ICalculator>();

        // Act
        _sut.Start();

        // Assert
        mock.Verify(x => x.Start(), Times.Once);
    }
}
