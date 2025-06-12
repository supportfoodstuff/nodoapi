using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionEntity>>> GetAll([FromQuery] int limit = 100, [FromQuery] string search = "")
        {
            var transactions = await _transactionRepository.GetAllAsync(limit, search);
            return Ok(transactions);
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionEntity>> GetById(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        // GET: api/Transaction/by-ref/REF-123456
        [HttpGet("by-ref/{referenceCode}")]
        public async Task<ActionResult<TransactionEntity>> GetByReferenceCode(string referenceCode)
        {
            var transaction = await _transactionRepository.GetByReferenceCodeAsync(referenceCode);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        // GET: api/Transaction/by-user/7
        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<TransactionEntity>>> GetByUserId(int userId)
        {
            var transactions = await _transactionRepository.GetByUserIdAsync(userId);
            return Ok(transactions);
        }

        // GET: api/Transaction/by-po/3
        [HttpGet("by-po/{purchaseOrderId}")]
        public async Task<ActionResult<IEnumerable<TransactionEntity>>> GetByPurchaseOrderId(int purchaseOrderId)
        {
            var transactions = await _transactionRepository.GetByPurchaseOrderIdAsync(purchaseOrderId);
            return Ok(transactions);
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TransactionEntity transaction)
        {
            if (transaction == null) return BadRequest();
            await _transactionRepository.AddAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TransactionEntity transaction)
        {
            if (transaction == null || transaction.Id != id) return BadRequest();
            await _transactionRepository.UpdateAsync(transaction);
            return NoContent();
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _transactionRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _transactionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
