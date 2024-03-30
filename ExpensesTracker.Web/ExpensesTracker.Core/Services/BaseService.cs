using ExpensesTracker.Data.Repositories;
using ExpensesTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services
{

    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class, IIdentifiable
	{
        
        protected BaseService(IRepository<TEntity> repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        protected IRepository<TEntity> Repository { get; }
        public bool Create(TEntity entity)
        {
            if(!this.IsValid(entity)) return false;

            this.Repository.Create(entity);
            return true;
        }
        public bool Delete(Guid id)
        {
            var entity = this.Repository.Get(x => x.Id == id);
            if (entity == null) return false;

            this.Repository.Delete(entity);
            return true;
        }

        protected virtual bool IsValid(TEntity entity) => true;
    }
}
