using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);

        Task<TEntity> GetById(int? id);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(TEntity obj);

        Task Remove(TEntity obj);

        //IEnumerable<TEntity> GetFiltered(
        //    Expression<Func<TEntity, bool>> filter,
        //    Expression<Func<TEntity, object>> orderByExpression = null,
        //    bool ascending = true);
    }
}
