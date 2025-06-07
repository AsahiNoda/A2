using InterportCargoQuotationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InterportCargoQuotationSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
