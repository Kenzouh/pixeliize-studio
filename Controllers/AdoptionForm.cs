using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class AdoptionForm : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
