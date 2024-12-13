using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;

namespace CoffeeMachineManager.Pages
{
    public class DeleteCoffeeMachinesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteCoffeeMachinesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoffeeMachine CoffeeMachine { get; set; }

        public IActionResult OnGet(int id)
        {
            CoffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);

            if (CoffeeMachine == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var coffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);

            if (coffeeMachine == null)
            {
                return NotFound();
            }

            _context.CoffeeMachines.Remove(coffeeMachine);
            _context.SaveChanges();

            return RedirectToPage("CoffeeMachines");
        }
    }
}
