using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class SignUp : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
