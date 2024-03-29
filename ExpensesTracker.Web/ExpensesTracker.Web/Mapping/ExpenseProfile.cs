using AutoMapper;
using ExpensesTracker.Core.Projections.Expenses;
using ExpensesTracker.Web.ViewModels.Expenses;

namespace ExpensesTracker.Web.Mapping
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            this.CreateMap<ExpenseGeneralInfoProjection, AddExpenseViewModel>();
        }
    }
}
