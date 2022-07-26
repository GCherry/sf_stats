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
    public class TeamSeasonGameController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ITeamSeasonGameService _TeamSeasonGameService;
        private readonly IMapper _mapper;

        public TeamSeasonGameController(ILogger<LogController> logger, IMapper mapper, ITeamSeasonGameService TeamSeasonGameService)
        {
            _logger = logger;
            _mapper = mapper;
            _TeamSeasonGameService = TeamSeasonGameService;
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

            var results = await _TeamSeasonGameService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamSeasonGameDto>>(results));
        }

        /// <summary>
        /// Return one TeamSeasonGame record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TeamSeasonGame record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonGameDto>> GetTeamSeasonGames(int id)
        {
            var results = await _TeamSeasonGameService.GetAsync(id);

            return Ok(_mapper.Map<TeamSeasonGameDto>(results));
        }

        /// <summary>
        /// Add a new TeamSeasonGame
        /// </summary>
        /// <param name="TeamSeasonGame">New TeamSeasonGame</param>
        /// <returns>Newly added TeamSeasonGame object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonGameDto>> AddTeamSeasonGames(TeamSeasonGameDto TeamSeasonGame)
        {
            // Add a check to make sure the TeamSeasonGame DTO has the proper value
            var newTeamSeason = _mapper.Map<TeamSeasonGame>(TeamSeasonGame);

            var results = await _TeamSeasonGameService.AddAsync(newTeamSeason);
            await _TeamSeasonGameService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamSeasonGameDto>(results));
        }

        /// <summary>
        /// Update an existing TeamSeasons data
        /// </summary>
        /// <param name="TeamSeason"></param>
        /// <returns>Returns the updated TeamSeason data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonGameDto>> UpdateTeamSeasonGame(TeamSeasonGameDto TeamSeason)
        {
            var updatedTeamSeason = _mapper.Map<TeamSeasonGame>(TeamSeason);

            var results = await _TeamSeasonGameService.Update(updatedTeamSeason);

            if (results == null)
            {
                _logger.LogWarning($"Update TeamSeason failed for TeamSeason id {TeamSeason.Id}. TeamSeason not found");
                return NotFound();
            }

            await _TeamSeasonGameService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamSeasonGameDto>(results));
        }

        /// <summary>
        /// Delete a TeamSeason
        /// </summary>
        /// <param name="TeamSeasonId">Id of current TeamSeason to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTeamSeasonGame(int TeamSeasonId)
        {
            await _TeamSeasonGameService.DeleteByIdAsync(TeamSeasonId);
            await _TeamSeasonGameService.SaveChangesAsync();

            return Ok();
        }
    }
}
