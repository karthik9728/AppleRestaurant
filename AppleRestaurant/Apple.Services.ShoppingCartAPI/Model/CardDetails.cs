using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apple.Services.ShoppingCartAPI.Model
{
    public class CardDetails
    {
        [Key]
        public int CardDeatilsId { get; set; }
        [ForeignKey("CardHeaderId")]
        public int CardHeaderId { get; set; }
        public virtual CardHeader CardHeader { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }   
        public int Count { get; set; }

    }
}
