using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;

namespace CoffeeMachineManager.Pages
{
    public class CreateCoffeeMachineModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateCoffeeMachineModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoffeeMachine CoffeeMachine { get; set; } = new CoffeeMachine();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CoffeeMachines.Add(CoffeeMachine);
            _context.SaveChanges();

            TempData["Message"] = "Coffee machine added successfully!";
            return RedirectToPage("CoffeeMachines");
        }
    }
}
