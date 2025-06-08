using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InterportCargoQuotationSystem.Models;
using OfficeOpenXml;
using System.IO;

namespace InterportCargoQuotationSystem.Pages.Rates
{
    public class IndexModel : PageModel
    {
        public List<RateEntry> Rates { get; set; } = new();

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("EmployeeType");
            if (HttpContext.Session.GetString("UserType") != "Employee" || role != "Quotation officer")
                return RedirectToPage("/AccessDenied");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RateSchedule.xlsx");
            if (!System.IO.File.Exists(path))
                return NotFound("Rate schedule not found.");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(new FileInfo(path));
            var worksheet = package.Workbook.Worksheets[0];

            for (int row = 2; worksheet.Cells[row, 1].Value != null; row++)
            {
                Rates.Add(new RateEntry
                {
                    Origin = worksheet.Cells[row, 1].Text,
                    Destination = worksheet.Cells[row, 2].Text,
                    ContainerType = worksheet.Cells[row, 3].Text,
                    Price = decimal.Parse(worksheet.Cells[row, 4].Text)
                });
            }

            return Page();
        }
    }
}
