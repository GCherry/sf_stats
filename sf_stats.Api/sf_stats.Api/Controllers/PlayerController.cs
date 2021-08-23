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
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IPlayerService _PlayerService;
        private readonly IMapper _mapper;

        public PlayerController(ILogger<LogController> logger, IMapper mapper, IPlayerService PlayerService)
        {
            _logger = logger;
            _mapper = mapper;
            _PlayerService = PlayerService;
        }

        /// <summary>
        /// Get Players based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetPlayers
        ///     {
        ///        "firstName": "Test",
        ///        "middleName": "",
        ///        "lastName": "Player",
        ///        "dateOfBirth": "03-25-1986",
        ///        "height": "48",
        ///        "weight": "105",
        ///        "grade": "7th",
        ///     }
        ///
        /// </remarks>
        /// <param name="name">Player name</param>
        /// <param name="code">Player code name</param>
        /// <returns> Player entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers(
            [FromQuery] string firstName,
            [FromQuery] string middleName,
            [FromQuery] string lastName,
            [FromQuery] DateTime? dateOfBirth,
            [FromQuery] int? height,
            [FromQuery] int? weight,
            [FromQuery] string grade,
            [FromQuery] int? id)
        {
            var filter = new PlayerQueryFilter()
            {
                Id = id,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Height = height,
                Weight = weight,
                Grade = grade
            };

            var results = await _PlayerService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<PlayerDto>>(results));
        }

        /// <summary>
        /// Return one Player record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<PlayerDto>> GetPlayers(int id)
        {
            var results = await _PlayerService.GetAsync(id);

            return Ok(_mapper.Map<PlayerDto>(results));
        }

        /// <summary>
        /// Add a new Player
        /// </summary>
        /// <param name="Player">New Player</param>
        /// <returns>Newly added Player object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<PlayerDto>> AddPlayer(PlayerDto Player)
        {
            // Add a check to make sure the Player DTO has the proper value
            var newPlayer = _mapper.Map<Player>(Player);

            var results = await _PlayerService.AddAsync(newPlayer);
            await _PlayerService.SaveChangesAsync();

            return Ok(_mapper.Map<PlayerDto>(results));
        }

        /// <summary>
        /// Update an existing Players data
        /// </summary>
        /// <param name="Player"></param>
        /// <returns>Returns the updated Player data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<PlayerDto>> UpdatePlayer(PlayerDto Player)
        {
            var updatedPlayer = _mapper.Map<Player>(Player);

            var results = await _PlayerService.Update(updatedPlayer);

            if (results == null)
            {
                _logger.LogWarning($"Update Player failed for Player id {Player.Id}. Player not found");
                return NotFound();
            }

            await _PlayerService.SaveChangesAsync();

            return Ok(_mapper.Map<PlayerDto>(results));
        }

        /// <summary>
        /// Delete a Player
        /// </summary>
        /// <param name="PlayerId">Id of current Player to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeletePlayer(int PlayerId)
        {
            await _PlayerService.DeleteByIdAsync(PlayerId);
            await _PlayerService.SaveChangesAsync();

            return Ok();
        }
    }
}
