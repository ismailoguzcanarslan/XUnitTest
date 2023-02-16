using Moq;
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
        private Calculator _calculator { get; set; }
        private Mock<ICalculatorService> mymock { get; set; }
        public CalculatorTest()
        {
            mymock = new Mock<ICalculatorService>();
            _calculator = new Calculator(mymock.Object);
        }

        [Fact]
        public void AddTest()
        {
            //Arrange
            int a = 1;
            int b = 2;

            //Act
            var total = _calculator.Add(a, b);

            //Assert
            Assert.NotEqual<int>(5, total);
        }

        [Theory]
        [InlineData(2,5,7)]
        [InlineData(10,2,12)]
        public void Add_SimpleValues_ReturnToTotalValue(int a, int b, int total) 
        {
            mymock.Setup(x => x.Add(a, b)).Returns(total);

            var ttl = _calculator.Add(a, b);

            Assert.Equal<int>(total, ttl);
            Assert.Equal<int>(total, ttl);
            mymock.Verify(x => x.Add(a,b),Times.Once);
        }

        [Theory]
        [InlineData(-2, 5, 0)]
        [InlineData(10, -2, 0)]
        public void Add_LessThenZeroValues_ReturnToZeroValue(int a, int b, int total)
        {
            var ttl = _calculator.Add(a, b);

            Assert.Equal<int>(total, ttl);
        }

        [Theory]
        [InlineData(2, 5, 10)]
        public void Mult_SimpleValues_ReturnToTotalValue(int a, int b, int total)
        {
            int actualMultip = 0;

            mymock.Setup(x => x.Mult(It.IsAny<int>(), It.IsAny<int>())).Callback<int,int>((x,y)=> actualMultip = x * y);

            var ttl = _calculator.Mult(a, b);

            Assert.Equal<int>(15, actualMultip);


        }

        [Theory]
        [InlineData(0, 5)]
        public void Mult_ZeroValues_ReturnException(int a, int b)
        {
            mymock.Setup(x => x.Mult(a, b)).Throws(new Exception("HATA!!"));

            Exception exception = Assert.Throws<Exception>(()=>_calculator.Mult(a,b));

            Assert.Equal("HATA!!", exception.Message);

        }
    }
}
