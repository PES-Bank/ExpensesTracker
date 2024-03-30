using ExpensesTracker.Core.Projections.Expenses;
using ExpensesTracker.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services.Expenses
{
    public interface IExpenseService : IService<Expense>
    {
        IEnumerable<ExpenseGeneralInfoProjection> GetAllExpenses();
        ExpenseGeneralInfoProjection? GetOne(Guid id);
    }
}
