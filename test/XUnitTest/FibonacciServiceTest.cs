using dotnet_webapi_fibonacci.Contants;
using dotnet_webapi_fibonacci.Services;
using System;
using Xunit;

namespace XUnitTest
{
    public class FibonacciServiceTest
    {
        [Fact]
        public void GetFibonacciSequenceUntil_Zero_Exception()
        {
            FibonacciService fibonacciService = new FibonacciService();
            Exception exception = Assert.Throws<ArgumentException>(() => 
                fibonacciService.GetFibonacciSequenceUntil(0));
            Assert.Equal(ErrorMessages.MUST_BE_GREATER_THAN_ZERO, exception.Message);
        }

        [Fact]
        public void GetFibonacciSequenceUntil_MaxInt_Exception()
        {
            FibonacciService fibonacciService = new FibonacciService();
            Exception exception = Assert.Throws<ArgumentException>(() => 
                fibonacciService.GetFibonacciSequenceUntil(int.MaxValue));
            Assert.Equal(ErrorMessages.MUST_BE_LESS_THAN_ONE_THOUSAND, exception.Message);
        }

        [Fact]
        public void GetFibonacciSequenceUntil_1_FibonacciSequenceUntil1()
        {
            FibonacciService fibonacciService = new FibonacciService();

            int[] expectedData = new int[] { 0, 1, 1 };
            int[] actualData = fibonacciService.GetFibonacciSequenceUntil(1);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetFibonacciSequenceUntil_10_FibonacciSequenceUntil8()
        {
            FibonacciService fibonacciService = new FibonacciService();

            int[] expectedData = new int[] { 0, 1, 1, 2, 3, 5, 8 };
            int[] actualData = fibonacciService.GetFibonacciSequenceUntil(10);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetFibonacciSequenceUntil_35_FibonacciSequenceUntil34()
        {
            FibonacciService fibonacciService = new FibonacciService();

            int[] expectedData = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            int[] actualData = fibonacciService.GetFibonacciSequenceUntil(35);

            Assert.Equal(expectedData, actualData);
        }
    }
}
