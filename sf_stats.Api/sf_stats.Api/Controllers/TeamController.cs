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
    public class TeamController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(ILogger<LogController> logger, IMapper mapper, ITeamService teamService)
        {
            _logger = logger;
            _mapper = mapper;
            _teamService = teamService;
        }

        /// <summary>
        /// Get Teams based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetTeams
        ///     {
        ///        "firstName": "Test",
        ///        "middleName": "",
        ///        "lastName": "Team",
        ///        "dateOfBirth": "03-25-1986",
        ///        "height": "48",
        ///        "weight": "105",
        ///        "grade": "7th",
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="name">Team name</param>
        /// <param name="nameAbbreviation"></param>
        /// <param name="isActive"></param>
        /// <returns> Team entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams(
            [FromQuery] int id,
            [FromQuery] string name,
            [FromQuery] string nameAbbreviation,
            [FromQuery] bool isActive)
        {
            var filter = new TeamQueryFilter()
            {
                Id = id,
                Name = name,
                NameAbbreviation = nameAbbreviation,
                IsActive = isActive
            };

            var results = await _teamService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamDto>>(results));
        }

        /// <summary>
        /// Return one Team record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Team record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamDto>> GetTeams(int id)
        {
            var results = await _teamService.GetAsync(id);

            return Ok(_mapper.Map<TeamDto>(results));
        }

        /// <summary>
        /// Add a new Team
        /// </summary>
        /// <param name="Team">New Team</param>
        /// <returns>Newly added Team object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamDto>> AddTeam(TeamDto Team)
        {
            // Add a check to make sure the Team DTO has the proper value
            var newTeam = _mapper.Map<Team>(Team);

            var results = await _teamService.AddAsync(newTeam);
            await _teamService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamDto>(results));
        }

        /// <summary>
        /// Update an existing Teams data
        /// </summary>
        /// <param name="Team"></param>
        /// <returns>Returns the updated Team data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<TeamDto>> UpdateTeam(TeamDto Team)
        {
            var updatedTeam = _mapper.Map<Team>(Team);

            var results = await _teamService.Update(updatedTeam);

            if (results == null)
            {
                _logger.LogWarning($"Update Team failed for Team id {Team.Id}. Team not found");
                return NotFound();
            }

            await _teamService.SaveChangesAsync();

            return Ok(_mapper.Map<TeamDto>(results));
        }

        /// <summary>
        /// Delete a Team
        /// </summary>
        /// <param name="TeamId">Id of current Team to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTeam(int TeamId)
        {
            await _teamService.DeleteByIdAsync(TeamId);
            await _teamService.SaveChangesAsync();

            return Ok();
        }
    }
}
