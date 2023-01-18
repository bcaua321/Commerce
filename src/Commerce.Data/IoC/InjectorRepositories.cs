using Commerce.Data.Repository;
using Commerce.Domain.Repositories.CategoryRepository;
using Commerce.Domain.Repositories.ProductRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Data.IoC
{
    public static class Repository
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
