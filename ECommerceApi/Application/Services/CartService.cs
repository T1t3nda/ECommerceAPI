using AutoMapper;
using ECommerceApi.Application.DTOs;
using ECommerceApi.Application.Services.Interfaces;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Domain.Repositories;

namespace ECommerceApi.Application.Services
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartByUserIdAsync(string userId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                await _cartRepository.AddAsync(cart);
            }
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> AddToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                await _cartRepository.AddAsync(cart);
            }

            var existingItem = cart.CartItems?.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = await _productRepository.GetByIdAsync(productId);

                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity
                };

                if (cart.CartItems == null)
                    cart.CartItems = new List<CartItem>();

                cart.CartItems.Add(cartItem);
            }

            await _cartRepository.UpdateAsync(cart);
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> UpdateCartItemAsync(string userId, int cartItemId, int quantity)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            var cartItem = cart.CartItems.FirstOrDefault(i => i.Id == cartItemId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                await _cartRepository.UpdateAsync(cart);
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> RemoveFromCartAsync(string userId, int cartItemId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            await _cartRepository.RemoveItemAsync(cartItemId);
            return _mapper.Map<CartDto>(cart);
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            await _cartRepository.ClearCartAsync(cart.Id);
        }
    }
}
