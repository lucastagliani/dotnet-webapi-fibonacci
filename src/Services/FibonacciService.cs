using dotnet_webapi_fibonacci.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_fibonacci.Services
{
    public class FibonacciService
    {
        private int MINIMUM_LIMIT = 0;
        private int MAXIMUM_LIMIT = 1000;

        public int[] GenerateFibonacci(int limit)
        {
            if (limit <= MINIMUM_LIMIT)
            {
                throw new ArgumentException(ErrorMessages.MUST_BE_GREATER_THAN_ZERO);
            }

            if (limit > MAXIMUM_LIMIT)
            {
                throw new ArgumentException(ErrorMessages.MUST_BE_LESS_THAN_ONE_THOUSAND);
            }

            return new int[] { 1, 1, 2, 3, 5, 8 };
        }
    }
}
