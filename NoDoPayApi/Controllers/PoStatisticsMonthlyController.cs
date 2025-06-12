using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoStatisticsMonthlyController : ControllerBase
    {
        private readonly IPoStatisticsMonthlyRepository _statisticsRepository;

        public PoStatisticsMonthlyController(IPoStatisticsMonthlyRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        // GET: api/PoStatisticsMonthly
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoStatisticsMonthlyEntity>>> GetAll()
        {
            var data = await _statisticsRepository.GetAllAsync();
            return Ok(data);
        }

        // GET: api/PoStatisticsMonthly/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoStatisticsMonthlyEntity>> GetById(int id)
        {
            var item = await _statisticsRepository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // GET: api/PoStatisticsMonthly/by-month/Jan 2024
        [HttpGet("by-month/{month}")]
        public async Task<ActionResult<PoStatisticsMonthlyEntity>> GetByMonth(string month)
        {
            var item = await _statisticsRepository.GetByMonthAsync(month);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/PoStatisticsMonthly
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PoStatisticsMonthlyEntity model)
        {
            if (model == null) return BadRequest();
            await _statisticsRepository.AddAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        // PUT: api/PoStatisticsMonthly/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PoStatisticsMonthlyEntity model)
        {
            if (model == null || model.Id != id) return BadRequest();
            await _statisticsRepository.UpdateAsync(model);
            return NoContent();
        }

        // DELETE: api/PoStatisticsMonthly/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _statisticsRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _statisticsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
