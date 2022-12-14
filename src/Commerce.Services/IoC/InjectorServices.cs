using Commerce.Application.Transfers.Requests;
using Commerce.Services.Services.ProductServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Services.IoC
{
    public static class InjectorServices
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IValidator<ProductRequest>, ProductValidator>();
        }
    }
}
