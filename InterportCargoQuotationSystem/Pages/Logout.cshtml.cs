using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterportCargoQuotationSystem.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
        }
    }
}
