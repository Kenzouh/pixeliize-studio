using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
