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
    public class TeamSeasonPlayerController : CrudController<TeamSeasonPlayerDto, TeamSeasonPlayer, TeamSeasonPlayerQueryFilter>
    {
        public TeamSeasonPlayerController(ILogger<LogController> logger, IMapper mapper, ICrudService<TeamSeasonPlayer, TeamSeasonPlayerQueryFilter> TeamSeasonPlayerService) : base (logger, mapper, TeamSeasonPlayerService)
        {
        }

        /// <summary>
        /// Get TeamSeasonPlayers based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetTeamSeasonPlayers
        ///     {
        ///        "id": 1,
        ///        "PlayerId": 1,
        ///        "TeamSeasonId": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="playerId">PlayerId</param>
        /// <param name="teamSeasonId">TeamSeasonId</param>
        /// <returns> TeamSeasonPlayer entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TeamSeasonPlayerDto>>> GetTeamSeasonPlayers(
            [FromQuery] int? id,
            [FromQuery] int? playerId,
            [FromQuery] int? teamSeasonId)
        {
            var filter = new TeamSeasonPlayerQueryFilter()
            {
                Id = id,
                PlayerId = playerId,
                TeamSeasonId = teamSeasonId
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamSeasonPlayerDto>>(results));
        }
    }
}
