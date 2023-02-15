using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.APP;
using Xunit;

namespace XUnitTest.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void AddTest()
        {
            //Arrange
            int a = 1;
            int b = 2;

            var calculator = new Calculator();

            //Act
            var total = calculator.Add(a, b);

            //Assert
            Assert.NotEqual<int>(5, total);
        }
    }
}
