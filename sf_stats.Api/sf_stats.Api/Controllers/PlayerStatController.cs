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
    public class PlayerStatController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IPlayerStatService _PlayerStatService;
        private readonly IMapper _mapper;

        public PlayerStatController(ILogger<LogController> logger, IMapper mapper, IPlayerStatService PlayerStatService)
        {
            _logger = logger;
            _mapper = mapper;
            _PlayerStatService = PlayerStatService;
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

            var results = await _PlayerStatService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<PlayerStatDto>>(results));
        }

        /// <summary>
        /// Return one PlayerStat record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PlayerStat record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<PlayerStatDto>> GetPlayerStats(int id)
        {
            var results = await _PlayerStatService.GetAsync(id);

            return Ok(_mapper.Map<PlayerStatDto>(results));
        }

        /// <summary>
        /// Add a new PlayerStat
        /// </summary>
        /// <param name="PlayerStat">New PlayerStat</param>
        /// <returns>Newly added PlayerStat object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<PlayerStatDto>> AddPlayerStat(PlayerStatDto PlayerStat)
        {
            // Add a check to make sure the PlayerStat DTO has the proper value
            var newPlayerStat = _mapper.Map<PlayerStat>(PlayerStat);

            var results = await _PlayerStatService.AddAsync(newPlayerStat);
            await _PlayerStatService.SaveChangesAsync();

            return Ok(_mapper.Map<PlayerStatDto>(results));
        }

        /// <summary>
        /// Update an existing PlayerStats data
        /// </summary>
        /// <param name="PlayerStat"></param>
        /// <returns>Returns the updated PlayerStat data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<PlayerStatDto>> UpdatePlayerStat(PlayerStatDto PlayerStat)
        {
            var updatedPlayerStat = _mapper.Map<PlayerStat>(PlayerStat);

            var results = await _PlayerStatService.Update(updatedPlayerStat);

            if (results == null)
            {
                _logger.LogWarning($"Update PlayerStat failed for PlayerStat id {PlayerStat.Id}. PlayerStat not found");
                return NotFound();
            }

            await _PlayerStatService.SaveChangesAsync();

            return Ok(_mapper.Map<PlayerStatDto>(results));
        }

        /// <summary>
        /// Delete a PlayerStat
        /// </summary>
        /// <param name="PlayerStatId">Id of current PlayerStat to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeletePlayerStat(int PlayerStatId)
        {
            await _PlayerStatService.DeleteByIdAsync(PlayerStatId);
            await _PlayerStatService.SaveChangesAsync();

            return Ok();
        }
    }
}
