using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NoDoPayApi.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISettingRepository _settingRepository;

        public UserController(IUserRepository userRepository, ISettingRepository settingRepository)
        {
            _userRepository = userRepository;
            _settingRepository = settingRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // GET: api/User/by-email/user@example.com
        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<UserEntity>> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserEntity user)
        {
            if (user == null) return BadRequest();

            await _userRepository.AddAsync(user);

            var settings = (await _settingRepository.GetAllAsync()).ToList();

            var availableBalanceSetting = settings.GetSetting("total_customer_available_balance");
            var currentBalanceSetting = settings.GetSetting("total_customer_current_balance");
            var collateralValueSetting = settings.GetSetting("total_customer_collateral_value");
            var creditLimitSettings = settings.GetSetting("total_credit_limit");
            var totalCustomerSetting = settings.GetSetting("total_customers");

            if (currentBalanceSetting == null || collateralValueSetting == null || totalCustomerSetting == null || availableBalanceSetting == null || creditLimitSettings == null)
                return StatusCode(500, "One or more required settings are missing.");

            // Parse and update setting values
            
            decimal creditLimitBalance = Validator.TryParseDecimal(creditLimitSettings.SettingValue);
            decimal currentBalance = Validator.TryParseDecimal(currentBalanceSetting.SettingValue) + user.CurrentBalance;
            decimal collateralValue = Validator.TryParseDecimal(collateralValueSetting.SettingValue) + user.CollateralValue;
            decimal totalCustomers = Validator.TryParseDecimal(totalCustomerSetting.SettingValue) + 1;
            decimal availableBalance = creditLimitBalance - currentBalance;

            // Update settings
            await UpdateSettingValueAsync(_settingRepository, availableBalanceSetting, availableBalance);
            await UpdateSettingValueAsync(_settingRepository, currentBalanceSetting, currentBalance);
            await UpdateSettingValueAsync(_settingRepository, collateralValueSetting, collateralValue);
            await UpdateSettingValueAsync(_settingRepository, totalCustomerSetting, totalCustomers);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        private static async Task UpdateSettingValueAsync(ISettingRepository repo, SettingEntity setting, decimal newValue)
        {
            setting.SettingValue = newValue.ToString("G", System.Globalization.CultureInfo.InvariantCulture);
            await repo.UpdateAsync(setting);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserEntity user)
        {
            if (user == null || user.Id != id) return BadRequest();
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }

        // POST: api/User/sign-in-admin
        [HttpPost("sign-in-admin")]
        public async Task<IActionResult> SignInAdmin([FromForm] string email, [FromForm] string passwordHash)
        {
            var user = await _userRepository.SignInAdminAsync(email, passwordHash);
            if (user == null) return Unauthorized();
            return Ok(user);
        }

        // POST: api/User/sign-in-customer
        [HttpPost("sign-in-customer")]
        public async Task<IActionResult> SignInCustomer([FromForm] string email, [FromForm] string passwordHash)
        {
            var user = await _userRepository.SignInCustomerAsync(email, passwordHash);
            if (user == null) return Unauthorized();
            return Ok(user);
        }

        // GET: api/User/customers?search=paul&limit=50
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetCustomers([FromQuery] string search = "", [FromQuery] int limit = 100)
        {
            var customers = await _userRepository.GetCustomersAsync(search, limit);
            return Ok(customers);
        }

        // PUT: api/User/block/5
        [HttpPut("block/{id}")]
        public async Task<IActionResult> BlockUser(int id)
        {
            var success = await _userRepository.BlockUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // PUT: api/User/activate/5
        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var success = await _userRepository.ActivateUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // GET: api/User/summary
        [HttpGet("summary")]
        public async Task<IActionResult> GetUserBalanceSummary()
        {
            var availableBalance = await _userRepository.GetTotalAvailableBalanceAsync();
            var currentBalance = await _userRepository.GetTotalCurrentBalanceAsync();
            var creditLimit = await _userRepository.GetTotalCreditLimitAsync();
            var collateralValue = await _userRepository.GetTotalCollateralValueAsync();

            var summary = new
            {
                TotalAvailableBalance = availableBalance,
                TotalCurrentBalance = currentBalance,
                TotalCreditLimit = creditLimit,
                TotalCollateralValue = collateralValue
            };

            return Ok(summary);
        }
    }
}
