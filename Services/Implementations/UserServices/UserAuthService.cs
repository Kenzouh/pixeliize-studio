using Microsoft.EntityFrameworkCore;
using woolly_friends.Data;
using woolly_friends.Models.Tables;
using woolly_friends.Services.Interfaces.UserServices;

namespace woolly_friends.Services.Implementations.UserServices
{
    public class UserAuthService : IUserAuthService
    {
        // this part communicates with database
        private readonly AppDbContext _context;

        public UserAuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateUserAsync(string email, string password)
        {
            // This part will check if email is registered and active.
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email && u.IsActive);
            if (user == null) return null;

            // password checker duh
            bool passwordCorrect = BCrypt.Net.BCrypt.Verify(password, user.UserPassword);
            return passwordCorrect ? user : null;
        }
    }
}