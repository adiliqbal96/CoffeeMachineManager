using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeMachineManager.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly Interfaces.IPasswordVerifier _passwordVerifier;

        public LoginModel(ApplicationDbContext context, Interfaces.IPasswordVerifier passwordVerifier)
        {
            _context = context;
            _passwordVerifier = passwordVerifier;
        }

        [BindProperty] public new Models.User User { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(User.Email) || string.IsNullOrEmpty(User.Password))
            {
                ModelState.AddModelError(string.Empty, "Email and Password are required.");
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == User.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }
            else
            {
                bool isPasswordCorrect = _passwordVerifier.VerifyHash(User.Password, user.Password);
                if (!isPasswordCorrect)
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return Page();
                }
            }

            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToPage("/Index");
        }
    }
}
