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
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);

    }
}
