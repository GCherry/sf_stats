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
    public class StatTypeController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IStatTypeService _StatTypeService;
        private readonly IMapper _mapper;

        public StatTypeController(ILogger<LogController> logger, IMapper mapper, IStatTypeService StatTypeService)
        {
            _logger = logger;
            _mapper = mapper;
            _StatTypeService = StatTypeService;
        }

        /// <summary>
        /// Get StatTypes based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetStatTypes
        ///     {
        ///        "displayName": "Test StatType",
        ///        "code": "TTD"
        ///     }
        ///
        /// </remarks>
        /// <param name="displayName">StatType display name</param>
        /// <param name="code">StatType code name</param>
        /// <param name="id">StatType id</param>
        /// <returns> StatType entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<StatTypeDto>>> GetStatTypes(
            [FromQuery] int? id,
            [FromQuery] string code,
            [FromQuery] string displayName)
        {
            var filter = new StatTypeQueryFilter()
            {
                Id = id,
                Code = code,
                DisplayName = displayName
            };

            var results = await _StatTypeService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<StatTypeDto>>(results));
        }

        /// <summary>
        /// Return one StatType record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StatType record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<StatTypeDto>> GetStatTypes(int id)
        {
            var results = await _StatTypeService.GetAsync(id);

            return Ok(_mapper.Map<StatTypeDto>(results));
        }

        /// <summary>
        /// Add a new StatType
        /// </summary>
        /// <param name="StatType">New StatType</param>
        /// <returns>Newly added StatType object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<StatTypeDto>> AddStatType(StatTypeDto StatType)
        {
            // Add a check to make sure the StatType DTO has the proper value
            var newStatType = _mapper.Map<StatType>(StatType);

            var results = await _StatTypeService.AddAsync(newStatType);
            await _StatTypeService.SaveChangesAsync();

            return Ok(_mapper.Map<StatTypeDto>(results));
        }

        /// <summary>
        /// Update an existing StatTypes data
        /// </summary>
        /// <param name="StatType"></param>
        /// <returns>Returns the updated StatType data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<StatTypeDto>> UpdateStatType(StatTypeDto StatType)
        {
            var updatedStatType = _mapper.Map<StatType>(StatType);

            var results = await _StatTypeService.Update(updatedStatType);

            if (results == null)
            {
                _logger.LogWarning($"Update StatType failed for StatType id {StatType.Id}. StatType not found");
                return NotFound();
            }

            await _StatTypeService.SaveChangesAsync();

            return Ok(_mapper.Map<StatTypeDto>(results));
        }

        /// <summary>
        /// Delete a StatType
        /// </summary>
        /// <param name="StatTypeId">Id of current StatType to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteStatType(int StatTypeId)
        {
            await _StatTypeService.DeleteByIdAsync(StatTypeId);
            await _StatTypeService.SaveChangesAsync();

            return Ok();
        }
    }
}
