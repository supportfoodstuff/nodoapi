using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface IFaqRepository
    {
        Task<bool> CreateFAQAsync(FaqEntity faq);
        Task<List<FaqEntity>> FetchAllFAQsAsync();
        Task<List<FaqEntity>> FetchAllFAQsAsync(int limit, string keyword = "");
        Task<bool> UpdateFAQAsync(FaqEntity updatedFAQ);
        Task<bool> PublishFAQAsync(int id);
        Task<bool> UnPublishFAQAsync(int id);
        Task<bool> DeleteFAQAsync(int faqId);
    }    
}
