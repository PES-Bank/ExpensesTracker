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
        bool Create(TEntity entity);
    }
}
