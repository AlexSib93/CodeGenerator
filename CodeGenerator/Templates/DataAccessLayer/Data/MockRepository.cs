using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccessLayer.Data
{
    public class MockRepository<T> : IRepository<T>
    {
        private List<T> _entities = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            // Ваш код удаления элемента по id
        }

        public void Add(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }
        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>> where, params string[] include)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> where, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public int Update(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
		
        public IEnumerable<int> GetIds(Expression<Func<T, bool>> where, Expression<Func<T, int>> idExpression)
        {
            throw new NotImplementedException();
        }
    }
}
