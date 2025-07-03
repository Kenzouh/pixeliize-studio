using woolly_friends.Models.DTOs.General;
using woolly_friends.Models.ViewModels.UserDisplay;

namespace woolly_friends.Services.Interfaces.General
{
    public interface IUserQueryService
    {
        Task<PaginatedResult<UserDisplayViewModel>> GetPaginatedUsersAsync(int pageNumber, int pageSize);
    }
}