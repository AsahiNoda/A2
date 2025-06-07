using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quotation Quotation { get; set; } = new();

        public string? UserEmail { get; set; }
        public bool IsLoggedIn { get; set; }

        public IActionResult OnGet()
        {
            UserEmail = HttpContext.Session.GetString("UserEmail");
            IsLoggedIn = !string.IsNullOrWhiteSpace(UserEmail);
            return Page();
        }

        public IActionResult OnPost()
        {
            UserEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(UserEmail))
                return RedirectToPage("/Login");

            Quotation.CustomerEmail = UserEmail;
            Quotation.DateIssued = DateTime.UtcNow;

            _context.Quotations.Add(Quotation);
            _context.SaveChanges();

            return RedirectToPage("/Quotations/Index");
        }
    }
}
