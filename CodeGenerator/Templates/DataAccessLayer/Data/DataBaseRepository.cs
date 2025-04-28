//using DataAccessLayer;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Data
{
    public class DataBaseRepository<T> : IRepository<T> where T : class
    {
        private DataBaseContext _db;

        public DataBaseRepository(DataBaseContext db)
        {
            _db = db;
        }

        public bool IsRemovable
        {
            get
            {
                return typeof(T).GetProperty("Deleted") != null;
            }
        }

        public int Create(T item)
        {
            if (item == null)
                throw new Exception("Пустой объект для сохранения");

            _db.Set<T>().Add(item);

            int res = _db.SaveChanges();

            return res;
        }

        public int Delete(T item)
        {
            _db.Set<T>().Remove(item);

            return _db.SaveChanges();
        }

        public int Delete(IEnumerable<T> items)
        {
            _db.Set<T>().RemoveRange(items);

            return _db.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> q = Set();
            if (where != null)
                q = q.Where(where);

            return await q.ToListAsync();
        }

        public List<T> GetAll(Expression<Func<T, bool>> where)
        {
            IQueryable<T> q = Set();
            if (where != null)
                q = q.Where(where);

            return q.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes)
        {
            IQueryable<T> q = Set();

            if (where != null)
                q = q.Where(where);

            foreach (Expression<Func<T, Object>> include in includes)
            {
                q = q.Include(include);
            }

            return q.ToList();
        }

	    public List<T> GetAll(Expression<Func<T, bool>> where = null, params string[] include)
        {
            IQueryable<T> q = Set();

            if (where != null)
                q = q.Where(where);

            foreach (string s in include)
            {
                q.Include(s).ToList(); 
            }

            return q.ToList();
        }

        public T Get(Expression<Func<T, bool>> where = null, params string[] include)
        {
            IQueryable<T> q = Set();

            if (where != null)
                q = q.Where(where);

            foreach (string s in include)
            {
                q.Include(s).ToList();
            }

            return q.FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await Set().SingleOrDefaultAsync(where);
        }

        public int GenId()
        {
            int? res = -1;

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                string tableName = typeof(T).Name;

                command.CommandText = @"
                     EXEC gen_id3 @genname, @id OUTPUT
                     SELECT @id";
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter() { ParameterName = "@genname", Value = $"gen_{tableName}" });
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = -1, Direction = System.Data.ParameterDirection.Output });

                _db.Database.OpenConnection();

                if (_db.Database.CurrentTransaction != null)
                    command.Transaction = (_db.Database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        res = (int?)reader[0];
                        if (res == null || res == -1)
                            throw new Exception(String.Format("Не удалось получить Id строки для таблицы {0}", tableName));

                        res = (int)reader[0];
                    }
                }
            }

            return (int)res;
        }

        public T Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public T Get(Expression<Func<T, bool>> where)
        {

            return Set().SingleOrDefault(where);
        }

        public T Get(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes)
        {
            IQueryable<T> q = Set();
            foreach (Expression<Func<T, Object>> include in includes)
            {
                q = q.Include(include);
            }

            return q.SingleOrDefault(where);
        }

        public List<T> GetAll(params Expression<Func<T, Object>>[] includes)
        {
            IQueryable<T> q = Set();
            foreach (Expression<Func<T, Object>> include in includes)
            {
                q = q.Include(include);
            }

            return q.ToList();
        }

        public List<T> GetAllAsNoTracking(params Expression<Func<T, Object>>[] includes)
        {
            IQueryable<T> q = Set();
            foreach (Expression<Func<T, Object>> include in includes)
            {
                q = q.Include(include);
            }

            return q.AsNoTracking().ToList();
        }

        public int Count()
        {
            IQueryable<T> q = Set();

            return q.AsNoTracking().Count();
        }

        public int Max(Func<T, int> selector)
        {
            IQueryable<T> q = Set();

            return q.AsNoTracking().Max(selector);
        }

        public IQueryable<T> Set()
        {
            IQueryable<T> q = _db.Set<T>();

            //if (IsRemovable)
            //    q = q.Where(f => ((IRemovable)f).Deleted == null);

            return q;
        }

        public int DeleteMark(T item)
        {
            (item as IRemovable).deleted = DateTime.Now;

            return Update(item);
        }

        public int DeleteMark(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                (item as IRemovable).deleted = DateTime.Now;
            }
            Update(items);

            return _db.SaveChanges();
        }

        public IQueryable<T> SetAsNoTracking()
        {
            return _db.Set<T>().AsNoTracking<T>();
        }

        public int Update(T item)
        {
            _db.Set<T>().Attach(item);
            _db.Entry(item).State = EntityState.Modified;

            return _db.SaveChanges();
        }

        public int Update(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _db.Set<T>().Attach(item);
                _db.Entry(item).State = EntityState.Modified;
            }

            return _db.SaveChanges();
        }

        public async Task<int> UpdateAsync(T item)
        {
            _db.Set<T>().Attach(item);
            _db.Entry(item).State = EntityState.Modified;

            return await _db.SaveChangesAsync();
        }

        public int CreateOrUpdate(T item, Expression<Func<T, bool>> where)
        {
            Type t = typeof(T);

            IReadOnlyList<IProperty> props = _db.Entry<T>(item).Metadata.FindPrimaryKey().Properties;
            if (props.Count() == 0)
                throw new Exception($"У таблицы {t.Name} не найден первичный ключ");

            string keyPropertyName = props[0].Name;

            T exist = Set().AsNoTracking().SingleOrDefault(where);
            if (exist != null)
            {
                t.GetProperty(keyPropertyName).SetValue(item, t.GetProperty(keyPropertyName).GetValue(exist));
                _db.Set<T>().Attach(item);
                _db.Entry(item).State = EntityState.Modified;
            }
            else
            {
               // t.GetProperty(keyPropertyName).SetValue(item, GenId());
                _db.Set<T>().Add(item);
            }

            return _db.SaveChanges();
        }

        public int Create(IEnumerable<T> items)
        {
            if (items == null)
                throw new Exception("Список объектов для сохранения is null");

            if (items.Count() == 0)
                return 0;

            _db.Set<T>().AddRange(items);

            int res = _db.SaveChanges();

            return res;
        }

        public void Detach(T o)
        {
            this._db.Entry<T>(o).State = EntityState.Detached;

        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> selector)
        {
            return Set().Where(where).Select(selector).FirstOrDefault();
        }
		
        public IEnumerable<T> GetAll()
        {
	        return Set();
        }

        public T GetById(object id, params string[] includes)
        {
            DbSet<T> set = _db.Set<T>();

            foreach (var item in includes)
            {
                set.Include(item);
            }

            T? res = _db.Set<T>().Find(id);

            return res;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new Exception("Объек для сохранения is null");

            _db.Add(entity);

            _db.SaveChanges();
        }

        public void Add(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetIds(Expression<Func<T, bool>> where, Expression<Func<T, int>> idExpression)
        {
            IQueryable<T> q = Set();

            if (where != null)
                q = q.Where(where);

            IEnumerable<int> res = q.Select(idExpression).ToArray();

            return res;
        }
    }
}
