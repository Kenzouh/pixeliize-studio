using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Admin
        public IActionResult PetsPage() 
        {
            return View();
        }

        // Admin
        public IActionResult Orders()
        {
            return View();
        }

        // Admin
        public IActionResult Reviews()
        {
            return View();
        }
    }
}
