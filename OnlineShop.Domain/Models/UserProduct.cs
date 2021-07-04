namespace OnlineShop.Domain.Models
{
    public class UserProductViews
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
