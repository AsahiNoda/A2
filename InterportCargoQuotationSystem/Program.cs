using InterportCargoQuotationSystem.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml; // Add this using directive for EPPlus

namespace InterportCargoQuotationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession(); // Add this

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();

            app.Run();
        }
    }
}
