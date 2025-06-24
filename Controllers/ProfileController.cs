using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models;

namespace woolly_friends.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
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

        public IActionResult PetsPage() => View();

        // this for admin
        public IActionResult PetsGallery() => View();
        public IActionResult Orders() => View();
        public IActionResult Reviews() => View();
    }
}
