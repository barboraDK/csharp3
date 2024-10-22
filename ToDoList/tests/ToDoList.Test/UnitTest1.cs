namespace ToDoList.Test;

public class UnitTest1
{
    [Fact]
    public void Divide_WithoutReminder_Succeeds()
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var result = calculator.Divide(10, 5);


        // Assert
        Assert.Equal(2, result);
    }
    [Fact]
    public void DivideInt_ByZero_ThrowsException()
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var divideAction = () => calculator.Divide(10, 0);


        // Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }
    [Theory]
    [InlineData(10, 2)]
    [InlineData(9, 3)]
    [InlineData(9, -3)]
    public void Divide_WithoutReminder_ReturnCorrectNumber_Parametrized(int value1, int value2)
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var result = calculator.Divide(value1, value2);
        var expectedResult = value1 / value2;


        // Assert
        Assert.Equal(expectedResult, result);
    }
}

public class Calculator
{
    public int Divide(int dividend, int divisor)
    {
        return dividend / divisor;
    }
}
