using Apple.Services.ProductAPI.Data;
using Apple.Services.ProductAPI.DTO.Product;
using Apple.Services.ProductAPI.Model;
using Apple.Services.ProductAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apple.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        //public Task<ProductDto> UpdateProduct(ProductDto productDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetProductByName(string name)
        {
            Product product = await _db.Products.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.OrderBy(x => x.ProductId).ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

    }
}
