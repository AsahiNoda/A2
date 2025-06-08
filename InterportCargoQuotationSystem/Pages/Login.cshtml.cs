using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Data;
using System.Security.Cryptography;
using System.Text;

namespace InterportCargoQuotationSystem.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string? ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please fill in all fields.";
                return Page();
            }

            string hash = ComputeSha256Hash(Password);

            // 顧客認証
            var customer = _context.Customers.FirstOrDefault(c => c.Email == Email && c.PasswordHash == hash);
            if (customer != null)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("UserType", "Customer");
                HttpContext.Session.SetString("UserEmail", customer.Email);

                // 顧客はマイ見積一覧ページへ遷移
                return RedirectToPage("/Quotations/ViewMyQuotes");
            }

            // 従業員認証
            var employee = _context.Employees.FirstOrDefault(e => e.Email == Email && e.PasswordHash == hash);
            if (employee != null)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("UserType", "Employee");
                HttpContext.Session.SetString("UserEmail", employee.Email);
                HttpContext.Session.SetString("EmployeeType", employee.EmployeeType);

                // 職種ごとにリダイレクト
                return employee.EmployeeType switch
                {
                    "Quotation officer" => RedirectToPage("/Quotations/List"),
                    "Booking officer" => RedirectToPage("/Bookings/Manage"),
                    _ => RedirectToPage("/AccessDenied") // 未定義の職種は拒否
                };
            }

            ErrorMessage = "Invalid email or password";
            return Page();
        }


        private string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Convert.ToBase64String(bytes); 
        }
    }
}
