using ECommerceApi.Application.DTOs;

namespace ECommerceApi.Application.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetCartByUserIdAsync(string userId);
        Task<CartDto> AddToCartAsync(string userId, int productId, int quantity);
        Task<CartDto> UpdateCartItemAsync(string userId, int cartItemId, int quantity);
        Task<CartDto> RemoveFromCartAsync(string userId, int cartItemId);
        Task ClearCartAsync(string userId);
    }
}
