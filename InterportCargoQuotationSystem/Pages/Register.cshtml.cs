using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = new();

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        public string? Message { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            
            if (_context.Customers.Any(c => c.Email == Customer.Email))
            {
                ModelState.AddModelError("Customer.Email", "This email is already registered.");
                return Page();
            }

            Customer.PasswordHash = ComputeSha256Hash(Password);
            _context.Customers.Add(Customer);
            _context.SaveChanges();


            HttpContext.Session.SetString("IsLoggedIn", "true");
            HttpContext.Session.SetString("UserEmail", Customer.Email);

            Message = "Registration successful!";
            return RedirectToPage("/Index");
        }

        private string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
