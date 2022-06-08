using Apple.Web.DTO.AppleServicesProductAPI.Response;
using Apple.Web.DTO.AppleServicesShoppingCartAPI;
using Apple.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Apple.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            //var userId = User.Claims.Where(x => x.Type == "sub")?.FirstOrDefault().Value;
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var responce = await _cartService.GetCartByUserIdAsnyc<ResponseDto>(userId, accessToken);

            CartDto cartDto = new CartDto();

            if (responce != null && responce.IsSuccess)
            {
                cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(responce.Result));
            }

            if (cartDto.CardHeader != null)
            {
                foreach (var detail in cartDto.CardDetails)
                {
                    cartDto.CardHeader.OrderTotal += (detail.Product.Price * detail.Count);
                }
            }
            return cartDto;
        }
    }
}
