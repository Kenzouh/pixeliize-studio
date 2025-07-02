using woolly_friends.Models.Tables;

namespace woolly_friends.Services.Interfaces.UserServices
{
    public interface IUserAuthService
    {
        Task<User?> AuthenticateUserAsync(string email, string password);
    }
}