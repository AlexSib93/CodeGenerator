using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using DataAccessLayer.Dto;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public interface IGenUoW : IDisposable
    {
        IGenRepository<people> RepPeople { get; }
        IGenRepository<peoplegroup> RepPeopleGroup { get; }
        IGenRepository<peoplegrouplist> RepPeopleGroupList { get; }
        IGenRepository<docoper> RepDocoper { get; }
        IGenRepository<good> RepGood { get; }
        IGenRepository<goodparam> RepGoodparam { get; }
        IGenRepository<manufactdoc> RepManufactdoc { get; }
        IGenRepository<manufactdocpos> RepManufactdocpos { get; }
        IGenRepository<modelcalc> RepModelcalc { get; }
        IGenRepository<orderitem> RepOrderItem { get; }
        IGenRepository<optimdoc> RepOptimdoc { get; }
        IGenRepository<optimdocpic> RepOptimdocpic { get; }
        //IGenRepository<manufactdocpossign> RepManufactdocpossign { get; }
        IGenRepository<sign> RepSign { get; }
        IGenRepository<signgroup> RepSignGroup { get; }
        IGenRepository<manufactdocsign> RepManufactdocsign { get; }
        IGenRepository<ordersign> RepOrdersign { get; }
        IGenRepository<signvalue> RepSignValue { get; }
        IGenRepository<goodoptim> RepGoodoptim { get; }
        IGenRepository<docrelation> RepDocrelation { get; }
        IGenRepository<goodbuffer> RepGoodbuffer { get; }
        IGenRepository<optimdocgoodin> RepOptimdocgoodin { get; }
        IGenRepository<storedepart> RepStoredepart { get; }
        IGenRepository<optimdocgoodout> RepOptimdocgoodout { get; }
        IGenRepository<customer> RepCustomer { get; }
        IGenRepository<orderdiraction> RepOrderdiraction { get; }
        IGenRepository<report> RepReport { get; }
        IGenRepository<docwork> RepDocwork { get; }
        IGenRepository<orders> RepOrder { get; }
        IGenRepository<work> RepWork { get; }
        IGenRepository<wdlog> RepWdlog { get; }
        IGenRepository<productiontype> RepProductiontype { get; }
        IGenRepository<productiontypesetting> RepProductiontypesetting { get; }
        IGenRepository<finparamcalc> RepFinparamcalc { get; }
        IGenRepository<workoper> RepWorkoper { get; }
        IGenRepository<storedoc> RepStoredoc { get; }
        IGenRepository<storagespace> RepStoragespace { get; }
        IGenRepository<storedocsign> RepStoredocsign { get; }
        IGenRepository<goodgroup> RepGoodgroup { get; }
        IGenRepository<color> RepColor { get; }
        IGenRepository<colorgroupcustom> RepColorgroupcustom { get; }
        IGenRepository<colorgroupprice> RepColorgroupprice { get; }
        IGenRepository<delivdoc> RepDelivDoc{ get; }
        IGenRepository<colorgrouppriceitem> RepColorgrouppriceitem { get; }
        IGenRepository<goodcolorparam> RepGoodcolorparam { get; }
        IGenRepository<supplydoc> RepSupplydoc { get; }
        IGenRepository<supplydocsign> RepSupplydocsign { get; }
        IGenRepository<goodmeasure> RepGoodmeasure { get; }
        IGenRepository<measure> RepMeasure { get; }
        IGenRepository<rotoxhouse> RepRotoxHouse { get; }
        IGenRepository<delivdocpos> RepDelivDocPos { get; }

        WdContext GetDbContext();
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
