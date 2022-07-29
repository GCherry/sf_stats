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
    public class TeamSeasonGameController : CrudController<TeamSeasonGameDto, TeamSeasonGame, TeamSeasonGameQueryFilter>
    {
        public TeamSeasonGameController(ILogger<LogController> logger, IMapper mapper, ICrudService<TeamSeasonGame, TeamSeasonGameQueryFilter> TeamSeasonGameService) : base(logger, mapper, TeamSeasonGameService)
        {
        }

        /// <summary>
        /// Get TeamSeasonGames based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetTeamSeasonGames
        ///     {
        ///        "id": 1,
        ///        "GameId": 1,
        ///        "TeamSeasonId": 1,
        ///        "IsHomeTeam": True
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="gameId">GameId</param>
        /// <param name="teamSeasonId">TeamSeasonId</param>
        /// <param name="isHomeTeam">IsHomeTeam</param>
        /// <returns> TeamSeasonGame entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TeamSeasonGameDto>>> GetTeamSeasonGames(
            [FromQuery] int? id,
            [FromQuery] int? gameId,
            [FromQuery] int? teamSeasonId,
            [FromQuery] bool? isHomeTeam)
        {
            var filter = new TeamSeasonGameQueryFilter()
            {
                Id = id,
                GameId = gameId,
                TeamSeasonId = teamSeasonId,
                IsHomeTeam = isHomeTeam
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamSeasonGameDto>>(results));
        }
    }
}
