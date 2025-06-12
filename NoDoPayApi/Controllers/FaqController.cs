using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NoDoPayApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly IFaqRepository _repository;

        public FaqController(IFaqRepository repository)
        {
            _repository = repository;
        }

        // POST: api/faq/add-faq
        [HttpPost("add-faq")]
        public async Task<IActionResult> AddFAQ([FromBody] FaqEntity faq)
        {
            try
            {
                var result = await _repository.CreateFAQAsync(faq);
                if (!result)
                    return StatusCode(500, "Failed to add faq.");

                return Ok("FAQ added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding faq: {ex.Message}");
            }
        }

        // PUT: api/faq/update-faq
        [HttpPut("update-faq")]
        public async Task<IActionResult> UpdateFAQ([FromBody] FaqEntity faq)
        {
            try
            {
                var result = await _repository.UpdateFAQAsync(faq);
                if (!result)
                    return StatusCode(500, "Failed to update faq.");

                return Ok("FAQ updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating faq: {ex.Message}");
            }
        }

        // PUT: api/faq/publish-faq
        [HttpPut("publish-faq")]
        public async Task<IActionResult> PublishFAQ(int faq_id)
        {
            try
            {
                var result = await _repository.PublishFAQAsync(faq_id);
                if (!result)
                    return StatusCode(500, "Failed to publish faq.");

                return Ok("FAQ publish successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error publishing faq: {ex.Message}");
            }
        }
        
        // PUT: api/faq/un-publish-faq
        [HttpPut("unpublish-faq")]
        public async Task<IActionResult> UnPublishFAQ(int faq_id)
        {
            try
            {
                var result = await _repository.UnPublishFAQAsync(faq_id);
                if (!result)
                    return StatusCode(500, "Failed to unpublish faq.");

                return Ok("FAQ unpublish successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error unpublishing faq: {ex.Message}");
            }
        }

        // GET: api/faq/fetch-faqs
        [HttpGet("fetch-faqs")]
        public async Task<IActionResult> FetchFAQs()
        {
            try
            {
                var faqs = await _repository.FetchAllFAQsAsync();
                if (faqs == null || !faqs.Any())
                    return NotFound("No faq found.");

                return Ok(faqs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching faqs: {ex.Message}");
            }
        }

        // GET: api/faq/fetch-all-faqs
        [HttpGet("fetch-all-faqs")]
        public async Task<IActionResult> FetchFAQs(int limit, string keyword = "")
        {
            try
            {
                var faqs = await _repository.FetchAllFAQsAsync(limit, keyword);
                if (faqs == null || !faqs.Any())
                    return NotFound("No faq found.");

                return Ok(faqs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching faqs: {ex.Message}");
            }
        }

        // DELETE: api/faq/delete-faq
        [HttpDelete("delete-faq")]
        public async Task<IActionResult> DeleteFAQ(int faq_id)
        {
            try
            {
                var result = await _repository.DeleteFAQAsync(faq_id);
                if (!result)
                    return StatusCode(500, "Failed to delete faq.");

                return Ok("FAQ deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting faq: {ex.Message}");
            }
        }
    }
}
