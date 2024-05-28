using Moq;
using FluentAssertions;
using Calculator.Services;

namespace Calculator.UnitTests;

public class MyCalculatorTest
{
    private readonly ICalculator _sut;
    private readonly Mock<IInputOutputService> _consoleServiceMock = new Mock<IInputOutputService>(MockBehavior.Strict);

    public MyCalculatorTest()
    {
        _sut = new MyCalculator(_consoleServiceMock.Object);
    }

    [Fact]
    public void Start_ShouldPrintPresentationMessage_WhenCalculatorStart()
    {
        // Arrange

        var operations = new Dictionary<string,string>
            {
                {"+","[+] sum" },
                {"/","[/] division" },
                {"ESC", "[ESC] exit" }
            };

        _consoleServiceMock.Setup(x => x.PrintPresentation(It.IsAny<Dictionary<string, string>>()));

        // Act
        _sut.Start();

        // Assert
        _consoleServiceMock.Verify(x => x.PrintPresentation(operations), Times.AtLeastOnce);
    }
}
