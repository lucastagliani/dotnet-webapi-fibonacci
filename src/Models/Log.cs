using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_webapi_fibonacci.Models
{
    public class Log
    {
        public Log(string algorithm, string parameter, Object objectReturned) 
        {
            Algorithm = algorithm;
            Parameter = parameter;
            ObjectReturned = objectReturned;
            RequestedAt = new BsonDateTime(DateTime.Now);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("algorithm")]
        public string Algorithm { get; }
        
        [BsonElement("parameter")]
        public string Parameter { get; }
        
        [BsonElement("requestedAt")]
        public BsonDateTime RequestedAt { get; }

        [BsonElement("objectReturned")]
        public Object ObjectReturned { get; }
    }
}