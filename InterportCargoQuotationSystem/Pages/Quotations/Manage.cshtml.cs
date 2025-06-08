using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class ManageModel : PageModel
    {
        private readonly AppDbContext _context;

        public ManageModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Quotation> Quotations { get; set; } = new();

        public IActionResult OnGet()
        {
            var userType = HttpContext.Session.GetString("UserType");
            var role = HttpContext.Session.GetString("EmployeeType");

            if (userType != "Employee" || !string.Equals(role, "Quotation officer", StringComparison.OrdinalIgnoreCase))
                return RedirectToPage("/AccessDenied");

            Quotations = _context.Quotations
                .OrderByDescending(q => q.DateIssued)
                .ToList();

            return Page();
        }

    }
}
