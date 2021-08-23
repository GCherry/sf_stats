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
    public class DivisionController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IDivisionService _divisionService;
        private readonly IMapper _mapper;

        public DivisionController(ILogger<LogController> logger, IMapper mapper, IDivisionService divisionService)
        {
            _logger = logger;
            _mapper = mapper;
            _divisionService = divisionService;
        }

        /// <summary>
        /// Get Divisions based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetDivisions
        ///     {
        ///        "name": "Test Division",
        ///        "code": "TTD"
        ///     }
        ///
        /// </remarks>
        /// <param name="name">Division name</param>
        /// <param name="code">Division code name</param>
        /// <param name="id">Division id</param>
        /// <returns> Division entries based on the filter provided</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<DivisionDto>>> GetDivisions(
            [FromQuery] string name,
            [FromQuery] string code,
            [FromQuery] int? id)
        {
            var filter = new DivisionQueryFilter()
            {
                Id = id,
                Code = code,
                Name = name
            };

            var results = await _divisionService.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<DivisionDto>>(results));
        }

        /// <summary>
        /// Return one Division record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Division record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<DivisionDto>> GetDivisions(int id)
        {
            var results = await _divisionService.GetAsync(id);

            return Ok(_mapper.Map<DivisionDto>(results));
        }

        /// <summary>
        /// Add a new Division
        /// </summary>
        /// <param name="Division">New Division</param>
        /// <returns>Newly added Division object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<DivisionDto>> AddDivision(DivisionDto Division)
        {
            // Add a check to make sure the Division DTO has the proper value
            var newDivision = _mapper.Map<Division>(Division);

            var results = await _divisionService.AddAsync(newDivision);
            await _divisionService.SaveChangesAsync();

            return Ok(_mapper.Map<DivisionDto>(results));
        }

        /// <summary>
        /// Update an existing Divisions data
        /// </summary>
        /// <param name="Division"></param>
        /// <returns>Returns the updated Division data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<DivisionDto>> UpdateDivision(DivisionDto Division)
        {
            var updatedDivision = _mapper.Map<Division>(Division);

            var results = await _divisionService.Update(updatedDivision);

            if (results == null)
            {
                _logger.LogWarning($"Update Division failed for Division id {Division.Id}. Division not found");
                return NotFound();
            }

            await _divisionService.SaveChangesAsync();

            return Ok(_mapper.Map<DivisionDto>(results));
        }

        /// <summary>
        /// Delete a Division
        /// </summary>
        /// <param name="DivisionId">Id of current Division to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDivision(int DivisionId)
        {
            await _divisionService.DeleteByIdAsync(DivisionId);
            await _divisionService.SaveChangesAsync();

            return Ok();
        }
    }
}
