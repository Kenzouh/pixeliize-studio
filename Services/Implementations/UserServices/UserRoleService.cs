using woolly_friends.Data;
using woolly_friends.Models.Tables;
using woolly_friends.Services.Interfaces.UserServices;

namespace woolly_friends.Services.Implementations.UserServices
{
    public class UserRoleService : IUserRoleService
    {
        // this part communicates with database
        private readonly AppDbContext _context;

        public UserRoleService(AppDbContext context)
        {
            _context = context;
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
