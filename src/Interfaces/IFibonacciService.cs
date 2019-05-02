using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_fibonacci.Interfaces
{
    public interface IFibonacciService
    {
        int[] GetFibonacciSequenceUntil(int limit);

        int[] GetFibonacciSequenceWithLength(int length);
    }
}
