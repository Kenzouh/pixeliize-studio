using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class Faqs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PetsForSaleFaqs()
        {
            return View();
        }
    }
}
