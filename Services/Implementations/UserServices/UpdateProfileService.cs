using woolly_friends.Data;
using woolly_friends.Models.Tables;
using woolly_friends.Models.ViewModels.UserProfile;
using woolly_friends.Services.Interfaces.UserServices;
using Microsoft.EntityFrameworkCore;
using woolly_friends.Services.Interfaces.General;

namespace woolly_friends.Services.Implementations.UserServices
{
    public class UpdateProfileService : IUpdateProfileService
    {
        private readonly AppDbContext _context;
        private readonly IFileUploadService _fileUploadService;

        public UpdateProfileService(AppDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
        }

        public async Task<UpdateProfileViewModel?> GetUserProfileAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.AdditionalUserInfo)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return null;

            return new UpdateProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserEmail = user.UserEmail,
                UserContact = user.UserContact,
                HomeAddress = user.AdditionalUserInfo?.HomeAddress,
                Birthday = user.AdditionalUserInfo?.Birthday,
                ExistingImagePath = user.UserImgPath
            };
        }

        public async Task<bool> UpdateUserProfileAsync(UpdateProfileViewModel model, IFormFile? profileImage)
        {
            var user = await _context.Users
                .Include(u => u.AdditionalUserInfo)
                .FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user == null) return false;

            // Update main user fields
            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.UserEmail = model.UserEmail ?? user.UserEmail;
            user.UserContact = model.UserContact ?? user.UserContact;
            user.Username = $"{user.FirstName} {user.LastName}";

            // Profile image upload
            if (profileImage != null)
            {
                string uploadPath = await _fileUploadService.UploadFileAsync(profileImage, $"user_{user.Id}", "Profile");
                user.UserImgPath = uploadPath;
            }

            // Handle AdditionalUserInfo
            if (user.AdditionalUserInfo == null)
            {
                user.AdditionalUserInfo = new AdditionalUserInfo
                {
                    Id = user.Id,
                    HomeAddress = model.HomeAddress,
                    Birthday = model.Birthday
                };
            }
            else
            {
                if (!string.IsNullOrEmpty(model.HomeAddress))
                    user.AdditionalUserInfo.HomeAddress = model.HomeAddress;

                if (model.Birthday.HasValue)
                    user.AdditionalUserInfo.Birthday = model.Birthday;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}