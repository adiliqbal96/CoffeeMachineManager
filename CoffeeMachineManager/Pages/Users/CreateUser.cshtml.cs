using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineManager.Pages.Users
{
    public class CreateUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 6 and 100 characters", MinimumLength = 6)]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page(); // Ensure the page loads correctly.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync called");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                return Page(); // Return the form with validation errors.
            }

            // Check if the email is already in use.
            Console.WriteLine($"Checking if email {User.Email} already exists");
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Email);
            if (existingUser != null)
            {
                Console.WriteLine($"User with email {User.Email} already exists");
                ModelState.AddModelError("User.Email", "A user with this email already exists.");
                return Page(); // Return with error if email already exists.
            }

            // Hash the password for storage.
            using (var sha256 = SHA256.Create())
            {
                Console.WriteLine("Hashing the password");
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                User.PasswordHash = Convert.ToBase64String(hash);
                Console.WriteLine("Password hashed successfully");
            }

            // Add the new user to the database.
            Console.WriteLine("Adding user to database");
            _context.Users.Add(User);

            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("User saved to database successfully");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database save error: {ex.InnerException?.Message ?? ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the user.");
                return Page(); // Return if there is a database issue.
            }

            // Provide feedback and redirect to the index page.
            TempData["SuccessMessage"] = $"User {User.Name} created successfully!";
            Console.WriteLine($"Redirecting to Index with success message: User {User.Name} created successfully!");
            return RedirectToPage("./Index");
        }
    }
}
