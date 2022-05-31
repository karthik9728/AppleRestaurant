using System.ComponentModel.DataAnnotations;

namespace Apple.Services.ShoppingCartAPI.Model
{
    public class CardHeader
    {
        [Key]
        public int CardHeaderId { get; set; } 
        public string userId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
    }
}
