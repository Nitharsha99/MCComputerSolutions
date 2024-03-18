using Microsoft.EntityFrameworkCore;

namespace MCComputerSolutionsAPI.DbConnection
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
