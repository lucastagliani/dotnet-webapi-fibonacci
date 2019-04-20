using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_fibonacci.Model;
using dotnet_webapi_fibonacci.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_fibonacci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        FibonacciService fibonacciService;

        // GET api/fibonacci
        [HttpGet]
        public ActionResult<FibonacciResult> Get()
        {
            fibonacciService = new FibonacciService();
            int defaultLimit = 100;

            FibonacciResult fibonacciResult = new FibonacciResult();

            try
            {
                fibonacciResult.Data = fibonacciService.GetFibonacciSequenceUntil(defaultLimit);
            }
            catch (Exception ex)
            {
                fibonacciResult.ErrorMessage = ex.Message;
            }

            return fibonacciResult;
        }

        // GET api/fibonacci/10
        [HttpGet("{limit}")]
        public ActionResult<FibonacciResult> Get(int limit)
        {
            fibonacciService = new FibonacciService();

            FibonacciResult fibonacciResult = new FibonacciResult();

            try
            {
                fibonacciResult.Data = fibonacciService.GetFibonacciSequenceUntil(limit);
            }
            catch (Exception ex)
            {
                fibonacciResult.ErrorMessage = ex.Message;
            }

            return fibonacciResult;
        }
    }
}
