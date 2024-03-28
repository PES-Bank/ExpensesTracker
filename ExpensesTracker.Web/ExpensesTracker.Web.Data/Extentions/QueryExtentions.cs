using ExpensesTracker.Data.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Data.Extentions
{
    public static class QueryExtentions
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query,
            IEnumerable<IOrderClause<TEntity>> orderClauses)
        {
            IOrderedQueryable<TEntity>? orderedQuery = null;
            foreach (var clause in orderClauses)
            {
                if (clause.IsAscending)
                {
                    if (orderedQuery is null) 
                        query = query.OrderBy(clause.Expression);
                    else 
                        orderedQuery = orderedQuery.ThenBy(clause.Expression);
                    
                }
                else
                {
                    if (orderedQuery is null)
                        orderedQuery = query.OrderByDescending(clause.Expression);
                    else orderedQuery = orderedQuery.ThenByDescending(clause.Expression);
                }
            }
            return orderedQuery ?? query;
        }
    }
}
