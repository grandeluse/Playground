using Calculator.Services;
using Moq;
using FluentAssertions;

namespace Calculator.UnitTests;

public class MyCalculatorTest
{
    private MyCalculator sut;
    private Mock<IConsoleManager> consoleManagerMock;

    private Dictionary<string, string> _operations = new()
    {
        { "+", "[+] sum" },
        { "/", "[/] division" },
        { "ESC", "[ESC] exit" }
    };
    public MyCalculatorTest()
    {
        consoleManagerMock = new Mock<IConsoleManager>();
        sut = new MyCalculator(consoleManagerMock.Object);
    }
    
    [Fact]
    public void Constructor_ShouldThrowException_WhenConsoleIsNull()
    {
        // Arrange
        
        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(()=> new MyCalculator(null));
    }
    
    [Fact]
    public void Start_ShouldPrintPresentationMessage_WhenCalculatorStart()
    {
        // Arrange

        // Act
        sut.PrintPresentation();

        // Assert
        consoleManagerMock.Verify(x=>x.WriteLine(),Times.Exactly(2));
        consoleManagerMock.Verify(x=>x.WriteLine("Welcome to Calculator"),Times.Once);
        consoleManagerMock.Verify(x=>x.WriteLine("Insert the operation"),Times.Once);
        consoleManagerMock.Verify(x=>x.WriteLine($"Allowed operations are: {string.Join(", ", _operations.Values)}"),Times.Once);
    }
    
}
