using ExpensesTracker.Web.ViewModels.Expenses;
using ExpensesTracker.Web.ViewModels.Workers;
using AutoMapper;
using ExpensesTracker.Core.Projections.Workers;

namespace ExpensesTracker.Web.Mapping
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            this.CreateMap<WorkerGeneralInfoProjection, WorkerViewModel>();
        }
    }
}
