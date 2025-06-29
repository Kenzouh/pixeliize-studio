using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}