﻿
namespace Apple.Services.ShoppingCartAPI.DTO
{
    public class CartDto
    {
        public CardHeaderDto CardHeader { get; set; }
        public IEnumerable<CardDetailsDto> CardDetails { get; set; }
    }
}
