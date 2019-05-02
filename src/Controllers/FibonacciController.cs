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
        private readonly IFibonacciService _service;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _service = fibonacciService;
        }

        // GET api/fibonacci/until
        [HttpGet]
        public ActionResult<FibonacciResult> Until()
        {
            int defaultLimit = 100;

            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(_service.GetFibonacciSequenceUntil(defaultLimit));
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

        // GET api/fibonacci/until/100
        [HttpGet("{limit}")]
        public ActionResult<FibonacciResult> Until(int limit)
        {
            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(_service.GetFibonacciSequenceUntil(limit));
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

        // GET api/fibonacci/length
        [HttpGet]
        public ActionResult<FibonacciResult> Length()
        {
            int defaultLength = 10;

            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(_service.GetFibonacciSequenceWithLength(defaultLength));
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

        // GET api/fibonacci/length/10
        [HttpGet("{length}")]
        public ActionResult<FibonacciResult> Length(int length)
        {
            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(_service.GetFibonacciSequenceWithLength(length));
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
