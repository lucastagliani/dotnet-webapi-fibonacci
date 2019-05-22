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
        private readonly string ALGORITHM_NAME_LENGTH = "length";
        private readonly string ALGORITHM_NAME_UNTIL = "until";
        private readonly ILogRepository _log;
        private readonly IFibonacciService _service;

        public FibonacciController(IFibonacciService fibonacciService, ILogRepository logRepository)
        {
            _service = fibonacciService;
            _log = logRepository;
        }
        // GET api/fibonacci/until/100
        [HttpGet("{limit?}")]
        public ActionResult<FibonacciResult> Until(int limit = 100)
        {
            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(_service.GetFibonacciSequenceUntil(limit));
                _log.Create(new Log(ALGORITHM_NAME_UNTIL, limit, fibonacciResult));
                return Ok(fibonacciResult);
            }
            catch (ArgumentException ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                _log.Create(new Log(ALGORITHM_NAME_UNTIL, limit, fibonacciResult));
                return BadRequest(fibonacciResult);
            }
            catch (Exception ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                _log.Create(new Log(ALGORITHM_NAME_UNTIL, limit, fibonacciResult));
                return StatusCode(500, fibonacciResult);
            }
        }

        // GET api/fibonacci/length/10
        [HttpGet("{length?}")]
        public ActionResult<FibonacciResult> Length(int length = 100)
        {
            FibonacciResult fibonacciResult;

            try
            {
                fibonacciResult = new FibonacciResult(_service.GetFibonacciSequenceWithLength(length));
                _log.Create(new Log(ALGORITHM_NAME_LENGTH, length, fibonacciResult));
                return Ok(fibonacciResult);
            }
            catch (ArgumentException ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                _log.Create(new Log(ALGORITHM_NAME_LENGTH, length, fibonacciResult));
                return BadRequest(fibonacciResult);
            }
            catch (Exception ex)
            {
                fibonacciResult = new FibonacciResult(ex.Message);
                _log.Create(new Log(ALGORITHM_NAME_LENGTH, length, fibonacciResult));
                return StatusCode(500, fibonacciResult);
            }
        }
    }
}
