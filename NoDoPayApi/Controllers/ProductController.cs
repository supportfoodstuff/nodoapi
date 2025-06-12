using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("all-products")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAllProductsAsync([FromQuery] int userId, [FromQuery] string keyword = "", [FromQuery] int limit = 25)
        {
            var products = await _productRepository.GetAllProductsAsync(userId, keyword, limit);
            return Ok(products);
        }
        
        [HttpGet("all-by-user-id")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAllByUserIdAsync([FromQuery] int userId)
        {
            var products = await _productRepository.GetAllByUserIdAsync(userId);
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // GET: api/Product/by-sku/ABC123
        [HttpGet("by-sku/{sku}")]
        public async Task<ActionResult<ProductEntity>> GetBySku(string sku)
        {
            var product = await _productRepository.GetBySkuAsync(sku);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductEntity product)
        {
            if (product == null) return BadRequest();
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductEntity product)
        {
            if (product == null || product.Id != id) return BadRequest();
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
