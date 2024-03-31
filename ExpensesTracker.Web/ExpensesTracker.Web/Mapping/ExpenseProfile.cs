using AutoMapper;
using ExpensesTracker.Core.Projections.Expenses;
using ExpensesTracker.Web.ViewModels.Expenses;
using ExpensesTracker.Web.Data.Entities;

namespace ExpensesTracker.Web.Mapping
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            this.CreateMap<ExpenseGeneralInfoProjection, AddExpenseViewModel>();
            this.CreateMap<ExpenseCreateModel, Expense>();
            this.CreateMap<AddExpenseViewModel, Expense>();
            this.CreateMap<Expense, AddExpenseViewModel>();
            this.CreateMap<ExpenseEditProjection, ExpenseEditModel>();
        }
    }
}
