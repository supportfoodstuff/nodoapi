using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportTicketLogController : ControllerBase
    {
        private readonly ISupportTicketLogRepository _logRepository;

        public SupportTicketLogController(ISupportTicketLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        // GET: api/SupportTicketLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicketLogEntity>>> GetAll()
        {
            var logs = await _logRepository.GetAllAsync();
            return Ok(logs);
        }

        // GET: api/SupportTicketLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicketLogEntity>> GetById(int id)
        {
            var log = await _logRepository.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        // GET: api/SupportTicketLog/by-ticket/3
        [HttpGet("by-ticket/{supportTicketId}")]
        public async Task<ActionResult<IEnumerable<SupportTicketLogEntity>>> GetByTicketId(int supportTicketId)
        {
            var logs = await _logRepository.GetByTicketIdAsync(supportTicketId);
            return Ok(logs);
        }

        // POST: api/SupportTicketLog
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SupportTicketLogEntity log)
        {
            if (log == null) return BadRequest();
            await _logRepository.AddAsync(log);
            return CreatedAtAction(nameof(GetById), new { id = log.Id }, log);
        }

        // DELETE: api/SupportTicketLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _logRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _logRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
