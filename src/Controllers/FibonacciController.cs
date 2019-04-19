﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_fibonacci.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_fibonacci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        FibonacciService fibonacciService; 

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<int>> Get()
        {
            fibonacciService = new FibonacciService();
            int defaultLimit = 100;

            return fibonacciService.GenerateFibonacciSequenceUntil(defaultLimit);
        }

        // GET api/fibonacci/10
        [HttpGet("{limit}")]
        public ActionResult<IEnumerable<int>> Get(int limit)
        {
            fibonacciService = new FibonacciService();

            return fibonacciService.GenerateFibonacciSequenceUntil(limit);
        }
    }
}
