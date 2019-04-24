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
        // GET api/fibonacci
        [HttpGet]
        public ActionResult<FibonacciResult> Get()
        {
            FibonacciService fibonacciService = new FibonacciService();
            int defaultLimit = 100;

            FibonacciResult fibonacciResult = new FibonacciResult();

            try
            {
                fibonacciResult.Data = fibonacciService.GetFibonacciSequenceUntil(defaultLimit);
                return Ok(fibonacciResult);
            }
            catch (ArgumentException ex)
            {
                fibonacciResult.ErrorMessage = ex.Message;
                return BadRequest(fibonacciResult);
            }
            catch (Exception ex)
            {
                fibonacciResult.ErrorMessage = ex.Message;
                return StatusCode(500, fibonacciResult);
            }
        }

        // GET api/fibonacci/10
        [HttpGet("{limit}")]
        public ActionResult<FibonacciResult> Get(int limit)
        {
            FibonacciService fibonacciService = new FibonacciService();

            FibonacciResult fibonacciResult = new FibonacciResult();

            try
            {
                fibonacciResult.Data = fibonacciService.GetFibonacciSequenceUntil(limit);
                return Ok(fibonacciResult);
            }
            catch (ArgumentException ex)
            {
                fibonacciResult.ErrorMessage = ex.Message;
                return BadRequest(fibonacciResult);
            }
            catch (Exception ex)
            {
                fibonacciResult.ErrorMessage = ex.Message;
                return StatusCode(500, fibonacciResult);
            }
        }
    }
}
