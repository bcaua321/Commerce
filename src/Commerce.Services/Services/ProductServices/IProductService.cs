using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;

namespace Commerce.Services.Services.ProductServices
{
    public interface IProductService 
    {
        Task<ProductResponse> RegisterProduct(ProductRequest product);
        Task<List<ProductResponse>> GetAllProducts();
        Task<ProductResponse> GetProductById(int id);
        Task<List<ProductResponse>> GetProductsByCategory(string category);
        Task<bool> DeleteById(int id);
        Task<ProductResponse> UpdateProduct(ProductRequest product);
        Task<bool> Exists(int id);
    }
}
