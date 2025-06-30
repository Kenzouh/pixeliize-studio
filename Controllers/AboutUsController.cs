using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
