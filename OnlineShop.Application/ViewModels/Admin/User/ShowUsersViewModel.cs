namespace OnlineShop.Application.ViewModels.Admin.User
{
    public class ShowUsersViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}