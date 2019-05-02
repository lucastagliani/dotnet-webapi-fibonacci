using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_fibonacci.Interfaces;
using dotnet_webapi_fibonacci.Models;
using dotnet_webapi_fibonacci.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_fibonacci.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        IFibonacciService service;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            service = fibonacciService;
        }
        // GET api/fibonacci
        [HttpGet]
        public ActionResult<FibonacciResult> Until()
        {
            int defaultLimit = 100;

            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(service.GetFibonacciSequenceUntil(defaultLimit));
                return Ok(fibonacciResult);
            }
            catch (ArgumentException ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                return BadRequest(fibonacciResult);
            }
            catch (Exception ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                return StatusCode(500, fibonacciResult);
            }
        }

        // GET api/fibonacci/10
        [HttpGet("{limit}")]
        public ActionResult<FibonacciResult> Until(int limit)
        {
            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(service.GetFibonacciSequenceUntil(limit));
                return Ok(fibonacciResult);
            }
            catch (ArgumentException ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                return BadRequest(fibonacciResult);
            }
            catch (Exception ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                return StatusCode(500, fibonacciResult);
            }
        }
    }
}
