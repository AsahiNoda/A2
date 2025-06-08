using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;
using InterportCargoQuotationSystem.Services;

namespace InterportCargoQuotationSystem.Pages.Quotations
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly DiscountService _discountService;

        public CreateModel(AppDbContext context, DiscountService discountService)
        {
            _context = context;
            _discountService = discountService;
        }

        [BindProperty]
        public Quotation Quotation { get; set; } = new();

        public string? UserEmail { get; set; }
        public bool IsLoggedIn { get; set; }

        public IActionResult OnGet()
        {
            var userType = HttpContext.Session.GetString("UserType");
            var role = HttpContext.Session.GetString("EmployeeType");

            if (userType != "Employee" || role != "Quotation Officer")
                return RedirectToPage("/AccessDenied");

            return Page();
        }

        public IActionResult OnPost()
        {
            var userType = HttpContext.Session.GetString("UserType");
            var role = HttpContext.Session.GetString("EmployeeType");

            if (userType != "Employee" || role != "Quotation Officer")
                return RedirectToPage("/AccessDenied");

            Quotation.DateIssued = DateTime.UtcNow;
            Quotation.Status = "Pending";

            Quotation.DiscountApplied = _discountService.Calculate(
                Quotation.BasePrice,
                Quotation.ContainerCount,
                Quotation.RequiresQuarantine,
                Quotation.RequiresFumigation
            );

            _context.Quotations.Add(Quotation);
            _context.SaveChanges();

            return RedirectToPage("/Quotations/Manage");
        }
    }
}
