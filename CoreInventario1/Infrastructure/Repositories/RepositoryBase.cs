using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext db;

        public RepositoryBase(ApplicationDbContext context) =>
            db = context;

        public virtual async Task Add(TEntity obj)
        {
            db.Add(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await db.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(int? id) =>
            await db.Set<TEntity>().FindAsync(id);

        public virtual async Task Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        ///// <summary>
        ///// <see cref="IRepositoryBase{TEntity}"/>
        ///// </summary>
        ///// <param name="filter"><see cref="IRepositoryBase{TEntity}"/></param>
        ///// <param name="orderByExpression"><see cref="IRepositoryBase{TEntity}"/></param>
        ///// <param name="ascending"><see cref="IRepositoryBase{TEntity}"/></param>
        ///// <returns><see cref="IRepositoryBase{TEntity}"/></returns>
        //public IEnumerable<TEntity> GetFiltered(
        //    Expression<Func<TEntity, bool>> filter,
        //    Expression<Func<TEntity, object>> orderByExpression = null,
        //    bool ascending = true)
        //{
        //    // Checking query arguments
        //    //Guard.IsNotNull(filter, "filter");

        //    //this._logger.LogDebug(string.Format(CultureInfo.InvariantCulture, "Getting filtered elements {0} with filter: {1}", typeof(TEntity).Name, filter.ToString()));

        //    var query = this.Query().Where(filter);

        //    if (orderByExpression == null)
        //    {
        //        return query.ToList();
        //    }

        //    return ascending
        //           ? query.OrderBy(orderByExpression).ToList()
        //           : query.OrderByDescending(orderByExpression).ToList();
        //}

        //protected abstract IQueryable<TEntity> Query();

        public void Dispose() =>
            db.Dispose();
    }
}
