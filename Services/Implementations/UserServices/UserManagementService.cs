using woolly_friends.Data;
using woolly_friends.Models.Tables;
using woolly_friends.Services.Interfaces.UserServices;

namespace woolly_friends.Services.Implementations.UserServices
{
    public class UserManagementService : IUserStatusService, IUserRoleService
    {
        // this part communicates with database
        private readonly AppDbContext _context;

        public UserManagementService(AppDbContext context)
        {
            _context = context;
        }

        // user banning
        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        // user unban
        public async Task<bool> ReactivateUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        // promotes or demotes a user
        public async Task<bool> UpdateUserRoleAsync(int userId, Role newRole)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.UserRole = newRole;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}