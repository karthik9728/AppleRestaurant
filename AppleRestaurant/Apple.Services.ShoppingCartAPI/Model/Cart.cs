namespace Apple.Services.ShoppingCartAPI.Model
{
    public class Cart
    {
        public CardHeader CardHeader { get; set; }
        public IEnumerable<CardDetails> CardDetails { get; set; }

    }
}
