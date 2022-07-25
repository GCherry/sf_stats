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
    public class GameController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IGameService _GameService;
        private readonly IMapper _mapper;

        public GameController(ILogger<LogController> logger, IMapper mapper, IGameService GameService)
        {
            _logger = logger;
            _mapper = mapper;
            _GameService = GameService;
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

            var results = await _GameService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<GameDto>>(results));
        }

        /// <summary>
        /// Return one Game record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Game record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<GameDto>> GetGames(int id)
        {
            var results = await _GameService.GetAsync(id);

            return Ok(_mapper.Map<GameDto>(results));
        }

        /// <summary>
        /// Add a new Game
        /// </summary>
        /// <param name="Game">New Game</param>
        /// <returns>Newly added Game object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<GameDto>> AddGame(GameDto Game)
        {
            // Add a check to make sure the Game DTO has the proper value
            var newGame = _mapper.Map<Game>(Game);

            var results = await _GameService.AddAsync(newGame);
            await _GameService.SaveChangesAsync();

            return Ok(_mapper.Map<GameDto>(results));
        }

        /// <summary>
        /// Update an existing Games data
        /// </summary>
        /// <param name="Game"></param>
        /// <returns>Returns the updated Game data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<GameDto>> UpdateGame(GameDto Game)
        {
            var updatedGame = _mapper.Map<Game>(Game);

            var results = await _GameService.Update(updatedGame);

            if (results == null)
            {
                _logger.LogWarning($"Update Game failed for Game id {Game.Id}. Game not found");
                return NotFound();
            }

            await _GameService.SaveChangesAsync();

            return Ok(_mapper.Map<GameDto>(results));
        }

        /// <summary>
        /// Delete a Game
        /// </summary>
        /// <param name="GameId">Id of current Game to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteGame(int GameId)
        {
            await _GameService.DeleteByIdAsync(GameId);
            await _GameService.SaveChangesAsync();

            return Ok();
        }
    }
}
