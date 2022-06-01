namespace Apple.Web.DTO.AppleServicesShoppingCartAPI
{
    public class CardHeaderDto
    {
        public int CardHeaderId { get; set; }
        public string userId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
        public double OrderTotal { get; set; }
    }
}
