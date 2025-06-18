using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }
    }
}
