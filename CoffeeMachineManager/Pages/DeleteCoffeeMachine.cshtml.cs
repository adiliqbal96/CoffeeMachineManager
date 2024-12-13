using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;

namespace CoffeeMachineManager.Pages
{
    public class DeleteCoffeeMachineModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteCoffeeMachineModel(ApplicationDbContext context)
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
            var coffeeMachineToDelete = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);
            if (coffeeMachineToDelete == null)
            {
                return NotFound();
            }

            _context.CoffeeMachines.Remove(coffeeMachineToDelete);
            _context.SaveChanges();

            TempData["Message"] = "Coffee machine deleted successfully!";
            return RedirectToPage("CoffeeMachines");
        }
    }
}
