using MCComputerSolutionsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MCComputerSolutionsAPI.DbConnection
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceItem> InvoicesItems { get; set; }
    }
}
