using Apple.Web.DTO.AppleServicesProductAPI.Product;
using Apple.Web.DTO.AppleServicesProductAPI.Response;
using Apple.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Apple.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();
            var response = await _productService.GetAllProductAsync<ResponseDto>();
            if (response == null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
                //list = JsonConvert.DeserializeObject<List<ProductDto>>(response.Result.ToString());
            }
            return View(list);
        }
    }
}
