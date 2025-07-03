using Microsoft.EntityFrameworkCore;
using woolly_friends.Data;
using woolly_friends.Models.Tables;
using woolly_friends.Models.ViewModels.UserAuth;
using woolly_friends.Services.Interfaces.UserServices;

namespace woolly_friends.Services.Implementations.UserServices
{
    public class RegistrationService : IRegistrationService
    {
        // this part communicates with database
        private readonly AppDbContext _context;
        private readonly IPasswordHasherService _passwordHasher;

        public RegistrationService(AppDbContext context, IPasswordHasherService passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<(bool Success, string ErrorMessage)> RegisterUserAsync(SignUpViewModel model)
        {
            string loweredEmail = model.UserEmail.Trim().ToLower();

            // checks if email exists, duh
            bool emailExists = await _context.Users.AnyAsync(u => u.UserEmail == loweredEmail);
            if (emailExists)
            {
                return (false, "Email is already registered.");
            }

            // hashes ur password
            string hashedPassword = _passwordHasher.HashPassword(model.UserPassword);

            // creates the user
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserEmail = loweredEmail,
                UserPassword = hashedPassword,
                Username = $"{model.FirstName} {model.LastName}",
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, null);
        }
    }
}