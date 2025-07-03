using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models.ViewModels.UserAuth;
using woolly_friends.Services.Interfaces.UserServices;

namespace woolly_friends.Controllers
{
    public class LoginController : Controller
    {
        // for the login logic
        private readonly IUserAuthService _userAuthService;

        public LoginController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
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
            string loweredEmail = model.UserEmail.Trim().ToLower();
            var user = await _userAuthService.AuthenticateUserAsync(loweredEmail, model.UserPassword);
            if (user == null)
            {
                ModelState.AddModelError("UserEmail", "Invalid email or password.");
                return View(model);
            }

            // saves info to session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("UserImgPath", user.UserImgPath);
            HttpContext.Session.SetString("UserRole", user.UserRole.ToString());

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