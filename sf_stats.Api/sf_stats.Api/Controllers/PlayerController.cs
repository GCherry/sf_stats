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
    public class PlayerController : CrudController<PlayerDto, Player, PlayerQueryFilter>
    {
        public PlayerController(ILogger<LogController> logger, IMapper mapper, ICrudService<Player, PlayerQueryFilter> PlayerService) : base(logger, mapper, PlayerService)
        {
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
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="grade"></param>
        /// <param name="id"></param>
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

            var results = await _service.GetAsync(filter);

            return Ok(_mapper.Map<IEnumerable<PlayerDto>>(results));
        }
    }
}
