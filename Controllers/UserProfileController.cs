using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models;

namespace woolly_friends.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly AppDbContext _context;

        public UserProfileController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Index", "Login");

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return RedirectToAction("Index", "Login");

            return View(user);
        }

        public IActionResult Orders()
        {
            return View();
        }
    }
}
