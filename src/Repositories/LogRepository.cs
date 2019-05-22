using System.Collections.Generic;
using System.Linq;
using dotnet_webapi_fibonacci.Interfaces;
using dotnet_webapi_fibonacci.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace dotnet_webapi_fibonacci.Services
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logs;

        public LogRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("fibonacci-db-prd"));
            var database = client.GetDatabase("fibonacci-db");
            _logs = database.GetCollection<Log>("logs");
        }

        public List<Log> Get()
        {
            return _logs.Find(log => true).ToList();
        }

        public Log Get(string id)
        {
            return _logs.Find<Log>(log => log.Id == id).FirstOrDefault();
        }

        public Log Create(Log log)
        {
            _logs.InsertOne(log);
            return log;
        }

        public void Update(string id, Log logIn)
        {
            _logs.ReplaceOne(log => log.Id == id, logIn);
        }

        public void Remove(Log logIn)
        {
            _logs.DeleteOne(log => log.Id == logIn.Id);
        }

        public void Remove(string id)
        {
            _logs.DeleteOne(log => log.Id == id);
        }
    }
}