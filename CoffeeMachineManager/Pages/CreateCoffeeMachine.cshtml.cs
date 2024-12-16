using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        // Dropdown options for location and type
        public List<string> Locations { get; set; } = new List<string>
        {
            "Lobby",
            "Cafeteria",
            "Breakroom",
            "Reception"
        };

        public List<string> Types { get; set; } = new List<string>
        {
            "Espresso Machine",
            "Drip Coffee Maker",
            "Pod Coffee Machine",
            "Bean-to-Cup Machine"
        };

        public IActionResult OnPost()
        {
            // Validate form inputs
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save coffee machine to the database
            _context.CoffeeMachines.Add(CoffeeMachine);
            _context.SaveChanges();

            TempData["Message"] = "Coffee machine added successfully!";
            return RedirectToPage("CoffeeMachines");
        }
    }
}
