using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class PetsReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
