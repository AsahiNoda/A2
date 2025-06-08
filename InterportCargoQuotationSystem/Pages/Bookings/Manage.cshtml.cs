using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Bookings
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

            if (userType != "Employee" || !string.Equals(role, "Booking officer", StringComparison.OrdinalIgnoreCase))
                return RedirectToPage("/AccessDenied");

            Quotations = _context.Quotations
                .Where(q => q.Status == "Accepted")
                .OrderByDescending(q => q.DateIssued)
                .ToList();

            return Page();
        }

        public IActionResult OnPost(int quotationId)
        {
            var quotation = _context.Quotations.FirstOrDefault(q => q.Id == quotationId);
            if (quotation != null && !quotation.Booked)
            {
                quotation.Booked = true;
                _context.SaveChanges();
                TempData["Message"] = $"Quotation #{quotation.Id} has been booked.";
            }

            return RedirectToPage();
        }

    }
}
