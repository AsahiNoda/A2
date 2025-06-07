using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    /// <summary>
    /// Handles deletion of quotations.
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Quotation to be deleted.
        /// </summary>
        public Quotation? Quotation { get; set; }

        /// <summary>
        /// Handles GET request to confirm delete.
        /// </summary>
        /// <param name="id">Quotation ID</param>
        public IActionResult OnGet(int id)
        {
            Quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);

            if (Quotation == null)
            {
                return RedirectToPage("/Quotations/Index");
            }

            return Page();
        }

        /// <summary>
        /// Handles POST request to delete the quotation.
        /// </summary>
        public IActionResult OnPost(int id)
        {
            var quotation = _context.Quotations.FirstOrDefault(q => q.Id == id);

            if (quotation != null)
            {
                _context.Quotations.Remove(quotation);
                _context.SaveChanges();
            }

            return RedirectToPage("/Quotations/Index");
        }
    }
}
