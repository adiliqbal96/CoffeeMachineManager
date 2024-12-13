using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;

namespace CoffeeMachineManager.Pages
{
    public class EditCoffeeMachinesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditCoffeeMachinesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoffeeMachine CoffeeMachine { get; set; }

        // Handle GET request to populate the form
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);

            if (CoffeeMachine == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handle POST request to save changes
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var coffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == CoffeeMachine.Id);
            if (coffeeMachine == null)
            {
                return NotFound();
            }

            coffeeMachine.Location = CoffeeMachine.Location;
            coffeeMachine.Type = CoffeeMachine.Type;
            coffeeMachine.Status = CoffeeMachine.Status;

            _context.SaveChanges();

            return RedirectToPage("/CoffeeMachines");
        }
    }
}
