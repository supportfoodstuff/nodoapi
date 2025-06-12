using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository _settingRepository;

        public SettingController(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        // GET: api/Setting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingEntity>>> GetAll()
        {
            var settings = await _settingRepository.GetAllAsync();
            return Ok(settings);
        }

        [HttpGet("get-editable")]
        public async Task<ActionResult<IEnumerable<SettingEntity>>> GetOnlyEditable()
        {
            var settings = await _settingRepository.GetEditableAsync();
            return Ok(settings);
        }

        // GET: api/Setting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SettingEntity>> GetById(int id)
        {
            var setting = await _settingRepository.GetByIdAsync(id);
            if (setting == null) return NotFound();
            return Ok(setting);
        }

        // GET: api/Setting/by-key/system-email
        [HttpGet("by-key/{settingKey}")]
        public async Task<ActionResult<SettingEntity>> GetByKey(string settingKey)
        {
            var setting = await _settingRepository.GetByKeyAsync(settingKey);
            if (setting == null) return NotFound();
            return Ok(setting);
        }

        // POST: api/Setting
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SettingEntity setting)
        {
            if (setting == null) return BadRequest();
            await _settingRepository.AddAsync(setting);
            return CreatedAtAction(nameof(GetById), new { id = setting.Id }, setting);
        }

        // PUT: api/Setting/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SettingEntity setting)
        {
            if (setting == null || setting.Id != id) return BadRequest();
            await _settingRepository.UpdateAsync(setting);
            return NoContent();
        }

        // DELETE: api/Setting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _settingRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _settingRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
