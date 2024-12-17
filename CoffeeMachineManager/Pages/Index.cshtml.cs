using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace CoffeeMachineManager.Pages
{
    public class IndexModel : PageModel
    {
        public string UserRole { get; set; }

        public void OnGet()
        {
            // Retrieve the user role from the session
            UserRole = HttpContext.Session.GetString("UserRole");
        }
    }
}