using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoffeeMachineManager.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CoffeeMachineManager.Data.ApplicationDbContext _context;
        private readonly CoffeeMachineManager.Interfaces.IPasswordHasher _passwordHasher;

        public CreateModel(CoffeeMachineManager.Data.ApplicationDbContext context, Interfaces.IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User.Password = _passwordHasher.GetHash(User.Password ?? throw new NullReferenceException("User password input is null!"));

            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            TempData["Message"] = "User created successfully!";

            return RedirectToPage("/Index"); // Needs to redirects to confirm or failure page.
        }
    }
}
