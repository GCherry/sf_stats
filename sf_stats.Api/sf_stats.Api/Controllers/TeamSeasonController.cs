using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sf_stats.Api.Interfaces;
using sf_stats.Domain.DomainObjects;
using sf_stats.Domain.Dtos;
using sf_stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sf_stats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamSeasonController : CrudController<TeamSeasonDto, TeamSeason, TeamSeasonQueryFilter>
    {
        public TeamSeasonController(ILogger<LogController> logger, IMapper mapper, ICrudService<TeamSeason, TeamSeasonQueryFilter> TeamSeasonService) : base(logger, mapper, TeamSeasonService)
        {
        }

        /// <summary>
        /// Get TeamSeasons based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetTeamSeasons
        ///     {
        ///        "id": 1,
        ///        "TeamId": 1,
        ///        "SeasonId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="teamId">TeamId</param>
        /// <param name="seasonId">SeasonId</param>
        /// <returns> TeamSeason entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TeamSeasonDto>>> GetTeamSeasons(
            [FromQuery] int? id,
            [FromQuery] int? teamId,
            [FromQuery] int? seasonId)
        {
            var filter = new TeamSeasonQueryFilter()
            {
                Id = id,
                TeamId = teamId,
                SeasonId = seasonId
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamSeasonDto>>(results));
        }
    }
}
