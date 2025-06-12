using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderItemController : ControllerBase
    {
        private readonly IPurchaseOrderItemRepository _itemRepository;

        public PurchaseOrderItemController(IPurchaseOrderItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/PurchaseOrderItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderItemEntity>>> GetAll()
        {
            var items = await _itemRepository.GetAllAsync();
            return Ok(items);
        }

        // GET: api/PurchaseOrderItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderItemEntity>> GetById(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // GET: api/PurchaseOrderItem/by-po/3
        [HttpGet("by-po/{purchaseOrderId}")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderItemEntity>>> GetByPurchaseOrderId(int purchaseOrderId)
        {
            var items = await _itemRepository.GetByPurchaseOrderIdAsync(purchaseOrderId);
            return Ok(items);
        }

        // POST: api/PurchaseOrderItem
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PurchaseOrderItemEntity item)
        {
            if (item == null) return BadRequest();
            await _itemRepository.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/PurchaseOrderItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PurchaseOrderItemEntity item)
        {
            if (item == null || item.Id != id) return BadRequest();
            await _itemRepository.UpdateAsync(item);
            return NoContent();
        }

        // DELETE: api/PurchaseOrderItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _itemRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _itemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
