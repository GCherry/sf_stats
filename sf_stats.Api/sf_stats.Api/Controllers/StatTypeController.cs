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
    public class StatTypeController : CrudController<StatTypeDto, StatType, StatTypeQueryFilter>
    {
        public StatTypeController(ILogger<LogController> logger, IMapper mapper, ICrudService<StatType, StatTypeQueryFilter> StatTypeService) : base(logger, mapper, StatTypeService)
        {
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

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<StatTypeDto>>(results));
        }
    }
}
