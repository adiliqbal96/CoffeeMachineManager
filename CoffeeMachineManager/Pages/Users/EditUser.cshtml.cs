using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineManager.Pages.Users
{
    public class EditUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public User User { get; set; }

        public EditUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userInDb = await _context.Users.FindAsync(User.Id);
            if (userInDb == null)
            {
                return NotFound();
            }

            userInDb.Name = User.Name;
            userInDb.Email = User.Email;
            userInDb.Role = User.Role;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
