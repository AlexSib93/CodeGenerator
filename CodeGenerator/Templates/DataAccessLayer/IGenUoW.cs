using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public interface IGenUoW : IDisposable
    {
        TemplateContext GetDbContext();
        List<T> SqlQuery<T>(string query, params DbParameter[] prms) where T : class, new();
        Task<List<T>> SqlQueryAsync<T>(string query, params DbParameter[] prms) where T : class, new();
        void ExecuteNonQuerySqlCommand(string query, params DbParameter[] prms);
        DataSet ExecuteStoredProcedure(string storedProcedureName, params DbParameter[] parameters);
        IGenRepository<T> GetRep<T>() where T : class;

        void BeginTrans();
        void CommitTrans();
        void RollbackTrans();
    }
}
