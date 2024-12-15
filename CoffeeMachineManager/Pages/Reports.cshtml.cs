using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachineManager.Pages
{
    public class ReportsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReportsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties for displaying data
        public List<ConsumptionLog> ConsumptionLogs { get; set; } = new List<ConsumptionLog>();
        public List<CoffeeMachine> CoffeeMachines { get; set; } = new List<CoffeeMachine>();

        // Bind property for adding new logs
        [BindProperty]
        public int CoffeeMachineId { get; set; }

        [BindProperty]
        public int CoffeeUsed { get; set; }

        public void OnGet()
        {
            // Fetch all logs with related coffee machine data
            ConsumptionLogs = _context.ConsumptionLogs
                .Select(log => new ConsumptionLog
                {
                    Id = log.Id,
                    CoffeeMachine = new CoffeeMachine
                    {
                        Location = log.CoffeeMachine.Location,
                        Type = log.CoffeeMachine.Type
                    },
                    CoffeeUsed = log.CoffeeUsed,
                    CreatedOn = log.CreatedOn
                })
                .OrderByDescending(log => log.CreatedOn)
                .ToList();

            // Fetch all coffee machines for the dropdown
            CoffeeMachines = _context.CoffeeMachines.ToList();
        }

        public IActionResult OnPost()
        {
            // Validate inputs
            if (CoffeeMachineId <= 0 || CoffeeUsed <= 0)
            {
                ModelState.AddModelError("", "Please provide valid inputs.");
                return Page();
            }

            // Create a new log entry
            var newLog = new ConsumptionLog
            {
                CoffeeMachineId = CoffeeMachineId,
                CoffeeUsed = CoffeeUsed,
                CreatedOn = DateTime.UtcNow
            };

            // Save the log to the database
            _context.ConsumptionLogs.Add(newLog);
            _context.SaveChanges();

            // Redirect back to the Reports page to see the updated list
            return RedirectToPage();
        }
    }
}
