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
    public class TeamSeasonPlayerController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ITeamSeasonPlayerService _TeamSeasonPlayerService;
        private readonly IMapper _mapper;

        public TeamSeasonPlayerController(ILogger<LogController> logger, IMapper mapper, ITeamSeasonPlayerService TeamSeasonPlayerService)
        {
            _logger = logger;
            _mapper = mapper;
            _TeamSeasonPlayerService = TeamSeasonPlayerService;
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

            var results = await _TeamSeasonPlayerService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamSeasonPlayerDto>>(results));
        }

        /// <summary>
        /// Return one TeamSeasonPlayer record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TeamSeasonPlayer record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonPlayerDto>> GetTeamSeasonPlayers(int id)
        {
            var results = await _TeamSeasonPlayerService.GetAsync(id);

            return Ok(_mapper.Map<TeamSeasonPlayerDto>(results));
        }

        /// <summary>
        /// Add a new TeamSeasonPlayer
        /// </summary>
        /// <param name="TeamSeasonPlayer">New TeamSeasonPlayer</param>
        /// <returns>Newly added TeamSeasonPlayer object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonPlayerDto>> AddTeamSeasonPlayers(TeamSeasonPlayerDto TeamSeasonPlayer)
        {
            // Add a check to make sure the TeamSeasonPlayer DTO has the proper value
            var newTeamSeason = _mapper.Map<TeamSeasonPlayer>(TeamSeasonPlayer);

            var results = await _TeamSeasonPlayerService.AddAsync(newTeamSeason);
            await _TeamSeasonPlayerService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamSeasonPlayerDto>(results));
        }

        /// <summary>
        /// Update an existing TeamSeasons data
        /// </summary>
        /// <param name="TeamSeason"></param>
        /// <returns>Returns the updated TeamSeason data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonPlayerDto>> UpdateTeamSeasonPlayer(TeamSeasonPlayerDto TeamSeason)
        {
            var updatedTeamSeason = _mapper.Map<TeamSeasonPlayer>(TeamSeason);

            var results = await _TeamSeasonPlayerService.Update(updatedTeamSeason);

            if (results == null)
            {
                _logger.LogWarning($"Update TeamSeason failed for TeamSeason id {TeamSeason.Id}. TeamSeason not found");
                return NotFound();
            }

            await _TeamSeasonPlayerService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamSeasonPlayerDto>(results));
        }

        /// <summary>
        /// Delete a TeamSeason
        /// </summary>
        /// <param name="TeamSeasonId">Id of current TeamSeason to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTeamSeasonPlayer(int TeamSeasonId)
        {
            await _TeamSeasonPlayerService.DeleteByIdAsync(TeamSeasonId);
            await _TeamSeasonPlayerService.SaveChangesAsync();

            return Ok();
        }
    }
}
