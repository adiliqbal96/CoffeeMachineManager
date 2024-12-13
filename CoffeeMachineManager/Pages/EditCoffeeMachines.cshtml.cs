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

        public IActionResult OnGet(int id)
        {
            CoffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);

            if (CoffeeMachine == null)
            {
                return NotFound();
            }

            return Page();
        }

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

            return RedirectToPage("CoffeeMachines");
        }
    }
}
