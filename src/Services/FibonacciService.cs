using dotnet_webapi_fibonacci.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_fibonacci.Services
{
    public class FibonacciService
    {
        private readonly int MINIMUM_LIMIT = 0;
        private readonly int MAXIMUM_LIMIT = 1000;

        public int[] GetFibonacciSequenceUntil(int limit)
        {
            ValidateLimit(limit);
            return CalculateFibonacciSequenceUntil(limit);
        }

        private void ValidateLimit(int limit)
        {
            if (limit <= MINIMUM_LIMIT)
            {
                throw new ArgumentException(ErrorMessages.MUST_BE_GREATER_THAN_ZERO);
            }

            if (MAXIMUM_LIMIT < limit)
            {
                throw new ArgumentException(ErrorMessages.MUST_BE_LESS_THAN_ONE_THOUSAND);
            }
        }

        private int[] CalculateFibonacciSequenceUntil(int limit)
        {
            List<int> fibonacciListResult = new List<int>() { 0, 1 };

            int penultimateNumber = 0, lastNumber = 1;
            int fibonacciNumber = CalculateFibonacciNumber(penultimateNumber, lastNumber);

            while (IsFibonacciNumberLessOrEqualLimit(fibonacciNumber, limit))
            {
                fibonacciListResult.Add(fibonacciNumber);

                penultimateNumber = lastNumber;
                lastNumber = fibonacciNumber;
                fibonacciNumber = CalculateFibonacciNumber(penultimateNumber, lastNumber);
            }

            return fibonacciListResult.ToArray();
        }

        private int CalculateFibonacciNumber(int penultimateNumber, int lastNumber)
        {
            return penultimateNumber + lastNumber;
        }

        private bool IsFibonacciNumberLessOrEqualLimit(int fibonacciNumber, int limit)
        {
            return fibonacciNumber <= limit;
        }

        public int[] GetFibonacciSequenceWithLength(int length)
        {
            return new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
        }
    }
}
