using Apple.Web.DTO.AppleServicesProductAPI.Product;

namespace Apple.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> GetProductByNameAsync<T>(string name, string token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);

    }
}
