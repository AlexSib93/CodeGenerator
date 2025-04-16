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
	List<T> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes);    
	T Get(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes);            
        T GetById(int id);
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        int Update(T entity);
        int Delete(T entity);
    }
}
