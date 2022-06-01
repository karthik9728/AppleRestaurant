using Apple.Web.DTO.AppleServicesProductAPI.Product;

namespace Apple.Web.DTO.AppleServicesShoppingCartAPI
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
