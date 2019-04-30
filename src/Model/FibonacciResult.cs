using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_fibonacci.Model
{
    public class FibonacciResult
    {
        public FibonacciResult(int[] data) {
            Data = data;
        }

        public FibonacciResult(string errorMessage) {
            ErrorMessage = errorMessage;
        }

        public int[] Data { get; }
        public string ErrorMessage { get; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
