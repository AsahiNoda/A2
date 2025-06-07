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

        public bool IsLoggedIn { get; set; }
        public void OnGet()
        {
            IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";
        }
        public IActionResult OnGet(int id)

        {
            Quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);
            return Quotation == null ? NotFound() : Page();
        }

        public IActionResult OnPost(string decision)
        {
            var existing = _context.Quotations.FirstOrDefault(q => q.Id == Quotation.Id);
            if (existing == null) return NotFound();

            if (decision == "Accept")
            {
                existing.Status = "Accepted";
            }
            else if (decision == "Reject")
            {
                existing.Status = "Rejected";
            }

            // フィードバック内容を保存
            existing.CustomerFeedback = Quotation.CustomerFeedback;

            _context.SaveChanges();
            Message = "Your decision and message have been recorded.";
            Quotation = existing;
            return Page();
        }

    }
}
