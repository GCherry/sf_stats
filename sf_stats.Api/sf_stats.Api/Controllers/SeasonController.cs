using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sf_stats.Api.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Dtos;
using sf_stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonController : CrudController<SeasonDto, Season, SeasonQueryFilter>
    {
        public SeasonController(ILogger<LogController> logger, IMapper mapper, ICrudService<Season, SeasonQueryFilter> seasonService) : base(logger, mapper, seasonService)
        {
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
        /// <param name="id">Season Id</param>
        /// <returns> Season entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<SeasonDto>>> GetSeasons(
            [FromQuery] string name,
            [FromQuery] string code,
            [FromQuery] DateTimeOffset? startDate,
            [FromQuery] DateTimeOffset? endDate,
            [FromQuery] int? id)
        {
            var filter = new SeasonQueryFilter()
            {
                Id = id,
                Code = code,
                Name = name,
                EndDate = endDate,
                StartDate = startDate
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<SeasonDto>>(results));
        }
    }
}
