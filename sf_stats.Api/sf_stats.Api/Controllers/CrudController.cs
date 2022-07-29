using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using sf_stats.Api.Interfaces;
using sf_stats.Domain.Dtos;

namespace sf_stats.Api.Controllers
{
    public class CrudController<TIDto, TEntity, TFilter> : ControllerBase
    {
        public ICrudService<TEntity, TFilter> _service;
        public ILogger<LogController> _logger;
        public IMapper _mapper;

        public CrudController(ILogger<LogController> logger, IMapper mapper, ICrudService<TEntity, TFilter> service)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new TEntity
        /// </summary>
        /// <param name="dto">New TEntity</param>
        /// <returns>Newly added TEntity object</returns>
        [HttpPost("add")]
        [Produces("application/json")]
        public async Task<ActionResult<TIDto>> Add(TIDto dto)
        {
            // Add a check to make sure the DTO has the proper value
            var newTEntity = _mapper.Map<TEntity>(dto);

            var results = await _service.AddAsync(newTEntity);
            await _service.SaveChangesAsync();

            return Ok(_mapper.Map<TIDto>(results));
        }

        /// <summary>
        /// Return one record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> record</returns>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<TEntity>> GetById(int id)
        {
            var results = await _service.GetAsync(id);

            return Ok(_mapper.Map<TEntity>(results));
        }

        /// <summary>
        /// Update an existing dto data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Returns the updated dto data</returns>
        [HttpPut("update")]
        [Produces("application/json")]
        public async Task<ActionResult<TIDto>> Update(TIDto dto)
        {
            var newTEntity = _mapper.Map<TEntity>(dto);

            var results = await _service.Update(newTEntity);

            if (results == null)
            {
                var typeName = typeof(TEntity);
                _logger.LogWarning($"Update {typeName} failed for {typeName} id {dto.Id}. {typeName} not found");
                return NotFound();
            }

            await _service.SaveChangesAsync();

            return Ok(_mapper.Map<TIDto>(results));
        }

        /// <summary>
        /// Delete a TEntity
        /// </summary>
        /// <param name="id">Id of current TEntity to be deleted</param>
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
