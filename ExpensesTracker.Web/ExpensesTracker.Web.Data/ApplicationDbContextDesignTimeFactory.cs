using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ExpensesTracker.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ExpensesTracker.Web.Data
{
    public class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Retrieve the connection string from the command-line arguments
            var connectionString = "Server=localhost;Database=ExpensesTracker;Uid=root;Pwd=root;" 
                ?? throw new ArgumentException("Connection string is required.");

            // Setup DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
