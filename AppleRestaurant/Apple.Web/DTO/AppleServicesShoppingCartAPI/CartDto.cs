namespace Apple.Web.DTO.AppleServicesShoppingCartAPI
{
    public class CartDto
    {
        public CardHeaderDto CardHeader { get; set; }
        public IEnumerable<CardDetailsDto> CardDetails { get; set; }
    }
}
