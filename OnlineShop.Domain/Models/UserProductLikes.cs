namespace OnlineShop.Domain.Models
{
    public class UserProductLikes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}