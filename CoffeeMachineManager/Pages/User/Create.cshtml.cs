using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models; // Explicitly use this namespace

namespace CoffeeMachineManager.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly Interfaces.IPasswordHasher _passwordHasher;

        public CreateModel(ApplicationDbContext context, Interfaces.IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CoffeeMachineManager.Models.User User { get; set; } // Explicitly specify the User class

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Hash the password
                User.Password = _passwordHasher.GetHash(User.Password);

                // Add the user to the database
                _context.Users.Add(User);
                await _context.SaveChangesAsync();

                // Success message to be shown on ManageUsers page
                TempData["SuccessMessage"] = "User created successfully!";

                // Redirect back to ManageUsers page
                return RedirectToPage("/User/ManageUsers");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating user: {ex.Message}");
                return Page();
            }
        }
    }
}
