using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using sf_stats.Api.Interfaces;
using sf_stats.Domain.Dtos;

namespace sf_stats.Api.Controllers
{
    public class CrudController<Dto, Entity, Service> : ControllerBase where Dto : IDto where Service: ICrudService<Entity>
    {
        public Service _service;
        public ILogger<LogController> _logger;
        public IMapper _mapper;

        public CrudController(ILogger<LogController> logger, IMapper mapper, Service service)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new entity
        /// </summary>
        /// <param name="dto">New Dto</param>
        /// <returns>Newly added Dto object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<Dto>> Add(Dto dto)
        {
            // Add a check to make sure the DTO has the proper value
            var newEntity = _mapper.Map<Entity>(dto);

            var results = await _service.AddAsync(newEntity);
            await _service.SaveChangesAsync();

            return Ok(_mapper.Map<Dto>(results));
        }

        /// <summary>
        /// Return one T record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<Entity>> GetById(int id)
        {
            var results = await _service.GetAsync(id);

            return Ok(_mapper.Map<Entity>(results));
        }

        /// <summary>
        /// Update an existing dto data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Returns the updated dto data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<Dto>> Update(Dto dto)
        {
            var newEntity = _mapper.Map<Entity>(dto);

            var results = await _service.Update(newEntity);

            if (results == null)
            {
                _logger.LogWarning($"Update Division failed for Division id {dto.Id}. Division not found");
                return NotFound();
            }

            await _service.SaveChangesAsync();

            return Ok(_mapper.Map<Dto>(results));
        }

        /// <summary>
        /// Delete a Division
        /// </summary>
        /// <param name="id">Id of current Entity to be deleted</param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            await _service.SaveChangesAsync();

            return Ok();
        }
    }
}
