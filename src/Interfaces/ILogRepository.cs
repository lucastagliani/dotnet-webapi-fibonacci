using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_fibonacci.Models;

namespace dotnet_webapi_fibonacci.Interfaces
{
    public interface ILogRepository
    {
        List<Log> Get();

        Log Get(string id);

        Log Create(Log log);

        void Update(string id, Log logIn);

        void Remove(Log logIn);

        void Remove(string id);
    }
}
