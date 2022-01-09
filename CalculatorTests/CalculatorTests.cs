using Xunit;
using CalculatorV2.Models;

namespace CalculatorV2Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("2 * 2", 4)]
        [InlineData("1 + 2 + 3", 6)]
        [InlineData("6 / 2", 3)]
        [InlineData("11 + 23", 34)]
        [InlineData("11.1 + 23", 34.1)]
        [InlineData("1 + 1 * 3", 4)]
        [InlineData("( 11.5 + 15.4 ) + 10.1", 37)]
        [InlineData("23 - ( 29.3 - 12.5 )", 6.2)]
        [InlineData("( 1 / 2 ) - 1 + 1", 0.5)]
        [InlineData("( 10 - 2 * 3 + ( 2 + 3 * ( 7 - 5 ) ) )", 12)]
        [InlineData("10 - ( 2 + 3 * ( 7 - 5 ) )", 2)]
        public void Test_Calculator(string sum, double expected)
        {
            // Arrange
            var _calculator = new Calculator();

            // Act
            var _actual = _calculator.Calculate(sum);

            // Assert
            Assert.Equal(expected, _actual);
        }
    }
}
