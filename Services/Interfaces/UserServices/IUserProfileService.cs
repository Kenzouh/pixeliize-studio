using woolly_friends.Models.Tables;

namespace woolly_friends.Services.Interfaces.UserServices
{
    public interface IUserProfileService
    {
        Task<User?> GetUserByIdAsync(int userId);
        // Task<bool> UpdateUserProfileAsync(int userId, UserProfileUpdateDto updateData);
    }
}