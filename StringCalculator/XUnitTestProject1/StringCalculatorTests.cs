using StringCalculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class StringCalculatorTests
    {
        [Fact]
        public void AddEmptyReturn0()
        {
            //Arrange
            var _stringCalc = new Calculator();

            //Act
            var result =_stringCalc.Add("");

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddOneNumberReturn0()
        {
            //Arrange
            var _stringCalc = new Calculator();

            //Act
            var result = _stringCalc.Add("1");

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddTwoNumberReturn0()
        {
            //Arrange
            var _stringCalc = new Calculator();

            //Act
            var result = _stringCalc.Add("1,2");

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add12_3Return6()
        {
            //Arrange
            var _stringCalc = new Calculator();

            //Act
            var result = _stringCalc.Add("1,2\n3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add1_23Return6()
        {
            //Arrange
            var _stringCalc = new Calculator();

            //Act
            var result = _stringCalc.Add("1\n2,3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void AddNegativeNumbersThrowException()
        {
            //Arrange 
            var _stringCalc = new Calculator();

            //Act
            var ex1 = Record.Exception(() => _stringCalc.Add("-1\n2,3"));
            var ex2 = Record.Exception(() => _stringCalc.Add("1\n-2,-3"));
            //Assert 
            Assert.NotNull(ex1);
            Assert.NotNull(ex2);
        }

        [Fact]
        public void AddOnlyPositiveNumbersThrowNoException()
        {
            //Arrange 
            var _stringCalc = new Calculator();

            //Act
            var ex = Record.Exception(() => _stringCalc.Add("1\n2,3"));

            //Assert 
            Assert.Null(ex);
        }
    }
}
