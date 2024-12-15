using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeMachineManager.Pages
{
    [Authorize]
    public class ReportsModel : PageModel
    {
        public void OnGet()
        {
            // Logic to fetch and display reports
        }
    }
}
