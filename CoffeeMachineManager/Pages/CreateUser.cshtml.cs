using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeMachineManager.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User NewUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please ensure all fields are correctly filled.");
                return Page();
            }

            // Additional server-side validation (optional)
            if (_context.Users.Any(u => u.Email == NewUser.Email))
            {
                ModelState.AddModelError("NewUser.Email", "This email is already registered.");
                return Page();
            }

            _context.Users.Add(NewUser);
            _context.SaveChanges();

            return RedirectToPage("Users");
        }
    }
}
