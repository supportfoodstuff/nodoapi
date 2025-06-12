using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoDoPayApi.Util;
using System.Data;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly IUserRepository _userRepository;

        public PurchaseOrderController(IPurchaseOrderRepository purchaseOrderRepository, IUserRepository userRepository, ISettingRepository settingRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _settingRepository = settingRepository;
            _userRepository = userRepository;
        }

        // GET: api/PurchaseOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderEntity>>> GetAll()
        {
            var orders = await _purchaseOrderRepository.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/PurchaseOrder/by-user
        [HttpGet("by-user")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderEntity>>> GetByUserId([FromQuery] int userId, [FromQuery] string keyword = "", [FromQuery] int limit = 25)
        {
            var orders = await _purchaseOrderRepository.GetPurchaseOrdersAsync(userId, keyword, limit);
            return Ok(orders);
        }
        
        [HttpGet("by-admin")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderEntity>>> GetAllPurchaseOrdersAsync([FromQuery] string keyword = "", [FromQuery] int limit = 25)
        {
            var orders = await _purchaseOrderRepository.GetAllPurchaseOrdersAsync(keyword, limit);
            return Ok(orders);
        }

        // GET: api/PurchaseOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderEntity>> GetById(int id)
        {
            var order = await _purchaseOrderRepository.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // GET: api/PurchaseOrder/by-code/PO-000123
        [HttpGet("by-code/{poCode}")]
        public async Task<ActionResult<PurchaseOrderEntity>> GetByPoCode(string poCode)
        {
            var order = await _purchaseOrderRepository.GetByPoCodeAsync(poCode);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // GET: api/PurchaseOrder/by-vendor/4
        [HttpGet("by-vendor/{vendorId}")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderEntity>>> GetByVendorId(int vendorId)
        {
            var orders = await _purchaseOrderRepository.GetByVendorIdAsync(vendorId);
            return Ok(orders);
        }

        // POST: api/PurchaseOrder
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PurchaseOrderEntity order)
        {
            if (order == null) return BadRequest();

            var createdOrder = await _purchaseOrderRepository.AddAsync(order);

            var user = await _userRepository.GetByIdAsync(order.UserId);

            user.AvailableBalance = user.CreditLimit - (user.CurrentBalance + order.Amount);
            user.CurrentBalance += order.AmountOwedByCustomer;

            await _userRepository.UpdateAsync(user);

            var settings = (await _settingRepository.GetAllAsync()).ToList();

            var currentBalanceSetting = settings.GetSetting("total_customer_current_balance");
            var availableBalanceSetting = settings.GetSetting("total_customer_available_balance");
            var creditLimitSettings = settings.GetSetting("total_credit_limit");

            decimal creditLimitBalance = Validator.TryParseDecimal(creditLimitSettings.SettingValue);
            decimal currentBalance = Validator.TryParseDecimal(currentBalanceSetting.SettingValue) + user.CurrentBalance;
            decimal availableBalance = creditLimitBalance - currentBalance;

            await UpdateSettingValueAsync(_settingRepository, currentBalanceSetting, currentBalance);
            await UpdateSettingValueAsync(_settingRepository, availableBalanceSetting, availableBalance);

            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }

        private static async Task UpdateSettingValueAsync(ISettingRepository repo, SettingEntity setting, decimal newValue)
        {
            setting.SettingValue = newValue.ToString("G", System.Globalization.CultureInfo.InvariantCulture);
            await repo.UpdateAsync(setting);
        }

        // PUT: api/PurchaseOrder/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PurchaseOrderEntity order)
        {
            if (order == null || order.Id != id) return BadRequest();
            await _purchaseOrderRepository.UpdateAsync(order);
            return NoContent();
        }

        // DELETE: api/PurchaseOrder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _purchaseOrderRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _purchaseOrderRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
