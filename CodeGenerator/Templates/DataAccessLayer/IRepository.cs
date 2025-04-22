using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> where = null, params string[] includes);
        T Get(Expression<Func<T, bool>> where = null, params string[] includes);
        T GetById(object id, params string[] includes);
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        int Update(T entity);
        int Delete(T entity);
    }
}
