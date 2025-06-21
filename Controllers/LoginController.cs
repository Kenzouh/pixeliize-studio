using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models;
using woolly_friends.Models.ViewModels.UserAuth;

namespace woolly_friends.Controllers
{
    public class LoginController : Controller
    {
        // This part allows communication with the database.
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }
        // This activates when the login page is visited.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // This part will check if email is registered and active.
                    var user = _context.Users.FirstOrDefault(u => u.UserEmail == model.UserEmail && u.IsActive);
                    if (user == null)
                    {
                        ModelState.AddModelError("UserEmail", "Email not found or account is inactive.");
                        return View(model);
                    }

                    // Password checker
                    bool PasswordCorrect = BCrypt.Net.BCrypt.Verify(model.UserPassword, user.UserPassword);

                    if (PasswordCorrect)
                    {
                        // session thing, it lets ur login stay
                        HttpContext.Session.SetInt32("UserId", user.Id);
                        HttpContext.Session.SetString("UserEmail", user.UserEmail);
                        return RedirectToAction("Index", "Home"); // format: file name, folder name. No need to specify View
                    }
                    else
                    {
                        ModelState.AddModelError("UserPassword", "Incorrect password!");
                        return View(model);
                    }
                }

            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("Database is non-existent or not connected yet.");
                return View(model);
            }

            return View(model); // again, add error msg here plz
        }
    }
}
