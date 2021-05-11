using System;
using Xunit;

using Packt.Shared;

namespace Excercise03UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 123450;
            string actualResult = a.GetNumberDescription();
            string expectedResult = "one hundred twenty three thousand, four hundred fifty";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
