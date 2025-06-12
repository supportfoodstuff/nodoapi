using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorEntity>>> GetAll()
        {
            var vendors = await _vendorRepository.GetAllAsync();
            return Ok(vendors);
        }

        // GET: api/Vendor/by-user
        [HttpGet("by-user")]
        public async Task<ActionResult<IEnumerable<VendorEntity>>> GetByUserId([FromQuery] int userId, [FromQuery] string? keyword = "", [FromQuery] int limit = 25)
        {
            var vendors = await _vendorRepository.GetVendorsAsync(userId, keyword, limit);
            return Ok(vendors);
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorEntity>> GetById(int id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);
            if (vendor == null) return NotFound();
            return Ok(vendor);
        }

        // GET: api/Vendor/by-name/Evergreen Ltd
        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<VendorEntity>> GetByName(string name)
        {
            var vendor = await _vendorRepository.GetByNameAsync(name);
            if (vendor == null) return NotFound();
            return Ok(vendor);
        }

        // POST: api/Vendor
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VendorEntity vendor)
        {
            if (vendor == null) return BadRequest();
            await _vendorRepository.AddAsync(vendor);
            return CreatedAtAction(nameof(GetById), new { id = vendor.Id }, vendor);
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VendorEntity vendor)
        {
            if (vendor == null || vendor.Id != id) return BadRequest();
            await _vendorRepository.UpdateAsync(vendor);
            return NoContent();
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _vendorRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _vendorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
