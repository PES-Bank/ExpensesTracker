using ExpensesTracker.Core.Projections.Workers;
using ExpensesTracker.Core.Services.Expenses;
using ExpensesTracker.Data.Entities;
using ExpensesTracker.Data.Repositories;
using ExpensesTracker.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services.Workers
{
    public class WorkerService : BaseService<Worker>, IWorkerService
    {
        public WorkerService(IRepository<Worker> repository)
            : base(repository)
        {
        }

        public bool Create(Worker entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkerGeneralInfoProjection> GetAllWorkers()
        {
            return this.Repository.GetMany(_ => true, w => new WorkerGeneralInfoProjection
            {
                Id = w.Id,
                Name = w.Name,
                LastName = w.LastName,
                PesonalIndentificationNumber = w.PesonalIndentificationNumber,
                DateOfBirth = w.DateOfBirth,
                Position = w.Position,
                PhoneNumber = w.PhoneNumber,
            });
        }

        public WorkerGeneralInfoProjection? GetById(Guid id)
        {
            return this.Repository.Get(
                w => w.Id == id, w => new WorkerGeneralInfoProjection
                {
                    Id = w.Id,
                    Name = w.Name,
                    LastName = w.LastName,
                    PesonalIndentificationNumber = w.PesonalIndentificationNumber,
                    DateOfBirth = w.DateOfBirth,
                    Position = w.Position,
                    PhoneNumber = w.PhoneNumber

                });
        }
    }
}
