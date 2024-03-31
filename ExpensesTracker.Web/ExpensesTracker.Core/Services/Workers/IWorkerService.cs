using ExpensesTracker.Core.Projections.Workers;
using ExpensesTracker.Data.Entities;
using ExpensesTracker.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services.Workers
{
    public interface IWorkerService : IService<Worker>
    {
        IEnumerable<WorkerGeneralInfoProjection> GetAllWorkers();
        WorkerGeneralInfoProjection? GetById(Guid Id);
    }
}
