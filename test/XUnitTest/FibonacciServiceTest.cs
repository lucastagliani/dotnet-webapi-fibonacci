using dotnet_webapi_fibonacci.Services;
using System;
using Xunit;

namespace XUnitTest
{
    public class FibonacciServiceTest
    {
        [Fact]
        public void GenerateFibonacci_Until10_Until8()
        {
            FibonacciService fibonacciService = new FibonacciService();

            int[] expectedData = new int[] { 1, 1, 2, 3, 5, 8 };
            int[] actualData = fibonacciService.GenerateFibonacci(10);

            Assert.Equal(expectedData, actualData);
        }
    }
}
