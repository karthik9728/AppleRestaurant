using Apple.Services.ShoppingCartAPI.Model;

namespace Apple.Services.ShoppingCartAPI.DTO
{
    public class CartDto
    {
        public CardHeader CardHeader { get; set; }
        public IEnumerable<CardDetails> CardDetails { get; set; }
    }
}
