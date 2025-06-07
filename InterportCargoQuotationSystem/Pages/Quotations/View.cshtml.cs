using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class ViewModel : PageModel
    {
        private readonly AppDbContext _context;

        public Quotation? Quotation { get; set; }

        public string? Message { get; set; }
        public bool IsLoggedIn => HttpContext.Session.GetString("IsLoggedIn") == "true";

        public ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            if (!IsLoggedIn)
                return RedirectToPage("/Login");

            Quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);
            if (Quotation == null)
                return NotFound();

            return Page();
        }
    }
}
