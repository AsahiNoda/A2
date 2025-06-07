using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public bool IsLoggedIn => HttpContext.Session.GetString("IsLoggedIn") == "true";

        public async Task OnGetAsync()
        {
            Quotations = await _context.Quotations.ToListAsync();
        }
    }
}
