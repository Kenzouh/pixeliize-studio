using woolly_friends.Models.Tables;

namespace woolly_friends.Models.ViewModels.UserProfile
{
    public class CombinedProfileViewModel
    {
        public User User { get; set; }
        public UpdateProfileViewModel UserProfile { get; set; }
    }
}
