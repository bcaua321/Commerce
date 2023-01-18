using Commerce.Data.Context;
using Commerce.Domain.Entities;
using Commerce.Domain.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _context { get; set; }
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task<List<Category>> GetByCategory(string category)
        {
            var cat = category.Trim().ToLower();
            var result = _context.Categories
                .Where(x => x.Name.Trim().ToLower().Contains(cat));
               
            return await result.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var result = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Category> Register(Category category)
        {
            await _context.Categories
                .AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Update(Category product)
        {
            var result = await GetById(product.Id);

            if(result is null)
                return result;

            _context.Entry(result).CurrentValues.SetValues(product);
            return product;
        }
    }
}
