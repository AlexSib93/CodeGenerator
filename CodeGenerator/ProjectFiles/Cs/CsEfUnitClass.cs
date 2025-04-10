using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class CsEfUnitClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public CsEfUnitClass(List<ModelMetadata> models)
        {
            Models = models;
        }

        public ModelMetadata ClassInfo { get; set; }
        public List<ModelMetadata> Models { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace DataAccessLayer.Data
{{
    public class EfUnit : IUnitOfWork, IDisposable
    {{
        private bool _disposed = false;

        private DataBaseContext _db;
        private IDbContextTransaction _trans;

{GetModelsText(Models)}


        public EfUnit(DataBaseContext db)
        {{
            _db = db;
        }}

        public EfUnit(string connectionString)
        {{
            _db = new DataBaseContext(connectionString);
        }}

        public virtual void Dispose(bool disposing)
        {{
            if (!_disposed)
            {{
                if (disposing)
                {{
                    _db.Dispose();
                }}
                _disposed = true;
            }}
        }}

        public void Dispose()
        {{
            Dispose(true);
            GC.SuppressFinalize(this);
        }}

        public DataBaseContext GetDbContext()
        {{
            return _db;
        }}

        public List<T> SqlQuery<T>(string query) where T : class, new()
        {{
            return SqlQuery<T>(query, null);
        }}

        public List<T> SqlQuery<T>(string query, params DbParameter[] prms) where T : class, new()
        {{
            DataBaseContext db = GetDbContext();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {{
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                if (prms != null)
                {{
                    foreach (var param in prms)
                    {{
                        command.Parameters.Add(param);
                    }}
                }}

                db.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {{
                    var lst = new List<T>();
                    var lstColumns = new T().GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
                    while (reader.Read())
                    {{
                        var newObject = new T();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {{
                            var name = reader.GetName(i);
                            PropertyInfo prop = lstColumns.FirstOrDefault(a => a.Name.ToLower().Equals(name.ToLower()));
                            if (prop == null)
                            {{
                                continue;
                            }}
                            var val = reader.IsDBNull(i) ? null : reader[i];
                            prop.SetValue(newObject, val, null);
                        }}
                        lst.Add(newObject);
                    }}

                    return lst;
                }}
            }}
        }}

        public async Task<List<T>> SqlQueryAsync<T>(string query, params DbParameter[] prms) where T : class, new()
        {{
            DataBaseContext db = GetDbContext();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {{
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                if (prms != null)
                {{
                    foreach (var param in prms)
                    {{
                        command.Parameters.Add(param);
                    }}
                }}

                db.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {{
                    var lst = new List<T>();
                    var lstColumns = new T().GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
                    while (await reader.ReadAsync())
                    {{
                        var newObject = new T();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {{
                            var name = reader.GetName(i);
                            PropertyInfo prop = lstColumns.FirstOrDefault(a => a.Name.ToLower().Equals(name.ToLower()));
                            if (prop == null)
                            {{
                                continue;
                            }}
                            var val = reader.IsDBNull(i) ? null : reader[i];
                            prop.SetValue(newObject, val, null);
                        }}
                        lst.Add(newObject);
                    }}

                    return lst;
                }}
            }}
        }}

        public void BeginTrans()
        {{
            _trans = _db.Database.BeginTransaction();
        }}

        public void CommitTrans()
        {{
            if (_trans != null)
                _trans.Commit();
            _trans = null;
        }}

        public void RollbackTrans()
        {{
            if (_trans != null)
                _trans.Rollback();
            _trans = null;
        }}

        private Dictionary<Type, object> repositoryDictionary = new Dictionary<Type, object>();

        private void PutInDictionary<T>(IRepository<T> rep)
        {{
            if (!repositoryDictionary.ContainsKey(typeof(T)))
            {{
                repositoryDictionary.Add(typeof(T), rep);
            }}
        }}

        public IRepository<T> GetRep<T>() where T : class
        {{
            Type type = typeof(T);

            if (this.repositoryDictionary.ContainsKey(type))
            {{
                IRepository<T> res = (IRepository<T>)repositoryDictionary[type];

                return res;
            }}


            var res2 = new DataBaseRepository<T>(_db);

            PutInDictionary<T>(res2);

            return res2;
        }}

        public void ExecuteNonQuerySqlCommand(string query, params DbParameter[] prms)
        {{
            DataBaseContext db = GetDbContext();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {{
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                if (prms != null)
                {{
                    foreach (var param in prms)
                    {{
                        command.Parameters.Add(param);
                    }}
                }}

                db.Database.OpenConnection();
                command.ExecuteNonQuery();
            }}
        }}

        public DataSet ExecuteStoredProcedure(string storedProcedureName, params DbParameter[] parameters)
        {{
            var res = new DataSet();

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {{
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                _db.Database.OpenConnection();

                if (_db.Database.CurrentTransaction != null)
                    command.Transaction = (_db.Database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;

                using (DbDataReader reader = command.ExecuteReader())
                {{
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    res.Tables.Add(dt);
                }}
            }}

            return res;
        }}

        public DataSet ExecuteSqlCommand(string query, params DbParameter[] parameters)
        {{
            var res = new DataSet();

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {{
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(parameters);

                _db.Database.OpenConnection();

                if (_db.Database.CurrentTransaction != null)
                    command.Transaction = (_db.Database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;

                using (DbDataReader reader = command.ExecuteReader())
                {{
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    res.Tables.Add(dt);
                }}
            }}

            return res;
        }}
    }}
}}
";

        public string UsingText => $@"using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DataAccessLayer.Dto;";

        public string GetModelText(ModelMetadata classInfo)
        {
            string res = "";
            res += $@"
        private IRepository<{classInfo.Name}> _rep{classInfo.Name};
        public IRepository<{classInfo.Name}> Rep{classInfo.Name}
        {{
            get {{ return _rep{classInfo.Name} ?? (_rep{classInfo.Name} = new DataBaseRepository<{classInfo.Name}>(_db)); }}
        }}";

            return res;
        }

        public string GetModelsText(List<ModelMetadata> classesInfo)
        {
            string res = "";
            //Auth
            res += GetModelText(new ModelMetadata() { Name = "User" });

            foreach (ModelMetadata classInfo in classesInfo)
            {
                res += $"{GetModelText(classInfo)}\n";

            }

            return res;
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }

    }
}
