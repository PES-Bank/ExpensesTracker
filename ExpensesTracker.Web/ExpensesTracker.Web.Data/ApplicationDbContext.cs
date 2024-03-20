using Microsoft.EntityFrameworkCore;
using ExpensesTracker.Web.Data.Entities;
namespace ExpensesTracker.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
