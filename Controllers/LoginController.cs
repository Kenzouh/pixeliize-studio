using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models.ViewModels.UserAuth;
using woolly_friends.Services;

namespace woolly_friends.Controllers
{
    public class LoginController : Controller
    {
        // for the login logic
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // This activates when the login page is visited.
        [HttpGet]
        public IActionResult Index() => View();


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            // checks if form is invalid
            if (!ModelState.IsValid) return View(model);

            // authenticates the login
            var user = await _accountService.AuthenticateUserAsync(model.UserEmail, model.UserPassword);
            if (user == null)
            {
                ModelState.AddModelError("UserEmail", "Invalid email or password.");
                return View(model);
            }

            // saves info to session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("UserImgPath", user.UserImgPath);

            // redirects to home if successful
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}