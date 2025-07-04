using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using woolly_friends.Data;
using woolly_friends.Models.ViewModels.UserProfile;
using woolly_friends.Services.Interfaces.UserServices;

namespace woolly_friends.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUpdateProfileService _updateProfileService;

        public UserProfileController(AppDbContext context, IUpdateProfileService updateProfileService)
        {
            _context = context;
            _updateProfileService = updateProfileService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Index", "Login");

            var user = _context.Users.Include(u => u.AdditionalUserInfo).FirstOrDefault(u => u.Id == userId);
            if (user == null) return RedirectToAction("Index", "Login");

            var profile = new UpdateProfileViewModel
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

            var combinedViewModel = new CombinedProfileViewModel
            {
                User = user,
                UserProfile = profile
            };

            return View(combinedViewModel);
        }

        public IActionResult ViewSection(string section)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Index", "Login");

            var user = _context.Users.Include(u => u.AdditionalUserInfo).FirstOrDefault(u => u.Id == userId);
            if (user == null) return RedirectToAction("Index", "Login");

            var profile = new UpdateProfileViewModel
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

            ViewBag.Tab = section ?? "wishlist";

            var combinedViewModel = new CombinedProfileViewModel
            {
                User = user,
                UserProfile = profile
            };

            return View("Index", combinedViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Login");

            var user = await _context.Users
                .Include(u => u.AdditionalUserInfo)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return RedirectToAction("Index", "Login");

            var viewModel = new UpdateProfileViewModel
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

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UpdateProfileViewModel model, IFormFile? profileImage)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($" - Error: {subError.ErrorMessage}");
                    }
                }

                return View(model);
            }

            var result = await _updateProfileService.UpdateUserProfileAsync(model, profileImage);
            if (!result)
                return BadRequest();

            return RedirectToAction("Index");
        }
    }
}