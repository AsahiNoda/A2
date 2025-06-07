using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Models;
using InterportCargoQuotationSystem.Data;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InterportCargoQuotationSystem.Pages
{
    public class RegisterEmployeeModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterEmployeeModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }


            using var sha256 = SHA256.Create();
            var hashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
            Employee.PasswordHash = Convert.ToBase64String(hashed);

            _context.Add(Employee);
            await _context.SaveChangesAsync();

            Message = "Employee registered successfully!";
            return RedirectToPage("/Login");
        }
    }
}
