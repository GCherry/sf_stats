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
    public class DivisionController : CrudController<DivisionDto, Division, DivisionQueryFilter>
    {
        public DivisionController(ILogger<LogController> logger, IMapper mapper, ICrudService<Division, DivisionQueryFilter> divisionService) : base(logger, mapper, divisionService)
        {
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

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<DivisionDto>>(results));
        }
    }
}
