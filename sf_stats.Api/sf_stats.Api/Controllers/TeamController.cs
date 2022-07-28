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
    public class TeamController : CrudController<TeamDto, Team, TeamQueryFilter>
    {
        public TeamController(ILogger<LogController> logger, IMapper mapper, ICrudService<Team, TeamQueryFilter> teamService) : base(logger, mapper, teamService)
        {
        }

        /// <summary>
        /// Get Teams based on the filter provided
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetTeams
        ///     {
        ///        "id": 1,
        ///        "name": "Test",
        ///        "nameAbberviation: "TST",
        ///        "isActive": true
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
            [FromQuery] bool? isActive)
        {
            var filter = new TeamQueryFilter()
            {
                Id = id,
                Name = name,
                NameAbbreviation = nameAbbreviation,
                IsActive = isActive ?? true
            };

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<TeamDto>>(results));
        }
    }
}
