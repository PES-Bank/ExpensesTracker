using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Services
{
    public interface IService<TEntity>
        where TEntity : class
    {
        
        TEntity? GetById(Guid id);
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Guid id);
    }
}
