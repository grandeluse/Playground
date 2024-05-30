using Calculator.Services;
using Calculator.Services.Operations;
using Moq;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace Calculator.UnitTests;

public class MyCalculatorTest
{
    private readonly MyCalculator sut;
    private readonly Mock<IConsoleManager> consoleManagerMock;
    private readonly Mock<IOperationFactory> operationFactoryMock;
    private readonly ILoggerFactory loggerFactory;
    
    private Dictionary<string, string> _operations = new()
    {
        { "+", "[+] sum" },
        { "/", "[/] division" },
        { "ESC", "[ESC] exit" }
    };
    public MyCalculatorTest()
    {
        consoleManagerMock = new Mock<IConsoleManager>();
        operationFactoryMock = new Mock<IOperationFactory>(MockBehavior.Strict);
        loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        sut = new MyCalculator(consoleManagerMock.Object, operationFactoryMock.Object, loggerFactory);
    }
    
    [Fact]
    public void Constructor_ShouldThrowException_WhenConsoleIsNull()
    {
        // Arrange
        
        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(()=> new MyCalculator(null, operationFactoryMock.Object, loggerFactory));
    }
    
    [Fact]
    public void Constructor_ShouldThrowException_WhenOperationFactoryIsNull()
    {
        // Arrange
        
        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(()=> new MyCalculator(consoleManagerMock.Object, null, loggerFactory));
    }
    
    [Fact]
    public void Constructor_ShouldThrowException_WhenLoggerFactoryIsNull()
    {
        // Arrange
        
        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(()=> new MyCalculator(consoleManagerMock.Object, operationFactoryMock.Object, null));
    }
    
    [Fact]
    public void PrintPresentation_ShouldPrintCorrectMessages_WhenCalculatorCalled()
    {
        // Arrange

        // Act
        sut.PrintPresentation();

        // Assert
        consoleManagerMock.Verify(x=>x.WriteLine(), Times.Exactly(2));
        consoleManagerMock.Verify(x=>x.WriteLine("Welcome to Calculator"), Times.Once);
        consoleManagerMock.Verify(x=>x.WriteLine("Insert the operation"), Times.Once);
        consoleManagerMock.Verify(x=>x.WriteLine($"Allowed operations are: {string.Join(", ", _operations.Values)}"), Times.Once);
    }

    [Fact]
    public void TryReadOperation_ShouldRestartCalculator_WhenOperationIsNull()
    {
        // Arrange
        consoleManagerMock.Setup(x => x.ReadLine())
            .Returns<string?>(null!);

        // Act
        var outcome = sut.TryReadOperation();

        // Assert
        outcome.result.Should().BeFalse();
        outcome.operation.Should().BeNull();
        outcome.operationValue.Should().BeNull();
        
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operation, Calculator restart ..."), Times.Once);
    }

    [Fact]
    public void TryReadOperation_ShouldRestartCalculator_WhenOperationIsNotAllowed()
    {
        // Arrange
        consoleManagerMock.Setup(x => x.ReadLine())
            .Returns("aaa");

        // Act
        var outcome = sut.TryReadOperation();

        // Assert
        outcome.result.Should().BeFalse();
        outcome.operation.Should().BeNull();
        outcome.operationValue.Should().BeNull();
        
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operation, Calculator restart ..."), Times.Once);
    }
    
    [Fact]
    public void TryReadOperation_ShouldReturnSumEntry_WhenOperationIsSum()
    {
        // Arrange
        consoleManagerMock.Setup(x => x.ReadLine())
            .Returns("+");

        // Act
        var outcome = sut.TryReadOperation();

        // Assert
        outcome.result.Should().BeTrue();
        outcome.operation.Should().Be("+");
        outcome.operationValue.Should().Be("[+] sum");
        
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operation, Calculator restart ..."), Times.Never);
    }
    
    [Fact]
    public void TryReadOperation_ShouldReturnDivisionEntry_WhenOperationIsDivision()
    {
        // Arrange
        consoleManagerMock.Setup(x => x.ReadLine())
            .Returns("/");

        // Act
        var outcome = sut.TryReadOperation();

        // Assert
        outcome.result.Should().BeTrue();
        outcome.operation.Should().Be("/");
        outcome.operationValue.Should().Be("[/] division");
        
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operation, Calculator restart ..."), Times.Never);
    }
    
    [Fact]
    public void TryReadOperation_ShouldReturnEscEntry_WhenOperationIsEsc()
    {
        // Arrange
        consoleManagerMock.Setup(x => x.ReadLine())
            .Returns("ESC");

        // Act
        var outcome = sut.TryReadOperation();

        // Assert
        outcome.result.Should().BeTrue();
        outcome.operation.Should().Be("ESC");
        outcome.operationValue.Should().Be("[ESC] exit");
        
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operation, Calculator restart ..."), Times.Never);
    }

    [Fact]
    public void Start_ShouldRestartCalculator_WhenFirstOperatorIsNotValid()
    {
        // Arrange
        consoleManagerMock.SetupSequence(x => x.ReadLine())
            .Returns("+")
            .Returns("not valid operator")
            .Returns("ESC");

        // Act
        sut.Start();
        
        // Assert
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operator, Calculator restart ..."), Times.Once);
    }
    
    [Fact]
    public void Start_ShouldRestartCalculator_WhenSecondOperatorIsNotValid()
    {
        // Arrange
        consoleManagerMock.SetupSequence(x => x.ReadLine())
            .Returns("+")
            .Returns("3")
            .Returns("not valid operator")
            .Returns("ESC");

        // Act
        sut.Start();
        
        // Assert
        consoleManagerMock.Verify(x=>x.WriteLine("Wrong operator, Calculator restart ..."), Times.Once);
    }
    
    [Fact]
    public void Start_ShouldPrintCorrectResult_WhenOperationIsSum()
    {
        // Arrange
        consoleManagerMock
            .SetupSequence(x => x.ReadLine())
            .Returns("+")
            .Returns("3")
            .Returns("5")
            .Returns("ESC");

        operationFactoryMock
            .Setup(x => x.GetOperation("+"))
            .Returns(new AdditionOperation());

        // Act
        sut.Start();
        
        // Assert
        consoleManagerMock.Verify(x=>x.WriteLine("The result of : 3 + 5 is 8"), Times.Once);
    }
    
    [Fact]
    public void Start_ShouldShowErrorMessage_WhenOperationIsDivisionAndSecondOperatorIsZero()
    {
        // Arrange
        consoleManagerMock.SetupSequence(x => x.ReadLine())
            .Returns("/")
            .Returns("3")
            .Returns("0")
            .Returns("ESC");
        
        operationFactoryMock
            .Setup(x => x.GetOperation("/"))
            .Returns(new DivisionOperation());

        // Act
        sut.Start();
        
        // Assert
        consoleManagerMock.Verify(x=>x.WriteLine("The second operator must not be 0 in division operation ..."), Times.Once);
    }


}
