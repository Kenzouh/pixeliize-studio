using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models.Tables;
using woolly_friends.Services.Interfaces.General;
using woolly_friends.Services.Interfaces.UserServices;
using woolly_friends.Models.ViewModels.UserDisplay;
using woolly_friends.Data;

namespace woolly_friends.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserQueryService _queryService;
        private readonly IUserRoleService _roleService;
        private readonly IUserStatusService _statusService;
        private readonly AppDbContext _context;

        public ProfileController(IUserQueryService queryService, IUserRoleService roleService, IUserStatusService statusService, AppDbContext context)
        {
            _queryService = queryService;
            _roleService = roleService;
            _statusService = statusService;
            _context = context;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Index", "Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return RedirectToAction("Index", "Login");

            return View(user);
        }

        public IActionResult Orders() => View();
        public IActionResult Reviews() => View();

        [HttpGet]
        public async Task<IActionResult> UserManagement(int page = 1)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            int pageSize = 5;
            var result = await _queryService.GetPaginatedUsersAsync(page, pageSize);

            var viewModel = new PaginatedUserViewModel
            {
                Items = result.Items,
                PageNumber = result.PageNumber,
                TotalPages = result.TotalPages,
                TotalCount = result.TotalCount
            };

            return View(viewModel);
        }
        // Promotes a user into an admin
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Promote(int userId, int page)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            await _roleService.UpdateUserRoleAsync(userId, Role.Admin);
            return RedirectToAction("UserManagement", new { page });
        }

        // Demotes an admin into a user
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Demote(int userId, int page)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            var currentUserId = HttpContext.Session.GetInt32("UserId");
            if (currentUserId == userId)
            {
                TempData["Error"] = "You cannot demote yourself, silly!";
                return RedirectToAction("UserManagement", new { page });
            }

            await _roleService.UpdateUserRoleAsync(userId, Role.User);
            return RedirectToAction("UserManagement", new { page });
        }

        // Deactivates an account
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int userId, int page)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            var currentUserId = HttpContext.Session.GetInt32("UserId");
            if (currentUserId == userId)
            {
                TempData["Error"] = "You cannot ban yourself, silly!";
                return RedirectToAction("UserManagement", new { page });
            }

            await _statusService.DeactivateUserAsync(userId);
            return RedirectToAction("UserManagement", new { page });
        }

        // Reactivates an account
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Reactivate(int userId, int page)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return RedirectToAction("Index", "Home");

            await _statusService.ReactivateUserAsync(userId);
            return RedirectToAction("UserManagement", new { page });
        }
    }
}