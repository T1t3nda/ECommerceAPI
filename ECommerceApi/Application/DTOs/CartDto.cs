namespace ECommerceApi.Application.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemDto> CartItems { get; set; }
        public decimal TotalAmount => CartItems?.Sum(i => i.TotalPrice) ?? 0;
    }
}
