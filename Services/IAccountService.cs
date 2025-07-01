using woolly_friends.Models.Tables;
using woolly_friends.Models.ViewModels.UserAuth;

namespace woolly_friends.Services
{
    // CONTRACT DEALER
    public interface IAccountService
    {
        // CREATE
        Task<(bool Success, string ErrorMessage)> RegisterUserAsync(SignUpViewModel model);

        // READ
        Task<User?> AuthenticateUserAsync(string email, string password);

    }
}