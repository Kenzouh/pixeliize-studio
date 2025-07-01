using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models.ViewModels.UserAuth;
using woolly_friends.Services;

namespace woolly_friends.Controllers
{
    public class SignUpController : Controller
    {
        // if the controller is the waiter, account service is the chef
        private readonly IAccountService _accountService;
        public SignUpController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // This activates when the registration page is visited.
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SignUpViewModel model)
        {
            // checks if form is invalid
            if (!ModelState.IsValid) return View(model);

            // this is what tries to register the user
            var (success, error) = await _accountService.RegisterUserAsync(model);

            // error handling if unsuccessful
            if (!success)
            {
                ModelState.AddModelError("UserEmail", error);
                return View(model);
            }

            // redirects to login if successful
            return RedirectToAction("Index", "Login");
        }
    }
}