using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class DataPrivacyController : Controller
    {
        [Route("PrivacyPolicy")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
