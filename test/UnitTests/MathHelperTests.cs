using System;
using System.Diagnostics;
using Servicio.Helpers;
using Xunit;

namespace UnitTests
{
    public class MathHelperTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 6)]
        public void Sumar_ShouldBeCorrectResult(int a, int b, int correctResult)
        {
            //Arrange

            //Act
            var result = MathHelper.Suma(a, b);

            //Assert
            Assert.Equal(correctResult,result);
        }
    }
}
