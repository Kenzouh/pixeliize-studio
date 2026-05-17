using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class FaqsController : Controller
    {
        [Route("Faqs-Adoption")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Faqs-Sales")]
        public IActionResult PetsForSaleFaqs()
        {
            return View();
        }
    }
}
