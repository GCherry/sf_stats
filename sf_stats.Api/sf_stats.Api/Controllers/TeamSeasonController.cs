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
    public class TeamSeasonController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ITeamSeasonService _TeamSeasonService;
        private readonly IMapper _mapper;

        public TeamSeasonController(ILogger<LogController> logger, IMapper mapper, ITeamSeasonService TeamSeasonService)
        {
            _logger = logger;
            _mapper = mapper;
            _TeamSeasonService = TeamSeasonService;
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

            var results = await _TeamSeasonService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamSeasonDto>>(results));
        }

        /// <summary>
        /// Return one TeamSeason record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TeamSeason record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonDto>> GetTeamSeasons(int id)
        {
            var results = await _TeamSeasonService.GetAsync(id);

            return Ok(_mapper.Map<TeamSeasonDto>(results));
        }

        /// <summary>
        /// Add a new TeamSeason
        /// </summary>
        /// <param name="TeamSeason">New TeamSeason</param>
        /// <returns>Newly added TeamSeason object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonDto>> AddTeamSeason(TeamSeasonDto TeamSeason)
        {
            // Add a check to make sure the TeamSeason DTO has the proper value
            var newTeamSeason = _mapper.Map<TeamSeason>(TeamSeason);

            var results = await _TeamSeasonService.AddAsync(newTeamSeason);
            await _TeamSeasonService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamSeasonDto>(results));
        }

        /// <summary>
        /// Update an existing TeamSeasons data
        /// </summary>
        /// <param name="TeamSeason"></param>
        /// <returns>Returns the updated TeamSeason data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamSeasonDto>> UpdateTeamSeason(TeamSeasonDto TeamSeason)
        {
            var updatedTeamSeason = _mapper.Map<TeamSeason>(TeamSeason);

            var results = await _TeamSeasonService.Update(updatedTeamSeason);

            if (results == null)
            {
                _logger.LogWarning($"Update TeamSeason failed for TeamSeason id {TeamSeason.Id}. TeamSeason not found");
                return NotFound();
            }

            await _TeamSeasonService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamSeasonDto>(results));
        }

        /// <summary>
        /// Delete a TeamSeason
        /// </summary>
        /// <param name="TeamSeasonId">Id of current TeamSeason to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTeamSeason(int TeamSeasonId)
        {
            await _TeamSeasonService.DeleteByIdAsync(TeamSeasonId);
            await _TeamSeasonService.SaveChangesAsync();

            return Ok();
        }
    }
}
