using Commerce.Domain.Entities;

namespace Commerce.Domain.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<Category> Register(Category product);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<List<Category>> GetByCategory(string category);
        Task<Category> Update(Category category);
    }
}
