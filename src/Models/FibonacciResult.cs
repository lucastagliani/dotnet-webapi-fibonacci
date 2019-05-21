using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_webapi_fibonacci.Models
{
    public class FibonacciResult
    {
        public FibonacciResult(int[] data) {
            Data = data;
        }

        public FibonacciResult(string errorMessage) {
            ErrorMessage = errorMessage;
        }

        [BsonElement("data")]
        public int[] Data { get; }

        [BsonElement("errorMessage")]
        public string ErrorMessage { get; }
        
        [BsonElement("hasError")]
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
