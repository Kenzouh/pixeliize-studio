using Microsoft.AspNetCore.Mvc;
using woolly_friends.Models.Tables;
using woolly_friends.Models.ViewModels.UserAuth;
using woolly_friends.Models;

namespace woolly_friends.Controllers
{
    public class SignUpController : Controller
    {
        // This part allows communication with the database.
        private readonly AppDbContext _context;

        public SignUpController(AppDbContext context)
        {
            _context = context;
        }

        // This activates when the registration page is visited.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignUpViewModel model)
        {
            try
            {
                // Checks if every input is present and correct.
                if (ModelState.IsValid)
                {
                    var user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserEmail = model.UserEmail,
                        UserPassword = model.UserPassword,
                        Username = null,
                        UserAddress = null,
                        UserImgPath = null // This should have a default value sa future
                    };

                    _context.Users.Add(user);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Login"); // brings u to login page
                }
            } catch (System.InvalidOperationException)
            {
                Console.WriteLine("Database is non-existent or not connected yet.");
            }



            return View(model); // uhhh idk how to display error msgs lol
        }
    }
}