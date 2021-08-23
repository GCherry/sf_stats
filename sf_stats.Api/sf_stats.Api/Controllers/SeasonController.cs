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
    public class SeasonController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ISeasonService _seasonService;
        private readonly IMapper _mapper;

        public SeasonController(ILogger<LogController> logger, IMapper mapper, ISeasonService seasonService)
        {
            _logger = logger;
            _mapper = mapper;
            _seasonService = seasonService;
        }

        /// <summary>
        /// Get seasons based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetSeasons
        ///     {
        ///        "name": "Test Season",
        ///        "code": "TTS",
        ///        "startDate": 2021-06-03T17:10:02.823Z
        ///        "endDate": 2021-06-03T17:10:02.823Z
        ///     }
        ///
        /// </remarks>
        /// <param name="name">Team name</param>
        /// <param name="code">Team code name</param>
        /// <param name="startDate">Season start date - 2021-06-02T17:10:02.823Z</param>
        /// <param name="endDate">Season end date - 2021-06-03T17:10:02.823Z</param>
        /// <returns> Season entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<SeasonDto>>> GetSeasons(
            [FromQuery] string name,
            [FromQuery] string code,
            [FromQuery] DateTimeOffset? startDate,
            [FromQuery] DateTimeOffset? endDate,
            [FromQuery] int? id)
        {
            var filter = new SeasonQueryFilter()
            {
                Id = id,
                Code = code,
                Name = name,
                EndDate = endDate,
                StartDate = startDate
            };

            var results = await _seasonService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<SeasonDto>>(results));
        }

        /// <summary>
        /// Return one season record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Season record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<SeasonDto>> GetSeasons(int id)
        {
            var results = await _seasonService.GetAsync(id);

            return Ok(_mapper.Map<SeasonDto>(results));
        }

        /// <summary>
        /// Add a new season
        /// </summary>
        /// <param name="season">New season</param>
        /// <returns>Newly added season object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<SeasonDto>> AddSeason(SeasonDto season)
        {
            // Add a check to make sure the Season DTO has the proper value
            var newSeason = _mapper.Map<Season>(season);

            var results = await _seasonService.AddAsync(newSeason);
            await _seasonService.SaveChangesAsync();

            return Ok(_mapper.Map<SeasonDto>(results));
        }

        /// <summary>
        /// Update an existing seasons data
        /// </summary>
        /// <param name="season"></param>
        /// <returns>Returns the updated season data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<SeasonDto>> UpdateSeason(SeasonDto season)
        {
            var updatedSeason = _mapper.Map<Season>(season);

            var results = await _seasonService.Update(updatedSeason);

            if (results == null)
            {
                _logger.LogWarning($"Update season failed for season id {season.Id}. Season not found");
                return NotFound();
            }

            await _seasonService.SaveChangesAsync();

            return Ok(_mapper.Map<SeasonDto>(results));
        }

        /// <summary>
        /// Delete a season
        /// </summary>
        /// <param name="seasonId">Id of current season to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSeason(int seasonId)
        {
            await _seasonService.DeleteByIdAsync(seasonId);
            await _seasonService.SaveChangesAsync();

            return Ok();
        }
    }
}
