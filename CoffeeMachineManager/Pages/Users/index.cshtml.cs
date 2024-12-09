using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineManager.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found for deletion.");
                TempData["ErrorMessage"] = "The user does not exist.";
                return RedirectToPage();
            }

            Console.WriteLine($"Deleting user: {user.Name}");
            _context.Users.Remove(user);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("User deleted successfully");
                TempData["SuccessMessage"] = $"User {user.Name} deleted successfully!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while deleting the user.";
            }

            return RedirectToPage();
        }
    }
}
