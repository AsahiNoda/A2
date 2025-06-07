using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;
using System.Linq;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quotation? Quotation { get; set; }

        public bool IsLoggedIn => HttpContext.Session.GetString("IsLoggedIn") == "true";

        public IActionResult OnGet(int id)
        {
            if (!IsLoggedIn)
            {
                return RedirectToPage("/Login");
            }

            Quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);
            if (Quotation == null)
            {
                return RedirectToPage("/Quotations/Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Quotation == null)
            {
                return Page();
            }

            var existing = _context.Quotations.FirstOrDefault(q => q.Id == Quotation.Id);
            if (existing == null)
            {
                return RedirectToPage("/Quotations/Index");
            }

            existing.CustomerEmail = Quotation.CustomerEmail;
            existing.ContainerCount = Quotation.ContainerCount;
            existing.BasePrice = Quotation.BasePrice;
            existing.RequiresQuarantine = Quotation.RequiresQuarantine;
            existing.RequiresFumigation = Quotation.RequiresFumigation;

            _context.SaveChanges();
            return RedirectToPage("/Quotations/Index");
        }
    }
}
