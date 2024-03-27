using ExpensesTracker.Core.Projections.Expenses;
using ExpensesTracker.Data.Repositories;
using ExpensesTracker.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services.Expenses
{
    public class ExpenseService : BaseService<Expense>, IExpenseService
    {
        public ExpenseService(IRepository<Expense> repository) 
            : base(repository)
        {
        }

        public IEnumerable<ExpenseGeneralInfoProjection> GetAllExpenses()
        {
            return this.Repository.GetMany(_ => true, e => new ExpenseGeneralInfoProjection
            {
                ExpenseId = e.ExpenseId,
                ExpenseName = e.ExpenseName,
                ExpenseDescription = e.ExpenseDescription,
                ExpenseType = e.ExpenseType,
                ExpenseAmount = e.ExpenseAmount
            });
        }
    }
}
