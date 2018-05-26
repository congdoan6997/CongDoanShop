using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CongDoan.Data.Infacstructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties

        private CongDoanShopDbContext _dbContext;
        private readonly IDbSet<T> _dbSet;
        protected IDbFactory DbFactory { get; private set; }
        protected CongDoanShopDbContext DbContext => this._dbContext ?? (_dbContext = DbFactory.Init());

        #endregion Properties

        public RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this._dbSet = DbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return this._dbSet.Add(entity);
        }

        public virtual bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Count(predicate) > 0;
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return this._dbSet.Count(where);
        }

        public virtual T Delete(T entity)
        {
            return this._dbSet.Remove(entity);
        }

        public virtual T Delete(int id)
        {
            var entity = _dbSet.Find(id);
            return this._dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> expression)
        {
            var objects = _dbSet.Where(expression).AsEnumerable();
            foreach (var item in objects)
            {
                _dbSet.Remove(item);
            }
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsEnumerable();
            }
            return _dbSet.AsEnumerable();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string[] includes = null)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.Where(predicate).AsEnumerable(); ;
            }
            return _dbSet.Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IEnumerable<T> _resetSet;
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                _resetSet = filter != null ? query.Where(filter).AsEnumerable() : query.AsEnumerable();
            }
            else
            {
                _resetSet = filter != null ? _dbSet.Where(filter).AsEnumerable() : _dbSet.AsEnumerable();
            }
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsEnumerable();
        }

        public virtual T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.FirstOrDefault(expression);
            }
            return _dbSet.FirstOrDefault(expression);
        }

        public virtual T GetSingleById(int id)
        {
            return this._dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}