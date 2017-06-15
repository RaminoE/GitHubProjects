using Organisation.Domain.Repository.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Organisation.Domain.EF;
using Organisation.Domain.Repository.Pattern.Infrastructure;

namespace Organisation.Domain.Repository
{
    public abstract class Repository<T> where T:class
    {
        #region Properties
        private readonly IDbSet<T> dbSet;
        private OrganisationEntities dbContext;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected OrganisationEntities DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        #endregion

        public Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T Entity)
        {
           // dbSet.Attach(Entity);
            dbContext.Entry(Entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);

        }

        public virtual void Delete(int id)
        {
           var g= dbSet.Find(id);
            dbSet.Remove(g);

        }
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where,int skip,int take)
        {
            return dbSet.Where(where).ToList().Skip(skip).Take(take);
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion
    }
}
