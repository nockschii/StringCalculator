using StringCalculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class StringCalculatorTests
    {
        IStringCalculator _stringCalc;

        public StringCalculatorTests()
        {
            //Arrange
            _stringCalc = new Calculator();
        }

        [Fact]
        public void AddEmptyReturn0()
        {
            //Act
            var result =_stringCalc.Add("");

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddOneNumberReturn0()
        {
            //Act
            var result = _stringCalc.Add("1");

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void AddTwoNumbersReturnSum()
        {
            //Act
            var result = _stringCalc.Add("1,2");

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add12_3Return6()
        {     
            //Act
            var result = _stringCalc.Add("1,2\n3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add1_23Return6()
        {
            //Act
            var result = _stringCalc.Add("1\n2,3");

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void AddNegativeNumbersThrowException()
        {
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
            //Act
            var ex = Record.Exception(() => _stringCalc.Add("1\n2,3"));

            //Assert 
            Assert.Null(ex);
        }

        [Fact]
        public void AddHandleUnknownAmountOfNumbers()
        {
            //Act
            var result = _stringCalc.Add("1,2,3,4,5,6,7,8,9");

            //Assert
            Assert.Equal(45, result);
        }
    }
}
