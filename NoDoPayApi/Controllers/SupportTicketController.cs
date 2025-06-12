using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportTicketController : ControllerBase
    {
        private readonly ISupportTicketRepository _ticketRepository;

        public SupportTicketController(ISupportTicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // GET: api/SupportTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicketEntity>>> GetAll()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return Ok(tickets);
        }

        // GET: api/SupportTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicketEntity>> GetById(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        // GET: api/SupportTicket/by-user/7
        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<SupportTicketEntity>>> GetByUserId(int userId)
        {
            var tickets = await _ticketRepository.GetByUserIdAsync(userId);
            return Ok(tickets);
        }

        // POST: api/SupportTicket
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SupportTicketEntity ticket)
        {
            if (ticket == null) return BadRequest();
            await _ticketRepository.AddAsync(ticket);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        // PUT: api/SupportTicket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupportTicketEntity ticket)
        {
            if (ticket == null || ticket.Id != id) return BadRequest();
            await _ticketRepository.UpdateAsync(ticket);
            return NoContent();
        }

        // DELETE: api/SupportTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _ticketRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _ticketRepository.DeleteAsync(id);
            return NoContent();
        }

        // PUT: api/SupportTicket/open/5
        [HttpPut("open/{id}")]
        public async Task<IActionResult> MarkAsOpen(int id)
        {
            var success = await _ticketRepository.MarkAsOpenAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // PUT: api/SupportTicket/closed/5
        [HttpPut("closed/{id}")]
        public async Task<IActionResult> MarkAsClosed(int id)
        {
            var success = await _ticketRepository.MarkAsClosedAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

    }
}
