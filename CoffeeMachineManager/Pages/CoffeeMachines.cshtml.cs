using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachineManager.Pages
{
    public class CoffeeMachinesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CoffeeMachinesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CoffeeMachine> CoffeeMachines { get; set; } = new List<CoffeeMachine>();

        public void OnGet()
        {
            CoffeeMachines = _context.CoffeeMachines.ToList();
        }
    }
}
