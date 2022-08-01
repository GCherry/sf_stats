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
    public class PlayerStatController : CrudController<PlayerStatDto, PlayerStat, PlayerStatQueryFilter>
    {


        public PlayerStatController(ILogger<LogController> logger, IMapper mapper, ICrudService<PlayerStat, PlayerStatQueryFilter> PlayerStatService) : base (logger, mapper, PlayerStatService)
        {
        }

        /// <summary>
        /// Get PlayerStats based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetPlayerStats
        ///     {
        ///        "TeamSeasonPlayerId": 1,
        ///        "GameId": 1,
        ///        "StatTypeId": 1,
        ///        "Value": 1.0,
        ///     }
        ///
        /// </remarks>
        /// <param name="teamSeasonPlayerId"></param>
        /// <param name="gameId"></param>
        /// <param name="statTypeId"></param>
        /// <param name="value"></param>
        /// <returns> PlayerStat entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<PlayerStatDto>>> GetPlayerStats(
            [FromQuery] int? teamSeasonPlayerId,
            [FromQuery] int? gameId,
            [FromQuery] int? statTypeId,
            [FromQuery] decimal? value)
        {
            var filter = new PlayerStatQueryFilter()
            {
                TeamSeasonPlayerId = teamSeasonPlayerId,
                GameId = gameId,
                StatTypeId = statTypeId,
                Value = value
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<PlayerStatDto>>(results));
        }
    }
}
