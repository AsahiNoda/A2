using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quotation? Quotation { get; set; }

        public IActionResult OnGet(int id)
        {
            Quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);
            return Quotation == null ? NotFound() : Page();
        }

        public IActionResult OnPost()
        {
            var quotation = _context.Quotations.FirstOrDefault(q => q.Id == Quotation.Id);
            if (quotation == null) return NotFound();

            _context.Quotations.Remove(quotation);
            _context.SaveChanges();

            return RedirectToPage("/Quotations/Index");
        }
    }
}
