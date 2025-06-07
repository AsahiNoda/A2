using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Quotation> Quotations { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        public bool IsLoggedIn { get; set; }
        public void OnGet()
        {
            IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";

            if (!IsLoggedIn) return;
            var query = _context.Quotations.AsQueryable();

            if (!string.IsNullOrEmpty(Status))
                query = query.Where(q => q.Status == Status);

            Quotations = query.OrderByDescending(q => q.DateIssued).ToList();
        }
    }
}
