using FJ.Data.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity :class
    {
        IQueryable<TEntity> _EntityQuery;

        protected DbContext DbContext { get; set; }
        protected DbSet<TEntity> Entity { get; set; }

        public Repository() : this(new FrogJumpEntities())
        {

        }

        public Repository(DbContext db)
        {
            this.DbContext = db;
            this.Entity = this.DbContext.Set<TEntity>();
            _EntityQuery = this.Entity.AsQueryable();
            SetDababaseContext();
        }

        private void SetDababaseContext()
        {
            this.DbContext.Database.CommandTimeout = 180;
        }

        public TEntity Create(TEntity entity)
        {
            this.Entity.Add(entity);
            return entity;
        }

        public void Create(IEnumerable<TEntity> entities)
        {
            this.Entity.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.Entity.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            this.Entity.RemoveRange(entities);
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity,bool>> predicate)
        {
            return _EntityQuery.FirstOrDefault(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _EntityQuery;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _EntityQuery.Where(predicate);
        }
    }
}
