using woolly_friends.Models.ViewModels.UserProfile;

namespace woolly_friends.Services.Interfaces.UserServices
{
    public interface IUpdateProfileService
    {
        Task<UpdateProfileViewModel?> GetUserProfileAsync(int userId);
        Task<bool> UpdateUserProfileAsync(UpdateProfileViewModel model, IFormFile? profileImage);
    }
}
