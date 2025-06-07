using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using InterportCargoQuotationSystem.Data;
using InterportCargoQuotationSystem.Models;

namespace InterportCargoQuotationSystem.Pages
{
    /// <summary>
    /// Handles customer registration logic.
    /// </summary>
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterModel"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Customer model bound to the registration form.
        /// </summary>
        [BindProperty]
        public Customer Customer { get; set; } = new();

        /// <summary>
        /// Password entered by the user.
        /// </summary>
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        /// <summary>
        /// Status message after registration.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Handles POST requests to register a new customer.
        /// </summary>
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

            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Computes the SHA-256 hash for a given string.
        /// </summary>
        /// <param name="rawData">Input string.</param>
        /// <returns>SHA-256 hash string.</returns>
        private string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
