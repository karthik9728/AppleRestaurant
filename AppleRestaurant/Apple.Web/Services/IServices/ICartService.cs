﻿using Apple.Web.DTO.AppleServicesShoppingCartAPI;

namespace Apple.Web.Services.IServices
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsnyc<T>(string userId, string token);
        Task<T> AddToCartAsync<T>(CartDto cartDto, string token);
        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token);
        Task<T> RemoveFromCartAsync<T>(int cartId, string token);

    }
}
