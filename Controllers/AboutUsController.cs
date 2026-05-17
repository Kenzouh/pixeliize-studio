using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class AboutUsController : Controller
    {
        [Route("AboutUs")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
