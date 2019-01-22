using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class StringCalcTests
    {
        [Fact]
        public void AddEmptyReturnZero()
        {
            //Arrange
            var _stringCalc = new StringCalculator();

            //Act
            var result = _stringCalc.Add("");

            //Assert
            Assert.Equal(0, result);
        }     
    }
}
