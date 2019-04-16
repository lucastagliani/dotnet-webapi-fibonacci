using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_fibonacci.Services
{
    public class FibonacciService
    {
        public int[] GenerateFibonacci(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("The limit must be greater than one.");
            }

            return new int[] { 1, 1, 2, 3, 5, 8 };
        }
    }
}
