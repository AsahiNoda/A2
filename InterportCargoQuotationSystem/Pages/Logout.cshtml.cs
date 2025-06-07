using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace InterportCargoQuotationSystem.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet() { }

        public IActionResult OnPost()
        {

            HttpContext.Session.Clear();


            return RedirectToPage("/Index");
        }
    }
}
