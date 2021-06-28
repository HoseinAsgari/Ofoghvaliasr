namespace OnlineShop.Domain.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public ulong Count { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
