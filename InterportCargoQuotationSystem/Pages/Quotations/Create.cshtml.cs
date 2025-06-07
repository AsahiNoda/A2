using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Models;
using InterportCargoQuotationSystem.Data;

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

        public bool IsLoggedIn { get; set; }

        public void OnGet()
        {
            IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";
        }

        public IActionResult OnPost()
        {
            IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";

            if (!IsLoggedIn)
            {
                ModelState.AddModelError(string.Empty, "You must be logged in to submit quotations.");
                return Page();
            }


            if (!ModelState.IsValid)
                return Page();


            if (Quotation.ContainerCount >= 5)
            {
                Quotation.DiscountApplied = 0.1m * Quotation.BasePrice;
            }
            else if (Quotation.RequiresQuarantine || Quotation.RequiresFumigation)
            {
                Quotation.DiscountApplied = 0.05m * Quotation.BasePrice;
            }
            else
            {
                Quotation.DiscountApplied = 0m;
            }

            Quotation.Status = "Pending";
            Quotation.DateIssued = DateTime.Now;

            _context.Quotations.Add(Quotation);
            _context.SaveChanges();

            return RedirectToPage("/Quotations/View", new { id = Quotation.Id });
        }
    }
}
