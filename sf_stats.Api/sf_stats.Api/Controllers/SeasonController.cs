using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sf_stats.Api.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sf_stats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ISeasonService _seasonService;
        private readonly IMapper _mapper;

        public SeasonController(ILogger<LogController> logger, IMapper mapper, ISeasonService seasonService)
        {
            _logger = logger;
            _mapper = mapper;
            _seasonService = seasonService;
        }

        /// <summary>
        /// Get seasons based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetSeasons
        ///     {
        ///        "name": "Test Season",
        ///        "code": "TTS",
        ///        "startDate": 2021-06-03T17:10:02.823Z
        ///        "endDate": 2021-06-03T17:10:02.823Z
        ///     }
        ///
        /// </remarks>
        /// <param name="name">Team name</param>
        /// <param name="code">Team code name</param>
        /// <param name="startDate">Season start date - 2021-06-02T17:10:02.823Z</param>
        /// <param name="endDate">Season end date - 2021-06-03T17:10:02.823Z</param>
        /// <returns> Season entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<SeasonDto>>> GetSeasons(
            [FromQuery] string name,
            [FromQuery] string code,
            [FromQuery] DateTimeOffset? startDate,
            [FromQuery] DateTimeOffset? endDate)
        {

            var filter = new SeasonQueryFilter()
            {
                Code = code,
                Name = name,
                EndDate = endDate,
                StartDate = startDate
            };

            var results = await _seasonService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<LogDto>>(results));
        }
    }
}
