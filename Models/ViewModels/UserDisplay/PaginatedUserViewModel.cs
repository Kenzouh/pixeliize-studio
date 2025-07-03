namespace woolly_friends.Models.ViewModels.UserDisplay
{
    public class PaginatedUserViewModel
    {
        public List<UserDisplayViewModel> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}