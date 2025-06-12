using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubUserController : ControllerBase
    {
        private readonly ISubUserRepository _subUserRepository;

        public SubUserController(ISubUserRepository subUserRepository)
        {
            _subUserRepository = subUserRepository;
        }

        // GET: api/SubUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubUserEntity>>> GetAll()
        {
            var users = await _subUserRepository.GetAllAsync();
            return Ok(users);
        }

        // GET: api/SubUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubUserEntity>> GetById(int id)
        {
            var user = await _subUserRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // GET: api/SubUser/by-email/user@example.com
        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<SubUserEntity>> GetByEmail(string email)
        {
            var user = await _subUserRepository.GetByEmailAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/SubUser
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SubUserEntity user)
        {
            if (user == null) return BadRequest();
            await _subUserRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/SubUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubUserEntity user)
        {
            if (user == null || user.Id != id) return BadRequest();
            await _subUserRepository.UpdateAsync(user);
            return NoContent();
        }

        // DELETE: api/SubUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _subUserRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _subUserRepository.DeleteAsync(id);
            return NoContent();
        }

        // POST: api/SubUser/sign-in
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromForm] string email, [FromForm] string passwordHash)
        {
            var user = await _subUserRepository.SignInAsync(email, passwordHash);
            if (user == null) return Unauthorized();
            return Ok(user);
        }

        // GET: api/SubUser/by-user/7
        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<SubUserEntity>>> GetByUserId(int userId)
        {
            var subs = await _subUserRepository.GetUserSubAccountsAsync(userId);
            return Ok(subs);
        }

        // PUT: api/SubUser/block/5
        [HttpPut("block/{id}")]
        public async Task<IActionResult> BlockUser(int id)
        {
            var success = await _subUserRepository.BlockUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // PUT: api/SubUser/activate/5
        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var success = await _subUserRepository.ActivateUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
