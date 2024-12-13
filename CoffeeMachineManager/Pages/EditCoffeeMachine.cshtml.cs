using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;

namespace CoffeeMachineManager.Pages
{
    public class EditCoffeeMachineModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditCoffeeMachineModel(ApplicationDbContext context)
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

            var coffeeMachineToUpdate = _context.CoffeeMachines.FirstOrDefault(m => m.Id == CoffeeMachine.Id);
            if (coffeeMachineToUpdate == null)
            {
                return NotFound();
            }

            coffeeMachineToUpdate.Location = CoffeeMachine.Location;
            coffeeMachineToUpdate.Type = CoffeeMachine.Type;
            coffeeMachineToUpdate.Status = CoffeeMachine.Status;

            _context.SaveChanges();

            TempData["Message"] = "Coffee machine updated successfully!";
            return RedirectToPage("CoffeeMachines");
        }
    }
}
