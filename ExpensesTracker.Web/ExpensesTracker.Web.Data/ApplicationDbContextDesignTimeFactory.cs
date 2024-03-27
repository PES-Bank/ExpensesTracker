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
            if (args.Length != 1) throw new InvalidOperationException
            ("You need to pass the connection string to use the only argument!");
            string connectionString = args[0];

            
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
