using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;

namespace CoffeeMachineManager.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly CoffeeMachineManager.Data.ApplicationDbContext _context;

        public DetailsModel(CoffeeMachineManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
