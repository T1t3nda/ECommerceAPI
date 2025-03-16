using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetByUserIdAsync(string userId);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task AddItemAsync(CartItem item);
        Task RemoveItemAsync(int cartItemId);
        Task ClearCartAsync(int cartId);
    }
}
