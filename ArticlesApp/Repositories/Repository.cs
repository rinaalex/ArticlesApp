using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ArticlesApp.Interfaces;

namespace ArticlesApp.Repositories
{
    public class Repository <TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        private DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            this.context = context;
            _entities = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")        
        {
            IQueryable<TEntity> query = _entities;

            if(filter!=null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query.Include(includeProperty).Load();
            }

            if(orderBy!=null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void Delete(int id)
        {
            _entities.Remove(_entities.Find(id));
        }
    }
}
