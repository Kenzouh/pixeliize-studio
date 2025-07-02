namespace woolly_friends.Services.Interfaces.UserServices
{
    public interface IUserStatusService
    {
        Task<bool> DeactivateUserAsync(int userId);
        Task<bool> ReactivateUserAsync(int userId);
    }
}