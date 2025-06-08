using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class ViewModel : PageModel
    {
        private readonly AppDbContext _context;

        public ViewModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quotation? Quotation { get; set; }

        public string? Message { get; set; }

        public string? ReturnPage { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return RedirectToPage("/Quotations/Manage");

            Quotation = _context.Quotations.FirstOrDefault(q => q.Id == id.Value);
            if (Quotation == null)
                return NotFound();

            SetReturnPage();
            return Page();
        }

        public IActionResult OnPost(string decision)
        {
            var existing = _context.Quotations.FirstOrDefault(q => q.Id == Quotation.Id);
            if (existing == null) return NotFound();

            if (decision == "Accept")
                existing.Status = "Accepted";
            else if (decision == "Reject")
                existing.Status = "Rejected";

            existing.CustomerFeedback = Quotation.CustomerFeedback;
            _context.SaveChanges();

            TempData["Message"] = $"Quotation #{existing.Id} has been {existing.Status.ToLower()}.";

            return RedirectToPage("/Quotations/MyQuotations");
        }

        private void SetReturnPage()
        {
            var userType = HttpContext.Session.GetString("UserType");
            ReturnPage = userType == "Customer"
                ? "/Quotations/MyQuotations"
                : "/Quotations/Manage";
        }
    }
}
