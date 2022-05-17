using Apple.Services.ProductAPI.DTO.Product;

namespace Apple.Services.ProductAPI.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int productId);

        Task<ProductDto> GetProductByName(string name);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        //Task<ProductDto> UpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(int productId);
    }
}
