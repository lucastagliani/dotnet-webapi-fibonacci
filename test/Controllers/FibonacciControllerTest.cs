using dotnet_webapi_fibonacci.Controllers;
using dotnet_webapi_fibonacci.Interfaces;
using Moq;
using Xunit;

namespace dotnet_webapi_fibonacci_test
{
    public class FibonacciControllerTest
    {
        readonly FibonacciController controller;
        readonly Mock<IFibonacciService> service;

        public FibonacciControllerTest()
        {
            service = new Mock<IFibonacciService>();
            controller = new FibonacciController(service.Object);
        }

        [Fact]
        public void Until_Nothing_OkAndData()
        {
            var response = controller.Until(42);
            Assert.False(response.Value.HasError);
        }
    }
}
