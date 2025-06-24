using Microsoft.AspNetCore.Mvc;

namespace woolly_friends.Controllers
{
    public class PaymentFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
