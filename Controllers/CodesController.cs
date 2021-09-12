using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StatusCodeGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodesController : ControllerBase
    {
        private readonly ISet<int> _statusCode = new HashSet<int>() { 202, 208, 300, 502, 400, 409, 100, 201, 103, 417, 424, 403, 302, 504, 410, 505, 226, 507, 500, 411, 423, 508, 405, 421, 301, 301, 300, 207, 511, 204, 203, 406, 510, 404, 501, 304, 200, 206, 402, 308, 412, 428, 102, 407, 302, 307, 303, 416, 413, 431, 408, 414, 205, 303, 503, 101, 307, 429, 401, 451, 422, 415, 306, 426, 305, 506 };

        private readonly ILogger<CodesController> _logger;

        public CodesController(ILogger<CodesController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException();
        }

        [HttpGet("{code}")]
        public IActionResult GeneratCode([FromRoute] int code, [FromQuery] bool customed = false)
        {
            _logger.LogInformation($"Match method GeneratCode, input code {code}");

            if (customed) return StatusCode(code);

            if (_statusCode.Contains(code)) return StatusCode(code);

            return BadRequest($"Invalid status code {code}");
        }
    }
}
