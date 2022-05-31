using Apple.Services.ShoppingCartAPI.Model;

namespace Apple.Services.ShoppingCartAPI.DTO
{
    public class CardDetailsDto
    {
        public int CardDeatilsId { get; set; }
        public int CardHeaderId { get; set; }
        public virtual CardHeader CardHeader { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}
