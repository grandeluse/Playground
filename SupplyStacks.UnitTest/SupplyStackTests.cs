using FluentAssertions;
using SupplyStack.Model;

namespace SupplyStacks.UnitTest;

public class SupplyStackTests
{
    private readonly SupplyStack<string> _sut;
    public SupplyStackTests()
    {
        _sut = new SupplyStack<string>();
        _sut.Push("A");
        _sut.Push("B");
        _sut.Push("C");
    }
    
    [Fact]
    public void Print_ShouldPrint_WhenCalled()
    {
        // Arrange
        var expected = "ABC";
        // Act
        var actual =_sut.Print();
        
        // Assert
        actual.Should().Be(expected);
    }
}