using ExpensesTracker.Core.Projections.Expenses;
using ExpensesTracker.Data.Repositories;
using ExpensesTracker.Data.Sorting;
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
            var amounOrderClause = new OrderClause<Expense> { Expression = e => e.ExpenseAmount };
            return this.Repository.GetMany(_ => true, e => new ExpenseGeneralInfoProjection
            {
                ExpenseId = e.ExpenseId,
                ExpenseName = e.ExpenseName,
                ExpenseDescription = e.ExpenseDescription,
                ExpenseType = e.ExpenseType,
                ExpenseAmount = e.ExpenseAmount
                
            }, new[] { amounOrderClause });
            

        }

        public ExpenseGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                e => e.ExpenseId == id,
                e => new ExpenseGeneralInfoProjection { ExpenseId = e.ExpenseId, ExpenseName = e.ExpenseName, ExpenseDescription=e.ExpenseDescription, ExpenseAmount=e.ExpenseAmount,ExpenseType=e.ExpenseType });
                
        }
    }
}
