using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
//using DataAccessLayer;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
//using DataAccessLayer.Dto;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;
using DataAccessLayer.Dto;

namespace DataAccessLayer.Ef
{
    public class EfUnit : IGenUoW, IDisposable
    {
        private bool _disposed = false;

        private WdContext _db;
        private IDbContextTransaction _trans;

        private IGenRepository<people> _repPeople;
        public IGenRepository<people> RepPeople
        {
            get { return _repPeople ?? (_repPeople = new TerminalRepository<people>(_db)); }
        }

        private IGenRepository<peoplegroup> _repPeopleGroup;
        public IGenRepository<peoplegroup> RepPeopleGroup
        {
            get { return _repPeopleGroup ?? (_repPeopleGroup = new TerminalRepository<peoplegroup>(_db)); }
        }

        private IGenRepository<peoplegrouplist> _repPeopleGroupList;
        public IGenRepository<peoplegrouplist> RepPeopleGroupList
        {
            get { return _repPeopleGroupList ?? (_repPeopleGroupList = new TerminalRepository<peoplegrouplist>(_db)); }
        }

        private IGenRepository<docoper> _repDocOper;
        public IGenRepository<docoper> RepDocoper
        {
            get { return _repDocOper ?? (_repDocOper = new TerminalRepository<docoper>(_db)); }
        }

        private IGenRepository<good> _repGood;
        public IGenRepository<good> RepGood
        {
            get { return _repGood ?? (_repGood = new TerminalRepository<good>(_db)); }
        }

        private IGenRepository<manufactdoc> _repManufactdoc;
        public IGenRepository<manufactdoc> RepManufactdoc
        {
            get { return _repManufactdoc ?? (_repManufactdoc = new TerminalRepository<manufactdoc>(_db)); }
        }

        private IGenRepository<manufactdocpos> _repManufactdocpos;
        public IGenRepository<manufactdocpos> RepManufactdocpos
        {
            get { return _repManufactdocpos ?? (_repManufactdocpos = new TerminalRepository<manufactdocpos>(_db)); }
        }

        private IGenRepository<modelcalc> _repModelcalc;
        public IGenRepository<modelcalc> RepModelcalc
        {
            get { return _repModelcalc ?? (_repModelcalc = new TerminalRepository<modelcalc>(_db)); }
        }

        private IGenRepository<orderitem> _repOrderitem;
        public IGenRepository<orderitem> RepOrderItem
        {
            get { return _repOrderitem ?? (_repOrderitem = new TerminalRepository<orderitem>(_db)); }
        }

        private IGenRepository<optimdoc> _repOptimdoc;
        public IGenRepository<optimdoc> RepOptimdoc
        {
            get { return _repOptimdoc ?? (_repOptimdoc = new TerminalRepository<optimdoc>(_db)); }
        }

        private IGenRepository<optimdocpic> _repOptimdocpic;
        public IGenRepository<optimdocpic> RepOptimdocpic
        {
            get { return _repOptimdocpic ?? (_repOptimdocpic = new TerminalRepository<optimdocpic>(_db)); }
        }

        //private IGenRepository<manufactdocpossign> _repManufactdocPosSign;
        //public IGenRepository<manufactdocpossign> RepManufactdocpossign
        //{
        //    get { return _repManufactdocPosSign ?? (_repManufactdocPosSign = new TerminalRepository<manufactdocpossign>(_db)); }
        //}

        private IGenRepository<sign> _repSign;
        public IGenRepository<sign> RepSign
        {
            get { return _repSign ?? (_repSign = new TerminalRepository<sign>(_db)); }
        }

        private IGenRepository<signgroup> _repSignGroup;
        public IGenRepository<signgroup> RepSignGroup
        {
            get { return _repSignGroup ?? (_repSignGroup = new TerminalRepository<signgroup>(_db)); }
        }

        private IGenRepository<manufactdocsign> _repManufactdocSign;
        public IGenRepository<manufactdocsign> RepManufactdocsign
        {
            get { return _repManufactdocSign ?? (_repManufactdocSign = new TerminalRepository<manufactdocsign>(_db)); }
        }

        private IGenRepository<ordersign> _repOrderSign;
        public IGenRepository<ordersign> RepOrdersign
        {
            get { return _repOrderSign ?? (_repOrderSign = new TerminalRepository<ordersign>(_db)); }
        }

        private IGenRepository<signvalue> _repSignValue;
        public IGenRepository<signvalue> RepSignValue
        {
            get { return _repSignValue ?? (_repSignValue = new TerminalRepository<signvalue>(_db)); }
        }

        private IGenRepository<goodoptim> _repGoodoptim;
        public IGenRepository<goodoptim> RepGoodoptim
        {
            get { return _repGoodoptim ?? (_repGoodoptim = new TerminalRepository<goodoptim>(_db)); }
        }

        private IGenRepository<docrelation> _repDocrelation;
        public IGenRepository<docrelation> RepDocrelation
        {
            get { return _repDocrelation ?? (_repDocrelation = new TerminalRepository<docrelation>(_db)); }
        }

        private IGenRepository<goodbuffer> _repGoodbuffer;
        public IGenRepository<goodbuffer> RepGoodbuffer
        {
            get { return _repGoodbuffer ?? (_repGoodbuffer = new TerminalRepository<goodbuffer>(_db)); }
        }

        public IGenRepository<optimdocgoodin> _repOptimdocgoodin;
        public IGenRepository<optimdocgoodin> RepOptimdocgoodin
        {
            get { return _repOptimdocgoodin ?? (_repOptimdocgoodin = new TerminalRepository<optimdocgoodin>(_db)); }
        }

        public IGenRepository<storedepart> _repStoredepart;
        public IGenRepository<storedepart> RepStoredepart
        {
            get { return _repStoredepart ?? (_repStoredepart = new TerminalRepository<storedepart>(_db)); }
        }

        public IGenRepository<optimdocgoodout> _repOptimdocgoodout;
        public IGenRepository<optimdocgoodout> RepOptimdocgoodout
        {
            get { return _repOptimdocgoodout ?? (_repOptimdocgoodout = new TerminalRepository<optimdocgoodout>(_db)); }
        }

        public IGenRepository<customer> _repCustomer;
        public IGenRepository<customer> RepCustomer
        {
            get { return _repCustomer ?? (_repCustomer = new TerminalRepository<customer>(_db)); }
        }

        public IGenRepository<orderdiraction> _repOrderdiraction;
        public IGenRepository<orderdiraction> RepOrderdiraction
        {
            get { return _repOrderdiraction ?? (_repOrderdiraction = new TerminalRepository<orderdiraction>(_db)); }
        }

        public IGenRepository<report> _repReport;
        public IGenRepository<report> RepReport
        {
            get { return _repReport ?? (_repReport = new TerminalRepository<report>(_db)); }
        }

        public IGenRepository<docwork> _repDocwork;
        public IGenRepository<docwork> RepDocwork
        {
            get { return _repDocwork ?? (_repDocwork = new TerminalRepository<docwork>(_db)); }
        }

        public IGenRepository<orders> _repOrder;
        public IGenRepository<orders> RepOrder
        {
            get { return _repOrder ?? (_repOrder = new TerminalRepository<orders>(_db)); }
        }

        public IGenRepository<work> _repWork;
        public IGenRepository<work> RepWork
        {
            get { return _repWork ?? (_repWork = new TerminalRepository<work>(_db)); }
        }

        public IGenRepository<wdlog> _repWdlog;
        public IGenRepository<wdlog> RepWdlog
        {
            get { return _repWdlog ?? (_repWdlog = new TerminalRepository<wdlog>(_db)); }
        }

        public IGenRepository<productiontype> _repProductiontype;
        public IGenRepository<productiontype> RepProductiontype
        {
            get { return _repProductiontype ?? (_repProductiontype = new TerminalRepository<productiontype>(_db)); }
        }

        public IGenRepository<productiontypesetting> _repProductiontypesetting;
        public IGenRepository<productiontypesetting> RepProductiontypesetting
        {
            get { return _repProductiontypesetting ?? (_repProductiontypesetting = new TerminalRepository<productiontypesetting>(_db)); }
        }

        private IGenRepository<finparamcalc> _repFinparamcalc;
        public IGenRepository<finparamcalc> RepFinparamcalc
        {
            get { return _repFinparamcalc ?? (_repFinparamcalc = new TerminalRepository<finparamcalc>(_db)); }
        }

        private IGenRepository<goodparam> _repGoodparam;
        public IGenRepository<goodparam> RepGoodparam
        {
            get { return _repGoodparam ?? (_repGoodparam = new TerminalRepository<goodparam>(_db)); }
        }

        private IGenRepository<workoper> _repWorkoper;
        public IGenRepository<workoper> RepWorkoper
        {
            get { return _repWorkoper ?? (_repWorkoper = new TerminalRepository<workoper>(_db)); }
        }

        private IGenRepository<storedoc> _repStoredoc;
        public IGenRepository<storedoc> RepStoredoc
        {
            get { return _repStoredoc ?? (_repStoredoc = new TerminalRepository<storedoc>(_db)); }
        }

        private IGenRepository<storedocsign> _repStoredocsign;
        public IGenRepository<storedocsign> RepStoredocsign
        {
            get { return _repStoredocsign ?? (_repStoredocsign = new TerminalRepository<storedocsign>(_db)); }
        }

        private IGenRepository<storagespace> _repStoragespace;
        public IGenRepository<storagespace> RepStoragespace
        {
            get { return _repStoragespace ?? (_repStoragespace = new TerminalRepository<storagespace>(_db)); }
        }

        private IGenRepository<goodgroup> _repGoodgroup;
        public IGenRepository<goodgroup> RepGoodgroup
        {
            get { return _repGoodgroup ?? (_repGoodgroup = new TerminalRepository<goodgroup>(_db)); }
        }

        private IGenRepository<color> _repColor;
        public IGenRepository<color> RepColor
        {
            get { return _repColor ?? (_repColor = new TerminalRepository<color>(_db)); }
        }

        private IGenRepository<colorgroupcustom> _repColorgroupcustom;
        public IGenRepository<colorgroupcustom> RepColorgroupcustom
        {
            get { return _repColorgroupcustom ?? (_repColorgroupcustom = new TerminalRepository<colorgroupcustom>(_db)); }
        }

        private IGenRepository<colorgroupprice> _repColorgroupprice;
        public IGenRepository<colorgroupprice> RepColorgroupprice
        {
            get { return _repColorgroupprice ?? (_repColorgroupprice = new TerminalRepository<colorgroupprice>(_db)); }
        }

        private IGenRepository<colorgrouppriceitem> _repColorgrouppriceitem;
        public IGenRepository<colorgrouppriceitem> RepColorgrouppriceitem
        {
            get { return _repColorgrouppriceitem ?? (_repColorgrouppriceitem = new TerminalRepository<colorgrouppriceitem>(_db)); }
        }

        private IGenRepository<goodcolorparam> _repGoodcolorparam;
        public IGenRepository<goodcolorparam> RepGoodcolorparam
        {
            get { return _repGoodcolorparam ?? (_repGoodcolorparam = new TerminalRepository<goodcolorparam>(_db)); }
        }

        private IGenRepository<supplydoc> _repSupplydoc;
        public IGenRepository<supplydoc> RepSupplydoc
        {
            get { return _repSupplydoc ?? (_repSupplydoc = new TerminalRepository<supplydoc>(_db)); }
        }

        private IGenRepository<supplydocsign> _repSupplydocsign;
        public IGenRepository<supplydocsign> RepSupplydocsign
        {
            get { return _repSupplydocsign ?? (_repSupplydocsign = new TerminalRepository<supplydocsign>(_db)); }
        }

        private IGenRepository<delivdoc> _repDelivDoc;
        public IGenRepository<delivdoc> RepDelivDoc
        {
            get { return _repDelivDoc ?? (_repDelivDoc = new TerminalRepository<delivdoc>(_db)); }
        }

        private IGenRepository<goodmeasure> _repGoodmeasure;
        public IGenRepository<goodmeasure> RepGoodmeasure
        {
            get { return _repGoodmeasure ?? (_repGoodmeasure = new TerminalRepository<goodmeasure>(_db)); }
        }

        private IGenRepository<measure> _repMeasure;
        public IGenRepository<measure> RepMeasure
        {
            get { return _repMeasure ?? (_repMeasure = new TerminalRepository<measure>(_db)); }
        }

        private IGenRepository<rotoxhouse> _repRotoxHouse;
        public IGenRepository<rotoxhouse> RepRotoxHouse
        {
            get { return _repRotoxHouse ?? (_repRotoxHouse = new TerminalRepository<rotoxhouse>(_db)); }
        }
                
        private IGenRepository<delivdocpos> _repDelivDocPos;
        public IGenRepository<delivdocpos> RepDelivDocPos
        {
            get { return _repDelivDocPos ?? (_repDelivDocPos = new TerminalRepository<delivdocpos>(_db)); }
        }


        public EfUnit(WdContext db)
        {
            _db = db;
        }

        public EfUnit(string connectionString)
        {
            _db = new WdContext(connectionString);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public WdContext GetDbContext()
        {
            return _db;
        }

        public List<T> SqlQuery<T>(string query) where T : class, new()
        {
            return SqlQuery<T>(query, null);
        }

        public List<T> SqlQuery<T>(string query, params DbParameter[] prms) where T : class, new()
        {
            DbContext db = GetDbContext();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                if (prms != null)
                {
                    foreach (var param in prms)
                    {
                        command.Parameters.Add(param);
                    }
                }

                db.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    var lst = new List<T>();
                    var lstColumns = new T().GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
                    while (reader.Read())
                    {
                        var newObject = new T();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            PropertyInfo prop = lstColumns.FirstOrDefault(a => a.Name.ToLower().Equals(name.ToLower()));
                            if (prop == null)
                            {
                                continue;
                            }
                            var val = reader.IsDBNull(i) ? null : reader[i];
                            prop.SetValue(newObject, val, null);
                        }
                        lst.Add(newObject);
                    }

                    return lst;
                }
            }
        }

        public async Task<List<T>> SqlQueryAsync<T>(string query, params DbParameter[] prms) where T : class, new()
        {
            DbContext db = GetDbContext();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                if (prms != null)
                {
                    foreach (var param in prms)
                    {
                        command.Parameters.Add(param);
                    }
                }

                db.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var lst = new List<T>();
                    var lstColumns = new T().GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
                    while (await reader.ReadAsync())
                    {
                        var newObject = new T();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var name = reader.GetName(i);
                            PropertyInfo prop = lstColumns.FirstOrDefault(a => a.Name.ToLower().Equals(name.ToLower()));
                            if (prop == null)
                            {
                                continue;
                            }
                            var val = reader.IsDBNull(i) ? null : reader[i];
                            prop.SetValue(newObject, val, null);
                        }
                        lst.Add(newObject);
                    }

                    return lst;
                }
            }
        }

        public void BeginTrans()
        {
            _trans = _db.Database.BeginTransaction();
        }

        public void CommitTrans()
        {
            if (_trans != null)
                _trans.Commit();
            _trans = null;
        }

        public void RollbackTrans()
        {
            if (_trans != null)
                _trans.Rollback();
            _trans = null;
        }

        private Dictionary<Type, object> repositoryDictionary = new Dictionary<Type, object>();

        private void PutInDictionary<T>(IGenRepository<T> rep)
        {
            if (!repositoryDictionary.ContainsKey(typeof(T)))
            {
                repositoryDictionary.Add(typeof(T), rep);
            }
        }

        public IGenRepository<T> GetRep<T>() where T : class
        {
            Type type = typeof(T);

            if (this.repositoryDictionary.ContainsKey(type))
            {
                IGenRepository<T> res = (IGenRepository<T>)repositoryDictionary[type];

                return res;
            }


            var res2 = new TerminalRepository<T>(_db);

            PutInDictionary<T>(res2);

            return res2;
        }

        public void ExecuteNonQuerySqlCommand(string query, params DbParameter[] prms)
        {
            DbContext db = GetDbContext();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                if (prms != null)
                {
                    foreach (var param in prms)
                    {
                        command.Parameters.Add(param);
                    }
                }

                db.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public DataSet ExecuteStoredProcedure(string storedProcedureName, params DbParameter[] parameters)
        {
            var res = new DataSet();

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                _db.Database.OpenConnection();

                if (_db.Database.CurrentTransaction != null)
                    command.Transaction = (_db.Database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;

                using (DbDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    res.Tables.Add(dt);
                }
            }

            return res;
        }

        public DataSet ExecuteSqlCommand(string query, params DbParameter[] parameters)
        {
            var res = new DataSet();

            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(parameters);

                _db.Database.OpenConnection();

                if (_db.Database.CurrentTransaction != null)
                    command.Transaction = (_db.Database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;

                using (DbDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    res.Tables.Add(dt);
                }
            }

            return res;
        }
    }
}