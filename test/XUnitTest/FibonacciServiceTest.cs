using dotnet_webapi_fibonacci.Services;
using System;
using Xunit;

namespace XUnitTest
{
    public class FibonacciServiceTest
    {
        [Fact]
        public void GenerateFibonacci_Zero_Exception() // TODO: Actually it should return 0 (?)
        {
            FibonacciService fibonacciService = new FibonacciService();
            Assert.Throws<ArgumentException>(() => fibonacciService.GenerateFibonacciSequenceUntil(0));
        }

        [Fact]
        public void GenerateFibonacci_UntilMaxInt_Exception()
        {
            FibonacciService fibonacciService = new FibonacciService();
            Assert.Throws<ArgumentException>(() => fibonacciService.GenerateFibonacciSequenceUntil(int.MaxValue));
        }

        [Fact]
        public void GenerateFibonacci_Until10_Until8()
        {
            FibonacciService fibonacciService = new FibonacciService();

            int[] expectedData = new int[] { 0, 1, 1, 2, 3, 5, 8 };
            int[] actualData = fibonacciService.GenerateFibonacciSequenceUntil(10);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GenerateFibonacci_Until35_Until34()
        {
            FibonacciService fibonacciService = new FibonacciService();

            int[] expectedData = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            int[] actualData = fibonacciService.GenerateFibonacciSequenceUntil(35);

            Assert.Equal(expectedData, actualData);
        }
    }
}
