namespace OnlineShop.Application.ViewModels.Admin.User
{
    public class ShowUserDetailsViewModel
    {
        public string UserName { get; set; }
        public int BoughtCount { get; set; }
        public string UserEmail { get; set; }
        public string SignedInDateTime { get; set; }
        public int ViewsCount { get; set; }
        public int LikedCount { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}