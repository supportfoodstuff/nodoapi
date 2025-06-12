using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly AppDbContext _dbContext;

        public FaqRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateFAQAsync(FaqEntity faq)
        {
            try
            {
                faq.created_on = DateTime.UtcNow;
                faq.updated_on = DateTime.UtcNow;

                await _dbContext.Faqs.AddAsync(faq);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<FaqEntity>> FetchAllFAQsAsync()
        {
            return await _dbContext.Faqs
                .OrderByDescending(c => c.created_on)
                .ToListAsync();
        }

        public async Task<List<FaqEntity>> FetchAllFAQsAsync(int limit, string keyword = "")
        {
            var query = _dbContext.Faqs.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();

                query = query.Where(faq =>
                    faq.category.ToLower().Contains(keyword) ||
                    faq.question.ToLower().Contains(keyword) ||
                    faq.answer.ToLower().Contains(keyword)
                );
            }

            return await query
                .OrderByDescending(faq => faq.created_on) // Sort by latest created
                .Take(limit) // Apply limit
                .ToListAsync();
        }


        public async Task<bool> UpdateFAQAsync(FaqEntity updateFAQ)
        {
            try
            {
                var existingFAQ = await _dbContext.Faqs.FirstOrDefaultAsync(c => c.Id == updateFAQ.Id);
                if (existingFAQ == null)
                    return false;

                existingFAQ.question = updateFAQ.question;
                existingFAQ.answer = updateFAQ.answer;
                existingFAQ.category = updateFAQ.category;
                existingFAQ.updated_on = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PublishFAQAsync(int id)
        {
            try
            {
                var existingFAQ = await _dbContext.Faqs.FirstOrDefaultAsync(c => c.Id == id);
                if (existingFAQ == null)
                    return false;

                existingFAQ.published = true;
                existingFAQ.updated_on = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UnPublishFAQAsync(int id)
        {
            try
            {
                var existingFAQ = await _dbContext.Faqs.FirstOrDefaultAsync(c => c.Id == id);
                if (existingFAQ == null)
                    return false;

                existingFAQ.published = false;
                existingFAQ.updated_on = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFAQAsync(int faqId)
        {
            try
            {
                var faq = await _dbContext.Faqs.FirstOrDefaultAsync(c => c.Id == faqId);
                if (faq == null)
                    return false;

                _dbContext.Faqs.Remove(faq);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
