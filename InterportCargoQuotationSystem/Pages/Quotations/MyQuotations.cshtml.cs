using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class MyQuotationsModel : PageModel
    {
        private readonly AppDbContext _context;

        public MyQuotationsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Quotation> Quotations { get; set; } = new();

        public IActionResult OnGet()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return RedirectToPage("/Login");

            Quotations = _context.Quotations
                .Where(q => q.CustomerEmail == email)
                .OrderByDescending(q => q.DateIssued)
                .ToList();

            return Page();
        }

        public IActionResult OnPost(int quotationId, string action)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            var quotation = _context.Quotations.FirstOrDefault(q => q.Id == quotationId && q.CustomerEmail == email);
            if (quotation == null || quotation.Status != "Pending")
                return RedirectToPage();

            if (action == "Accept")
                quotation.Status = "Accepted";
            else if (action == "Reject")
                quotation.Status = "Rejected";

            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
