using Commerce.Domain.Entities;

namespace Commerce.Domain.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> Register(Product product);
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<List<Product>> GetByCategory(string category);
        Task<bool> DeleteById(int id);
        Product Update(Product product);
        Task<bool> Exists(int id);
    }
}
