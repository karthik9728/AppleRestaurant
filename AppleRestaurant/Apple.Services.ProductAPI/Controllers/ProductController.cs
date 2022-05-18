using Apple.Services.ProductAPI.DTO.Product;
using Apple.Services.ProductAPI.DTO.Response;
using Apple.Services.ProductAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apple.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDto = await _productRepository.GetProducts();
                _response.Result = productDto;
                _response.DisplayMessage = "Date Fetched From Database";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
                _response.DisplayMessage = "Date Fetched From Database";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductByName(name);
                _response.Result = productDto;
                _response.DisplayMessage = "Date Fetched From Database";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = productDto;
                _response.DisplayMessage = "Date Fetched From Database";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = productDto;
                _response.DisplayMessage = "Date Fetched From Database";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response; 
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool IsSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = IsSuccess;
                _response.DisplayMessage = "Date Fetched From Database";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }




    }
}
