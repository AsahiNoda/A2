using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace InterportCargoQuotationSystem.Pages
{
    public class RateScheduleModel : PageModel
    {
        public List<RateItem> RateList { get; set; } = new();

        public void OnGet()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Rate Schedule Extract.xlsx");
            if (!System.IO.File.Exists(path)) return;

            using var package = new ExcelPackage(new FileInfo(path));
            var worksheet = package.Workbook.Worksheets[0];

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var type = worksheet.Cells[row, 1].Text;
                if (string.IsNullOrWhiteSpace(type)) continue;

                var rateItem = new RateItem
                {
                    Type = type,
                    Container20 = worksheet.Cells[row, 2].Text,
                    Container40 = worksheet.Cells[row, 3].Text
                };
                RateList.Add(rateItem);
            }
        }

        public class RateItem
        {
            public string Type { get; set; }
            public string Container20 { get; set; }
            public string Container40 { get; set; }
        }
    }
}
