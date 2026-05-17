using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class ContactController : Controller
    {
        [Route("Contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}