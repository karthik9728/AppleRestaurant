using System.ComponentModel.DataAnnotations;

namespace Apple.Web.DTO.AppleServicesProductAPI.Product
{
    public class ProductDto
    {
        public ProductDto()
        {
            Count = 1;
        }
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Range(0,100)]
        public int Count { get; set; }
    }
}
