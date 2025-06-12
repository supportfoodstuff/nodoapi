using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using NoDoPayApi.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepaymentController : ControllerBase
    {
        private readonly IRepaymentRepository _repaymentRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly IUserRepository _userRepository;

        public RepaymentController(IRepaymentRepository repaymentRepository, IUserRepository userRepository, ISettingRepository settingRepository)
        {
            _repaymentRepository = repaymentRepository;
            _userRepository = userRepository;
            _settingRepository = settingRepository;
        }

        // GET: api/Repayment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepaymentEntity>>> GetAll()
        {
            var repayments = await _repaymentRepository.GetAllAsync();
            return Ok(repayments);
        }

        // GET: api/Repayment/by-user
        [HttpGet("by-user")]
        public async Task<ActionResult<IEnumerable<RepaymentEntity>>> GetByUserId([FromQuery] int userId, [FromQuery] string keyword = "", [FromQuery] int limit = 25)
        {
            var repayments = await _repaymentRepository.GetRepaymentsAsync(userId, keyword, limit);
            return Ok(repayments);
        }
        
        // GET: api/Repayment/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RepaymentEntity>>> GetAllRepayments([FromQuery] string keyword = "", [FromQuery] int limit = 25)
        {
            var repayments = await _repaymentRepository.GetAllRepayments(   keyword, limit);
            return Ok(repayments);
        }

        // GET: api/Repayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepaymentEntity>> GetById(int id)
        {
            var repayment = await _repaymentRepository.GetByIdAsync(id);
            if (repayment == null) return NotFound();
            return Ok(repayment);
        }

        // GET: api/Repayment/by-po/4
        [HttpGet("by-po/{purchaseOrderId}")]
        public async Task<ActionResult<IEnumerable<RepaymentEntity>>> GetByPurchaseOrderId(int purchaseOrderId)
        {
            var repayments = await _repaymentRepository.GetByPurchaseOrderIdAsync(purchaseOrderId);
            return Ok(repayments);
        }

        // POST: api/Repayment
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RepaymentEntity repayment)
        {
            if (repayment == null) return BadRequest();
            await _repaymentRepository.AddAsync(repayment);

            var user = await _userRepository.GetByIdAsync(repayment.UserId);

            user.AvailableBalance = user.CreditLimit - (user.CurrentBalance - repayment.AmountRepaid);
            user.CurrentBalance += repayment.AmountRepaid;

            await _userRepository.UpdateAsync(user);

            var settings = (await _settingRepository.GetAllAsync()).ToList();

            var currentBalanceSetting = settings.GetSetting("total_customer_current_balance");
            var availableBalanceSetting = settings.GetSetting("total_customer_available_balance");
            var creditLimitSettings = settings.GetSetting("total_credit_limit");

            decimal creditLimitBalance = Validator.TryParseDecimal(creditLimitSettings.SettingValue);
            decimal currentBalance = Validator.TryParseDecimal(currentBalanceSetting.SettingValue) - repayment.AmountRepaid;
            decimal availableBalance = creditLimitBalance - currentBalance;

            await UpdateSettingValueAsync(_settingRepository, currentBalanceSetting, currentBalance);
            await UpdateSettingValueAsync(_settingRepository, availableBalanceSetting, availableBalance);

            return CreatedAtAction(nameof(GetById), new { id = repayment.Id }, repayment);
        }

        private static async Task UpdateSettingValueAsync(ISettingRepository repo, SettingEntity setting, decimal newValue)
        {
            setting.SettingValue = newValue.ToString("G", System.Globalization.CultureInfo.InvariantCulture);
            await repo.UpdateAsync(setting);
        }

        // PUT: api/Repayment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RepaymentEntity repayment)
        {
            if (repayment == null || repayment.Id != id) return BadRequest();
            await _repaymentRepository.UpdateAsync(repayment);
            return NoContent();
        }

        // DELETE: api/Repayment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repaymentRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repaymentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
