using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}