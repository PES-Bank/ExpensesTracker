using ExpensesTracker.Core.Projections.Expenses;
using ExpensesTracker.Data.Repositories;
using ExpensesTracker.Data.Sorting;
using ExpensesTracker.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                Id = e.Id,
                ExpenseName = e.ExpenseName,
                ExpenseDescription = e.ExpenseDescription,
                ExpenseType = e.ExpenseType,
                ExpenseAmount = e.ExpenseAmount
                
            }, new[] { amounOrderClause });
            

        }

        public ExpenseGeneralInfoProjection? GetById(Guid id)
        {
            return this.Repository.Get(
                e => e.Id == id,
                e => new ExpenseGeneralInfoProjection { Id = e.Id, ExpenseName = e.ExpenseName, ExpenseDescription=e.ExpenseDescription, ExpenseAmount=e.ExpenseAmount,ExpenseType=e.ExpenseType });
                
        }

        public ExpenseGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(e => e.Id == id, this.GetGeneralInfoProjection());
        }

        public ExpenseEditProjection? GetOneEdit(Guid id)
        {
            return this.Repository.Get(e => e.Id == id,
                e => new ExpenseEditProjection
                {
                    Id = e.Id,
                    ExpenseName = e.ExpenseName,
                    ExpenseDescription = e.ExpenseDescription,
                    ExpenseType = e.ExpenseType,
                    ExpenseAmount = e.ExpenseAmount
                });
        }
        private Expression<Func<Expense, ExpenseGeneralInfoProjection>> GetGeneralInfoProjection()
        {
            return e => new ExpenseGeneralInfoProjection
            {
                Id = e.Id,
                ExpenseName = e.ExpenseName,
                ExpenseDescription = e.ExpenseDescription,
                ExpenseType = e.ExpenseType,
                ExpenseAmount = e.ExpenseAmount,
            };
        }
    }
}
