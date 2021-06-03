using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sf_stats.Api.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public LogController(ILogger<LogController> logger, IMapper mapper, ILogService logService)
        {
            _logger = logger;
            _mapper = mapper;
            _logService = logService;
        }

        /// <summary>
        /// Get logs based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetLogs
        ///     {
        ///        "level": Error,
        ///        "top": "10",
        ///        "startDate": 2021-06-03T17:10:02.823Z
        ///        "endDate": 2021-06-03T17:10:02.823Z
        ///     }
        ///
        /// </remarks>
        /// <param name="level"> Information, Warning, Error</param>
        /// <param name="top"> How many records do you want to return</param>
        /// <param name="startDate"> 2021-06-02T17:10:02.823Z</param>
        /// <param name="endDate"> 2021-06-03T17:10:02.823Z</param>
        /// <returns> Log entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogs(
            [FromQuery] string level,
            [FromQuery] int? top,
            [FromQuery] DateTimeOffset? startDate,
            [FromQuery] DateTimeOffset? endDate)
        {

            var filter = new LogQueryFilter()
            {
                Level = level,
                EndDate = endDate,
                StartDate = startDate,
                Top = top
            };

            var results = await _logService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<LogDto>>(results));
        }
    }
}
