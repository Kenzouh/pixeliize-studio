using woolly_friends.Models.ViewModels.UserAuth;

namespace woolly_friends.Services.Interfaces.UserServices
{
    public interface IRegistrationService
    {
        Task<(bool Success, string ErrorMessage)> RegisterUserAsync(SignUpViewModel model);
    }
}