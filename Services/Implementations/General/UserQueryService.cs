using woolly_friends.Data;
using woolly_friends.Models.DTOs.General;
using woolly_friends.Models.ViewModels.UserDisplay;
using woolly_friends.Services.Interfaces.General;

namespace woolly_friends.Services.Implementations.General
{
    public class UserQueryService : IUserQueryService
    {
        private readonly AppDbContext _context;
        private readonly IPaginationService _pagination;

        public UserQueryService(AppDbContext context, IPaginationService pagination)
        {
            _context = context;
            _pagination = pagination;
        }

        public async Task<PaginatedResult<UserDisplayViewModel>> GetPaginatedUsersAsync(int pageNumber, int pageSize)
        {
            var query = _context.Users
                .OrderBy(u => u.Id)
                .Select(u => new UserDisplayViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    UserEmail = u.UserEmail,
                    UserContact = u.UserContact,
                    UserRole = u.UserRole.ToString(),
                    IsActive = u.IsActive
                });

            return await _pagination.GetPaginatedAsync(query, pageNumber, pageSize);
        }
    }
}