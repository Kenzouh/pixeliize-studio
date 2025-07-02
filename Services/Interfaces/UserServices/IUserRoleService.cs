using woolly_friends.Models.Tables;

namespace woolly_friends.Services.Interfaces.UserServices
{
    public interface IUserRoleService
    {
        Task<bool> UpdateUserRoleAsync(int userId, Role newRole);
    }
}