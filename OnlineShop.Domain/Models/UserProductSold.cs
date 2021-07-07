namespace OnlineShop.Domain.Models
{
    public class UserProductSold
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        
        public User User { get; set; }
        public Product Product { get; set; }
    }
}