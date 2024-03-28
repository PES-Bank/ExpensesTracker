using ExpensesTracker.Data.Sorting;
using ExpensesTracker.Data.Extentions;
using ExpensesTracker.Web.Data;
using System.Linq.Expressions;
using System.Linq;

namespace ExpensesTracker.Data.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public void Create(TEntity entity)
        {
            this._applicationDbContext.Set<TEntity>().Add(entity);
            this._applicationDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this._applicationDbContext.Set<TEntity>().Remove(entity);
            this._applicationDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this._applicationDbContext.Set<TEntity>().Update(entity);
            this._applicationDbContext.SaveChanges();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            return this._applicationDbContext.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public TProjection? Get<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection)
        {
            return this._applicationDbContext.Set<TEntity>().Where(filter).Select(projection).FirstOrDefault();
        }

        public TEntity? GetComplete(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter)
        {
            return this._applicationDbContext.Set<TEntity>().Where(filter).ToList();
        }

        public IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection)
        {
            return this._applicationDbContext.Set<TEntity>().Where(filter).Select(projection).ToList();
        }

        public TEntity? GetWithNavigations(Expression<Func<TEntity, bool>> filter, IEnumerable<string> navigations)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity,
            bool>> filter, Expression<Func<TEntity, TProjection>> projection, 
            IEnumerable<IOrderClause<TEntity>> orderClauses)
        {

            return this._applicationDbContext.Set<TEntity>().Where(filter).OrderBy(orderClauses).Select(projection).ToList();
        }
    }
}
