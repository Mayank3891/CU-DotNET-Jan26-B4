using API.DTO;
using API.Models;

namespace API.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}
