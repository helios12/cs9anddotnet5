using System;
using Xunit;

using PrimeFactorsLib;

namespace PrimeFactorsUnitTests
{
    public class PrimeFactorUnitTest
    {
        [Fact]
        public void Test17()
        {
            int number = 17;
            string expectedResult = "17";
            PrimeFactors pf = new PrimeFactors();
            string actualResult = pf.GetPrimeFactors(number);
            Assert.Equal(expectedResult, actualResult);    
        }

        [Fact]
        public void Test4()
        {
            int number = 4;
            string expectedResult = "2 x 2";
            PrimeFactors pf = new PrimeFactors();
            string actualResult = pf.GetPrimeFactors(number);
            Assert.Equal(expectedResult, actualResult);    
        }

        [Fact]
        public void Test7()
        {
            int number = 7;
            string expectedResult = "7";
            PrimeFactors pf = new PrimeFactors();
            string actualResult = pf.GetPrimeFactors(number);
            Assert.Equal(expectedResult, actualResult);    
        }

        [Fact]
        public void Test30()
        {
            int number = 30;
            string expectedResult = "5 x 3 x 2";
            PrimeFactors pf = new PrimeFactors();
            string actualResult = pf.GetPrimeFactors(number);
            Assert.Equal(expectedResult, actualResult);    
        }

        [Fact]
        public void Test40()
        {
            int number = 40;
            string expectedResult = "5 x 2 x 2 x 2";
            PrimeFactors pf = new PrimeFactors();
            string actualResult = pf.GetPrimeFactors(number);
            Assert.Equal(expectedResult, actualResult);    
        }

        [Fact]
        public void Test50()
        {
            int number = 50;
            string expectedResult = "5 x 5 x 2";
            PrimeFactors pf = new PrimeFactors();
            string actualResult = pf.GetPrimeFactors(number);
            Assert.Equal(expectedResult, actualResult);    
        }
    }
}
