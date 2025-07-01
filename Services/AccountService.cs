using Microsoft.EntityFrameworkCore;
using woolly_friends.Data;
using woolly_friends.Models.Tables;
using woolly_friends.Models.ViewModels.UserAuth;

namespace woolly_friends.Services
{
    public class AccountService : IAccountService
    {
        // this part communicates with database
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<(bool Success, string ErrorMessage)> RegisterUserAsync(SignUpViewModel model)
        {
            // checks if email exists, duh
            bool emailExists = await _context.Users.AnyAsync(u => u.UserEmail == model.UserEmail);
            if (emailExists)
            {
                return (false, "Invalid attempt!");
            }

            // hashes ur password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.UserPassword);

            // creates the user
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserEmail = model.UserEmail,
                UserPassword = hashedPassword,
                Username = $"{model.FirstName} {model.LastName}",
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, null);
        }

        // READ
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
