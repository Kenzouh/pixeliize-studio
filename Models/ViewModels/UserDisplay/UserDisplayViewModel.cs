namespace woolly_friends.Models.ViewModels.UserDisplay
{
    public class UserDisplayViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}