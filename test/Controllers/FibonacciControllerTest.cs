using dotnet_webapi_fibonacci.Controllers;
using dotnet_webapi_fibonacci.Interfaces;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc.Core;
using dotnet_webapi_fibonacci.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dotnet_webapi_fibonacci_test
{
    public class FibonacciControllerTest
    {
        private readonly FibonacciController _controller;
        private readonly Mock<IFibonacciService> _mockService;

        public FibonacciControllerTest()
        {
            _mockService = new Mock<IFibonacciService>();
            _controller = new FibonacciController(_mockService.Object);
        }

        [Fact]
        public void Until_Nothing_OkAndData()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetFibonacciSequenceUntil(100))
                .Returns(new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 });

            // Act
            var response = _controller.Until();

            // Assert
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(response.Result);
            Assert.Equal(200, okObjectResult.StatusCode);

            FibonacciResult result = Assert.IsType<FibonacciResult>(okObjectResult.Value);
            Assert.False(result.HasError);
        }

        [Fact]
        public void Until_IntMaxValue_BadRequestAndArgumentException()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetFibonacciSequenceUntil(int.MaxValue))
                .Throws(new ArgumentException());

            // Act
            var response = _controller.Until(int.MaxValue);

            // Assert
            BadRequestObjectResult badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(response.Result);
            Assert.Equal(400, badRequestObjectResult.StatusCode);

            FibonacciResult result = Assert.IsType<FibonacciResult>(badRequestObjectResult.Value);
            Assert.True(result.HasError);
        }

        [Fact]
        public void Length_Nothing_OkAndData()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetFibonacciSequenceWithLength(10))
                .Returns(new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 });

            // Act
            var response = _controller.Length();

            // Assert
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(response.Result);
            Assert.Equal(200, okObjectResult.StatusCode);

            FibonacciResult result = Assert.IsType<FibonacciResult>(okObjectResult.Value);
            Assert.False(result.HasError);
        }

        [Fact]
        public void Length_IntMaxValue_BadRequestAndArgumentException()
        {
            // Arrange
            _mockService
                .Setup(s => s.GetFibonacciSequenceWithLength(int.MaxValue))
                .Throws(new ArgumentException());

            // Act
            var response = _controller.Length(int.MaxValue);

            // Assert
            BadRequestObjectResult badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(response.Result);
            Assert.Equal(400, badRequestObjectResult.StatusCode);

            FibonacciResult result = Assert.IsType<FibonacciResult>(badRequestObjectResult.Value);
            Assert.True(result.HasError);
        }
    }
}
