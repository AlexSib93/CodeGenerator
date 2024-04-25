using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGenRepository<T>
    {
        bool IsRemovable { get; }
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null);
        List<T> GetAll(Expression<Func<T, bool>> where = null);
        List<T> GetAll(params Expression<Func<T, Object>>[] includes);
        List<T> GetAllAsNoTracking(params Expression<Func<T, Object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes);
        IQueryable<T> Set();
		TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> selector);
		IQueryable<T> SetAsNoTracking();
        int Create(T item);
        int Create(IEnumerable<T> entities);
        int GenId();
        T Create();
        void Detach(T o);
        int Delete(T item);
        int Delete(IEnumerable<T> items);
        int DeleteMark(T item);
        int DeleteMark(IEnumerable<T> items);
        int Update(T item);
        Task<int> UpdateAsync(T item);
        int Update(IEnumerable<T> items);
        List<T> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes);
        int CreateOrUpdate(T item, Expression<Func<T, bool>> where);
        int Count();
        int Max(Func<T, int> selector);
    }
}
