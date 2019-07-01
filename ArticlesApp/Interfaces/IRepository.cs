using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace ArticlesApp.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
