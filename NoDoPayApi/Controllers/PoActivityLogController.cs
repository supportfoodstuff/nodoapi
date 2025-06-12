using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoActivityLogController : ControllerBase
    {
        private readonly IPoActivityLogRepository _activityLogRepository;

        public PoActivityLogController(IPoActivityLogRepository activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }

        // GET: api/PoActivityLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoActivityLogEntity>>> GetAll()
        {
            var logs = await _activityLogRepository.GetAllAsync();
            return Ok(logs);
        }

        // GET: api/PoActivityLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoActivityLogEntity>> GetById(int id)
        {
            var log = await _activityLogRepository.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        // GET: api/PoActivityLog/by-po/3
        [HttpGet("by-po/{purchaseOrderId}")]
        public async Task<ActionResult<IEnumerable<PoActivityLogEntity>>> GetByPurchaseOrderId(int purchaseOrderId)
        {
            var logs = await _activityLogRepository.GetByPurchaseOrderIdAsync(purchaseOrderId);
            return Ok(logs);
        }

        // POST: api/PoActivityLog
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PoActivityLogEntity log)
        {
            if (log == null) return BadRequest();

            await _activityLogRepository.AddAsync(log);
            return CreatedAtAction(nameof(GetById), new { id = log.Id }, log);
        }

        // DELETE: api/PoActivityLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _activityLogRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _activityLogRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
