using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class PetsGalleryController : Controller
    {
        [Route("PetsGallery")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Pet")]
        public IActionResult Pet()
        {
            return View();
        }
    }
}
