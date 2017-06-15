using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Repository.Pattern
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T Entity);
        void Delete(T entity);
        void Delete(int id);
        T GetById(int id);
        IQueryable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where,int skip, int take);
        T Get(Expression<Func<T, bool>> where);

    }
}
