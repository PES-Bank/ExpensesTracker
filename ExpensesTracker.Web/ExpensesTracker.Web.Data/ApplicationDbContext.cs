using Microsoft.EntityFrameworkCore;
using ExpensesTracker.Web.Data.Entities;
using ExpensesTracker.Data.Entities;
namespace ExpensesTracker.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
