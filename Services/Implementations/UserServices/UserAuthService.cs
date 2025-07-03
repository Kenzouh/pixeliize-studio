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
        private readonly IPasswordHasherService _passwordHasher;

        public UserAuthService(AppDbContext context, IPasswordHasherService passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<User?> AuthenticateUserAsync(string email, string password)
        {
            // This part will check if email is registered and active.
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email && u.IsActive);
            if (user == null) return null;

            // password checker duh
            bool passwordCorrect = _passwordHasher.VerifyPassword(password, user.UserPassword);
            return passwordCorrect ? user : null;
        }
    }
}