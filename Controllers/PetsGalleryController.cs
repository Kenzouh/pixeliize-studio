using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class PetsGalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pet()
        {
            return View();
        }
    }
}
