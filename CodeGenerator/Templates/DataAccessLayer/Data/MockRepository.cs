using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class MockRepository<T> : IRepository<T>
    {
        private List<T> _entities = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            // Ваш код получения элемента по id
            //_entities.FirstOrDefault();
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            // Ваш код обновления элемента
        }

        public void Delete(int id)
        {
            // Ваш код удаления элемента по id
        }
    }
}
