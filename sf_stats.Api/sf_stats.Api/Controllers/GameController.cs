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
    public class GameController : CrudController<GameDto, Game, IGameService>
    {
        public GameController(ILogger<LogController> logger, IMapper mapper, IGameService GameService) : base(logger, mapper, GameService)
        {
        }

        /// <summary>
        /// Get Games based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetGames
        ///     {
        ///        "id": 1,
        ///        "gameDate": 2021-06-03T17:10:02.823Z,
        ///        "home_Score: 24,
        ///        "away_Score": 24
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="gameDate">Game date</param>
        /// <param name="home_Score">Home Score</param>
        /// <param name="away_Score">Away Score</param>
        /// <returns> Game entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGames(
            [FromQuery] int? id,
            [FromQuery] DateTime? gameDate,
            [FromQuery] int? home_Score, 
            [FromQuery] int? away_Score)
        {
            var filter = new GameQueryFilter()
            {
                Id = id,
                GameDate = gameDate,
                Home_Score = home_Score,
                Away_Score = away_Score
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<GameDto>>(results));
        }
    }
}
