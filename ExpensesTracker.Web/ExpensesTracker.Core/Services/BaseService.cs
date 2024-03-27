using ExpensesTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services
{

    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class
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

        protected virtual bool IsValid(TEntity entity) => true;
    }
}
