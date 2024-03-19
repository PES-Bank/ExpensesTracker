using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Data
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
    }
}
