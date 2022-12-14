using Commerce.Data.Context;
using Commerce.Domain.Entities;
using Commerce.Domain.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext _context { get; }
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Product> Register(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .AsNoTracking()
                .Include(x => x.Images)
                .ToListAsync();
        }

        public async Task<List<Product>> GetByCategory(string category)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(x => x.Images)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(x => x.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Product Update(Product product)
        {
            product = _context.Products.Update(product).Entity;

            return product;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = await GetById(id);

            if (result is null)
                return false;

            _context.Products.Remove(result);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }
    }
}
