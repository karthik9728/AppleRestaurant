using Apple.Services.ShoppingCartAPI.DTO.Products;

namespace Apple.Services.ShoppingCartAPI.DTO
{
    public class CardDetailsDto
    {
        public int CardDeatilsId { get; set; }
        public int CardHeaderId { get; set; }
        public virtual CardHeaderDto CardHeader { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
