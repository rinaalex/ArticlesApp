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

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> All()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
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
