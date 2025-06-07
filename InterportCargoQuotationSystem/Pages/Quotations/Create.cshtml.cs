using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;
using System.ComponentModel.DataAnnotations;

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

        public bool IsLoggedIn => HttpContext.Session.GetString("IsLoggedIn") == "true";

        public IActionResult OnPost()
        {
            if (!IsLoggedIn)
            {
                return RedirectToPage("/Login");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Basic quotation calculation
            Quotation.Amount = Math.Round(Quotation.BasePrice * Quotation.ContainerCount, 2);
            Quotation.DateCreated = DateTime.Now;

            _context.Quotations.Add(Quotation);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
