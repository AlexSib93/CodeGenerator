using System;
using System.Collections.Generic;
using System.Linq;
using BuisinessLogicLayer.Enum;
using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.Services.Domain;
using BuisinessLogicLayer.ViewModels;
using DataAccessLayer;
using DataAccessLayer.Dto;
using Microsoft.Data.SqlClient;

namespace BuisinessLogicLayer.Services
{
    public class RotoxHouseService : BaseService, IRotoxHouseService
    {
        public int IdPeople { get; set; }
        public IStorageSpaceService StorageSpaceService { get; private set; }

        public RotoxHouseService(IGenUoW unit, IStorageSpaceService storageSpaceService) : base(unit)
        {
            StorageSpaceService = storageSpaceService;
        }

        public rotoxhouse Create(rotoxhouse rotoxHouse)
        {
            rotoxHouse.idrotoxhouse = Unit.RepRotoxHouse.GenId();
            rotoxHouse.state ??= 0;
            Unit.RepRotoxHouse.Create(rotoxHouse);

            return rotoxHouse;
        }

        public List<rotoxhouse> Create(List<rotoxhouse> rotoxHouses)
        {
            foreach (rotoxhouse item in rotoxHouses)
            {
                item.idrotoxhouse = Unit.RepRotoxHouse.GenId();
                item.state ??= 0;
            }

            Unit.RepRotoxHouse.Create(rotoxHouses);

            return rotoxHouses;
        }

        public rotoxhouse Get(int id)
        {
            rotoxhouse r = Unit.RepRotoxHouse.Get(r => r.idrotoxhouse == id);

            return r;
        }

        public RotoxHouse Scan(string barcode, bool isSgp = true)
        {
            RotoxHouse res;
            string sql;

            BarcodeInfo info = BarcodeService.GetBarcodeInfo(barcode);
            if (info.Type == BarcodeTypeEnum.OptimDocPos)
            {
                sql = $@"
SELECT
     cnt.cntwithcell AS mfCntOnSgp
    ,cnt.cntall AS mfCntAll
    ,oi.idorder
    ,oi.name
    ,oi.numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,mdp.idorderitem
    ,mdp.idmanufactdoc
    ,mdp.idmanufactdocpos
    ,mdp.orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,oi.name ItemName
    ,md.name ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,oi.weight
    ,d.name AS destanationName
    ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,null as idstoredoc
    ,rh.dtout
	,isnull(md_p.name, iif(oi.idconstructiontype = 9, 'Склад СП', '') ) as parentManufactDocName
	,md_p.idmanufactdoc as parentIdManufactDoc
FROM optimdocpos odp
JOIN manufactdocpos mdp on odp.idmanufactdocpos = mdp.idmanufactdocpos
  JOIN manufactdoc md ON md.idmanufactdoc = mdp.idmanufactdoc
  JOIN orderitem oi ON mdp.idorderitem = oi.idorderitem
  outer apply (select top 1 md_p.idmanufactdoc, md_p.name from orderitem oi_p
					join manufactdocpos mdp_p on mdp_p.idorderitem = oi_p.idorderitem
					join manufactdoc md_p on md_p.idmanufactdoc = mdp_p.idmanufactdoc
				where oi_p.idorderitem = oi.parentid) md_p
  JOIN orders o
    ON o.idorder = oi.idorder
  JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder and od.idorderitem = mdp.idorderitem and od.orderitemnum = mdp.orderitemnum
  LEFT JOIN delivdocpos ddp
    ON ddp.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idmanufactdocpos = mdp.idmanufactdocpos
    {(isSgp ? "and rh.idstoredepart is null" : "and rh.idstoredepart is not null")}
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
  OUTER APPLY (SELECT COUNT(mdp2.idmanufactdocpos) AS cntall, COUNT(rh.idrotoxhouse) cntwithcell FROM manufactdocpos mdp2 
      LEFT JOIN rotoxhouse rh ON mdp2.idmanufactdocpos = rh.idmanufactdocpos
        WHERE mdp2.idmanufactdoc = md.idmanufactdoc ) AS cnt
WHERE odp.barcode = @barcode
order by rh.idrotoxhouse desc ";

                var param = new SqlParameter("@barcode", barcode);
                res = Unit.SqlQuery<RotoxHouse>(sql, param).FirstOrDefault();
            }
            else if (info.Type == BarcodeTypeEnum.StoreDoc)
            {
                sql = $@"
SELECT
     IIF(rh.idrotoxhouse IS NOT NULL, 1, 0) AS mfCntOnSgp
    ,1 AS mfCntAll
    ,o.idorder
    ,doc.name
    ,NULL numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,NULL idorderitem
    ,NULL idmanufactdoc
    ,NULL idmanufactdocpos
    ,NULL orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,doc.name ItemName
    ,null ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,NULL AS weight
    ,d.name AS destanationName
    ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,doc.idstoredoc as idstoredoc
    ,rh.dtout
	,null as parentManufactDocName
	,null as parentIdManufactDoc
FROM storedoc doc
  LEFT JOIN orders o
    ON o.idorder = doc.idorder
  LEFT JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    outer apply (select top 1 * from orderdiraction od where od.iddiraction = 3 and od.idorder = o.idorder) od
  LEFT JOIN delivdocpos ddp
    ON ddp.idstoredoc = doc.idstoredoc
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idstoredoc = doc.idstoredoc
    {(isSgp ? "and rh.idstoredepart is null" : "and rh.idstoredepart is not null")}
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
WHERE doc.idstoredoc = @idstoredoc
order by rh.idrotoxhouse DESC ";

                var par = new SqlParameter("@idstoredoc", info.Id);
                res = Unit.SqlQuery<RotoxHouse>(sql, par).FirstOrDefault();
            }
            else
            {
                sql = $@"
SELECT
     cnt.cntwithcell AS mfCntOnSgp
    ,cnt.cntall AS mfCntAll
    ,oi.idorder
    ,oi.name
    ,oi.numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,mdp.idorderitem
    ,mdp.idmanufactdoc
    ,mdp.idmanufactdocpos
    ,mdp.orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,oi.name ItemName
    ,md.name ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,oi.weight
    ,d.name AS destanationName
    ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,null as idstoredoc
    ,rh.dtout
	,isnull(md_p.name, iif(oi.idconstructiontype = 9, 'Склад СП', '') ) as parentManufactDocName
	,md_p.idmanufactdoc as parentIdManufactDoc
FROM manufactdocpos mdp
  JOIN manufactdoc md ON md.idmanufactdoc = mdp.idmanufactdoc
  JOIN orderitem oi
    ON mdp.idorderitem = oi.idorderitem
  outer apply (select top 1 md_p.idmanufactdoc, md_p.name from orderitem oi_p
					join manufactdocpos mdp_p on mdp_p.idorderitem = oi_p.idorderitem
					join manufactdoc md_p on md_p.idmanufactdoc = mdp_p.idmanufactdoc
				where oi_p.idorderitem = oi.parentid) md_p
  JOIN orders o
    ON o.idorder = oi.idorder
  JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder and od.idorderitem = mdp.idorderitem and od.orderitemnum = mdp.orderitemnum
  LEFT JOIN delivdocpos ddp
    ON ddp.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idmanufactdocpos = mdp.idmanufactdocpos
    {(isSgp ? "and rh.idstoredepart is null" : "and rh.idstoredepart is not null")}
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
  OUTER APPLY (SELECT COUNT(mdp2.idmanufactdocpos) AS cntall, COUNT(rh.idrotoxhouse) cntwithcell FROM manufactdocpos mdp2 
      LEFT JOIN rotoxhouse rh ON mdp2.idmanufactdocpos = rh.idmanufactdocpos
        WHERE mdp2.idmanufactdoc = md.idmanufactdoc ) AS cnt
WHERE mdp.barcode = @barcode
order by rh.idrotoxhouse desc ";

                var param = new SqlParameter("@barcode", barcode);
                res = Unit.SqlQuery<RotoxHouse>(sql, param).FirstOrDefault();
            }

            return res;
        }

        public List<RotoxHouse> GetByManufactDoc(int id)
        {
            string sql = $@"
SELECT
     cnt.cntwithcell AS mfCntOnSgp
     ,cnt.cntall AS mfCntAll
    ,oi.idorder
    ,oi.name
    ,oi.numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,mdp.idorderitem
    ,mdp.idmanufactdoc
    ,mdp.idmanufactdocpos
    ,mdp.orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,oi.name ItemName
    ,md.name ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,oi.weight
    ,d.name AS destanationName
    ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,null as idstoredoc
    ,rh.dtout
	,isnull(md_p.name, iif(oi.idconstructiontype = 9, 'Склад СП', '') ) as parentManufactDocName
	,md_p.idmanufactdoc as parentIdManufactDoc
FROM manufactdocpos mdp
  JOIN manufactdoc md ON md.idmanufactdoc = mdp.idmanufactdoc
  JOIN orderitem oi
    ON mdp.idorderitem = oi.idorderitem
  outer apply (select top 1 md_p.idmanufactdoc, md_p.name from orderitem oi_p
					join manufactdocpos mdp_p on mdp_p.idorderitem = oi_p.idorderitem
					join manufactdoc md_p on md_p.idmanufactdoc = mdp_p.idmanufactdoc
				where oi_p.idorderitem = oi.parentid) md_p
  JOIN orders o
    ON o.idorder = oi.idorder
  JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder and od.idorderitem = mdp.idorderitem and od.orderitemnum = mdp.orderitemnum
  LEFT JOIN delivdocpos ddp
    ON ddp.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
  OUTER APPLY (SELECT COUNT(mdp2.idmanufactdocpos) AS cntall, COUNT(rh.idrotoxhouse) cntwithcell FROM manufactdocpos mdp2 
      LEFT JOIN rotoxhouse rh ON mdp2.idmanufactdocpos = rh.idmanufactdocpos
        WHERE mdp2.idmanufactdoc = md.idmanufactdoc and rh.idstoredepart is null ) AS cnt
WHERE mdp.idmanufactdoc = @id
";
            var param = new SqlParameter("@id", id);
            var res = Unit.SqlQuery<RotoxHouse>(sql, param);

            return res;
        }

        public List<RotoxHouse> GetByDelivDoc(int id)
        {
            string sql = $@"
SELECT
     cnt.cntwithcell AS mfCntOnSgp
    ,cnt.cntall AS mfCntAll
    ,oi.idorder
    ,oi.name
    ,oi.numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,mdp.idorderitem
    ,mdp.idmanufactdoc
    ,mdp.idmanufactdocpos
    ,mdp.orderitemnum
    ,rh.IdRotoxHouse
    ,sd2.name AS storedepart
    ,ss2.row
    ,ss2.cell
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,oi.name ItemName
    ,md.name ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,oi.weight
    ,d.name AS destanationName
    ,rh.dtout
	,isnull(md_p.name, iif(oi.idconstructiontype = 9, 'Склад СП', '') ) as parentManufactDocName
	,md_p.idmanufactdoc as parentIdManufactDoc
FROM manufactdocpos mdp
    JOIN manufactdoc md ON md.idmanufactdoc = mdp.idmanufactdoc
    JOIN orderitem oi
        ON mdp.idorderitem = oi.idorderitem
    outer apply (select top 1 md_p.idmanufactdoc, md_p.name 
                from orderitem oi_p
					join manufactdocpos mdp_p on mdp_p.idorderitem = oi_p.idorderitem
					join manufactdoc md_p on md_p.idmanufactdoc = mdp_p.idmanufactdoc
				where oi_p.idorderitem = oi.parentid) md_p
    JOIN orders o
        ON o.idorder = oi.idorder
    JOIN destanation d 
        ON o.iddestanation = d.iddestanation
    LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder and od.idorderitem = mdp.idorderitem and od.orderitemnum = mdp.orderitemnum
    LEFT JOIN delivdocpos ddp
        ON ddp.idorderitem = mdp.idorderitem and ddp.orderitemnum = mdp.orderitemnum
    LEFT JOIN delivdoc dd
        ON dd.iddelivdoc = ddp.iddelivdoc
    LEFT JOIN rotoxhouse rh ON rh.idmanufactdocpos = mdp.idmanufactdocpos
    LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
    LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
    LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
    LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
    LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
    OUTER APPLY (SELECT COUNT(mdp2.idmanufactdocpos) AS cntall, COUNT(rh.idrotoxhouse) cntwithcell FROM manufactdocpos mdp2 
      LEFT JOIN rotoxhouse rh ON mdp2.idmanufactdocpos = rh.idmanufactdocpos
        WHERE mdp2.idmanufactdoc = md.idmanufactdoc and rh.idstoredepart is null ) AS cnt
WHERE dd.iddelivdoc = @id
";
            var param = new SqlParameter("@id", id);
            var res = Unit.SqlQuery<RotoxHouse>(sql, param);

            return res;
        }

        public List<RotoxHouse> GetByStorageSpace(string barcode, bool isSgp = true)
        {

            string type = barcode.Substring(0, 4);
            storagespace space = StorageSpaceService.Get(barcode);
            string sql = $@"
SELECT
     cnt.cntwithcell AS mfCntOnSgp
    ,cnt.cntall AS mfCntAll
    ,oi.idorder
    ,oi.name
    ,oi.numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,mdp.idorderitem
    ,mdp.idmanufactdoc
    ,mdp.idmanufactdocpos
    ,mdp.orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,oi.name ItemName
    ,md.name ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,oi.weight
    ,d.name AS destanationName
	  ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,null as idstoredoc
    ,rh.dtout
	,isnull(md_p.name, iif(oi.idconstructiontype = 9, 'Склад СП', '') ) as parentManufactDocName
	,md_p.idmanufactdoc as parentIdManufactDoc
FROM manufactdocpos mdp
  JOIN manufactdoc md ON md.idmanufactdoc = mdp.idmanufactdoc
  JOIN orderitem oi
    ON mdp.idorderitem = oi.idorderitem
  outer apply (select top 1 md_p.idmanufactdoc, md_p.name from orderitem oi_p
					join manufactdocpos mdp_p on mdp_p.idorderitem = oi_p.idorderitem
					join manufactdoc md_p on md_p.idmanufactdoc = mdp_p.idmanufactdoc
				where oi_p.idorderitem = oi.parentid) md_p
  JOIN orders o
    ON o.idorder = oi.idorder
  JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder and od.idorderitem = mdp.idorderitem and od.orderitemnum = mdp.orderitemnum
  LEFT JOIN delivdocpos ddp
    ON ddp.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idmanufactdocpos = mdp.idmanufactdocpos
    {(isSgp ? "and rh.idstoredepart is null" : "and rh.idstoredepart is not null")}
    and rh.dtout is null
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
  OUTER APPLY (SELECT COUNT(mdp2.idmanufactdocpos) AS cntall, COUNT(rh.idrotoxhouse) cntwithcell FROM manufactdocpos mdp2 
      LEFT JOIN rotoxhouse rh ON mdp2.idmanufactdocpos = rh.idmanufactdocpos
        WHERE mdp2.idmanufactdoc = md.idmanufactdoc ) AS cnt
WHERE rh.idstoragespace{(type == "7777" ? "2" : "")} = @idstoragespace --AND rh.state in (1,2,3) 
UNION ALL
SELECT
     IIF(rh.idrotoxhouse IS NOT NULL, 1, 0) AS mfCntOnSgp
    ,1 AS mfCntAll
    ,o.idorder
    ,doc.name
    ,NULL numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,NULL idorderitem
    ,NULL idmanufactdoc
    ,NULL idmanufactdocpos
    ,NULL orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,doc.name ItemName
    ,null ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,NULL AS weight
    ,d.name AS destanationName
    ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,doc.idstoredoc as idstoredoc
    ,rh.dtout
	,null as parentManufactDocName
	,null as parentIdManufactDoc
FROM storedoc doc
  LEFT JOIN orders o
    ON o.idorder = doc.idorder
  LEFT JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    outer apply (select top 1 * from orderdiraction od where od.iddiraction = 3 and od.idorder = o.idorder) od
  LEFT JOIN delivdocpos ddp
    ON ddp.idstoredoc = doc.idstoredoc
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idstoredoc = doc.idstoredoc
    {(isSgp ? "and rh.idstoredepart is null" : "and rh.idstoredepart is not null")}
    and rh.dtout is null
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
WHERE rh.idstoragespace{(type == "7777" ? "2" : "")} = @idstoragespace
--order by rh.idrotoxhouse DESC

";
            int idstoragespace = space?.idstoragespace ?? 0;
            var param = new SqlParameter[] { new SqlParameter("@idstoragespace", idstoragespace) };
            List<RotoxHouse> res = Unit.SqlQuery<RotoxHouse>(sql, param);

            return res;
        }

        public List<rotoxhouse> ScanCell(string barcode, List<rotoxhouse> items)
        {
            List<rotoxhouse> res = new List<rotoxhouse>();
            string type = barcode.Substring(0, 4);
            storagespace space = StorageSpaceService.Get(barcode);
            if (space != null)
            {
                res = ScanCell(items, space, type);
            }
            else
            {
                throw new Exception($"Место хранения не найдено по баркоду '{barcode}'");
            }

            return res;
        }

        private List<rotoxhouse> ScanCell(List<rotoxhouse> items, storagespace space, string type)
        {
            List<rotoxhouse> res;
            List<rotoxhouse> NotExistedItems = items.Where(r => r.idrotoxhouse == 0).ToList();
            foreach (rotoxhouse item in NotExistedItems)
            {
                // Пирамида
                if (type == "7777") 
                {
                    item.idstoragespaceNavigation = space.idparentNavigation;
                    item.idstoragespace2Navigation = space;
                    item.idpeople2 = IdPeople;
                }
                // Зона хранения
                else if (type == "0000")
                {
                    item.idstoragespaceNavigation = space;
                    item.idstoragespace2Navigation = null;
                    item.idpeople1 = IdPeople;
                }
                item.state = (int)RotoxHouseStateEnum.CellAssigned;
                item.dtin = DateTime.Now;
                item.dtout = null;
            }
            res = Create(NotExistedItems);

            List<int> existedItemsIds = items.Where(r => r.idrotoxhouse > 0).Select(r => r.idrotoxhouse).ToList();
            List<rotoxhouse> existedItems = Unit.RepRotoxHouse.Set().Where(rh => existedItemsIds.Contains(rh.idrotoxhouse)).ToList();
            foreach (rotoxhouse item in existedItems)
            {
                if (type == "7777")
                {
                    item.idstoragespace = space.idparent;
                    item.idstoragespace2 = space.idstoragespace;
                    item.idpeople2 = IdPeople;
                }
                else if (type == "0000")
                {
                    item.idstoragespace = space.idstoragespace;
                    item.idstoragespace2 = null;
                    item.idpeople1 = IdPeople;
                }
                item.state = (int)RotoxHouseStateEnum.CellAssigned;
                item.dtin = DateTime.Now;
                item.dtout = null;
            }
            Unit.RepRotoxHouse.Update(existedItems);
            res.AddRange(existedItems);

            UpdateOrderStateIfNeed(items);
            return res;
        }

        public List<rotoxhouse> ScanCellRemoteStore(string barcode, List<rotoxhouse> items)
        {
            if (barcode.Length != 11)
                throw new Exception($"Баркод '{barcode}' не распознан. \nДлина баркода должна составлять 11 символов");

            List<rotoxhouse> res = new List<rotoxhouse>();
            string type = barcode.Substring(0, 4);
            storagespace space = StorageSpaceService.Get(barcode);
            //Storagespace space = Unit.RepStoragespace.Set().ToList().FirstOrDefault();
            if (space != null)
            {
                List<rotoxhouse> NotExistedItems = items.Where(r => r.idrotoxhouse == 0).ToList();
                foreach (rotoxhouse item in NotExistedItems)
                {
                    if (type == "7777")
                    {
                        item.idstoredepart = space.idstoredepart;
                        item.idstoragespace = null;
                        item.idstoragespace2 = space.idstoragespace;
                        item.idpeople3 = IdPeople;
                    }
                    else if (type == "0000")
                    {
                        item.idstoredepart = space.idstoredepart;
                        item.idstoragespace2 = null;
                        item.idpeople3 = IdPeople;
                        item.row = space.row;
                        item.cell = space.cell;
                    }
                    item.state = (int)RotoxHouseStateEnum.CellAssigned;
                    item.dtin = DateTime.Now;
                    item.dtout = null;
                }
                res = Create(NotExistedItems);

                List<int> existedItemsIds = items.Where(r => r.idrotoxhouse > 0).Select(r => r.idrotoxhouse).ToList();
                List<rotoxhouse> existedItems = Unit.RepRotoxHouse.Set().Where(rh => existedItemsIds.Contains(rh.idrotoxhouse)).ToList();
                foreach (rotoxhouse item in existedItems)
                {
                    //if (type == "7777")
                    //{
                    //    item.idstoragespace2 = space.idstoragespace;
                    //    item.idpeople2 = IdPeople;
                    //}
                    //else 
                    if (type == "0000")
                    {
                        item.idstoragespace = space.idstoragespace;
                        item.idstoragespace2 = null;
                        item.idpeople3 = IdPeople;
                        item.row = space.row;
                        item.cell = space.cell;
                    }
                    item.state = (int)RotoxHouseStateEnum.CellAssigned;
                    item.dtin = DateTime.Now;
                    item.dtout = null;
                }
                Unit.RepRotoxHouse.Update(existedItems);

                UpdateOrderStateIfNeed(items);
            }
            else
            {
                throw new Exception($"Место хранения не найдено по баркоду '{barcode}'");
            }

            return res;
        }

        public storagespace ScanFromCellToCell(string barcodefrom, string barcode)
        {
            if (barcodefrom.Length != 11)
                throw new Exception($"Баркод '{barcodefrom}' не распознан. \nДлина баркода должна составлять 11 символов");

            if (barcode.Length != 11)
                throw new Exception($"Баркод '{barcode}' не распознан. \nДлина баркода должна составлять 11 символов");

            string type = barcode.Substring(0, 4);
            storagespace storagespaceFrom = StorageSpaceService.Get(barcodefrom);
            storagespace storagespaceTo = StorageSpaceService.Get(barcode);
            if (storagespaceTo == null)
            {
                throw new Exception($"Место не найдено по баркоду '{barcode}'");
            }
            else if (storagespaceFrom == null)
            {
                throw new Exception($"Место не найдено по баркоду '{barcodefrom}'");
            }
            else
            {
                storagespaceFrom.idparent = storagespaceTo.idstoragespace;
                Unit.RepStoragespace.Update(storagespaceFrom);

                List<rotoxhouse> rotoxHouses = GetRotoxHousesOnPyramid(storagespaceFrom);
                if (rotoxHouses.Count > 0)
                {
                    if (type == "0000")
                    {
                        foreach (rotoxhouse rh in rotoxHouses)
                        {
                            rh.idstoragespace = storagespaceTo.idstoragespace;
                            //rh.state = (int)RotoxHouseStateEnum.OnRemoteStore;
                            //rh.idstoredepart = storagespace.idstoredepart; 
                            rh.idpeople1 = IdPeople;
                        }
                    }
                    else if (type == "7777")
                    {
                        foreach (rotoxhouse rh in rotoxHouses)
                        {
                            rh.idstoragespace2 = storagespaceTo.idstoragespace;
                            rh.idstoragespace = storagespaceTo.idparent;
                            //rh.state = (int)RotoxHouseStateEnum.OnRemoteStore;
                            //rh.idstoredepart = storagespace.idstoredepart; 
                            rh.idpeople2 = IdPeople;
                        }
                    }

                    Unit.RepRotoxHouse.Update(rotoxHouses);

                    UpdateOrderStateIfNeed(rotoxHouses);
                }
            }

            return storagespaceTo;
        }

        private List<rotoxhouse> GetRotoxHousesOnPyramid(storagespace pyramid)
        {
            //int[] states = new int[] { (int)RotoxHouseStateEnum.CellAssigned, (int)RotoxHouseStateEnum.Left };
            List<rotoxhouse> rotoxHouses = Unit.RepRotoxHouse.Set().Where(rh => rh.idstoragespace2 == pyramid.idstoragespace && rh.idstoredepart != null && rh.dtout == null).ToList();

            if(!rotoxHouses.Any())
            {
                rotoxHouses = Unit.RepRotoxHouse.Set().Where(rh => rh.idstoragespace2 == pyramid.idstoragespace && rh.idstoredepart == null && rh.dtout == null).ToList();
            }

            return rotoxHouses;
        }

        public storagespace ScanFromCellToCellRemoteStore(string barcodeFrom, string barcode)
        {
            string type = barcode.Substring(0, 4);
            storagespace storagespaceFrom = StorageSpaceService.Get(barcodeFrom);
            storagespace storagespaceTo = StorageSpaceService.Get(barcode);
            if (storagespaceTo == null)
            {
                throw new Exception($"Место не найдено по баркоду '{barcode}'");
            }
            else if (storagespaceFrom == null)
            {
                throw new Exception($"Место не найдено по баркоду '{barcodeFrom}'");
            }
            else
            {
                List<rotoxhouse> rotoxHouses = GetRotoxHousesOnPyramid(storagespaceFrom);
                if (rotoxHouses.Count > 0)
                {
                    if (type == "0000")
                    {
                        foreach (rotoxhouse rh in rotoxHouses)
                        {
                            //rh.idstoragespace = storagespaceTo.idstoragespace;
                            rh.state = (int)RotoxHouseStateEnum.CellAssigned;
                            rh.idstoredepart = storagespaceTo.idstoredepart;
                            rh.idpeople3 = IdPeople;
                            rh.row = storagespaceTo.row;
                            rh.cell = storagespaceTo.cell;
                        }
                    }

                    Unit.RepRotoxHouse.Update(rotoxHouses);

                    UpdateOrderStateIfNeed(rotoxHouses);
                }
            }

            return storagespaceTo;
        }

        public void ClearCell(string barcodeFrom)
        {
            storagespace storagespaceFrom = StorageSpaceService.Get(barcodeFrom);
            if (storagespaceFrom == null)
            {
                throw new Exception($"Место не найдено по баркоду '{barcodeFrom}'");
            }
            else
            {
                List<rotoxhouse> rotoxHouses = GetRotoxHousesOnPyramid(storagespaceFrom);
                if (rotoxHouses.Count > 0)
                {
                    foreach (rotoxhouse rh in rotoxHouses)
                    {
                        //rh.idstoragespace = storagespaceTo.idstoragespace;
                        rh.state = (int)RotoxHouseStateEnum.Left;
                        rh.dtout = DateTime.Now;
                    }

                    Unit.RepRotoxHouse.Update(rotoxHouses);

                    UpdateOrderStateIfNeed(rotoxHouses);
                }
            }
        }

        public void ClearItems(IEnumerable<int> rotoxhouses)
        {
            List<int> existedItemsIds = rotoxhouses.Where(r => r > 0).ToList();
            List<rotoxhouse> existedItems = Unit.RepRotoxHouse.Set().Where(rh => existedItemsIds.Contains(rh.idrotoxhouse)).ToList();
            if (existedItems.Count > 0)
            {
                foreach (rotoxhouse rh in existedItems)
                {
                    rh.idstoragespace2 = null;
                    rh.state = (int)RotoxHouseStateEnum.Left;
                    rh.dtout = DateTime.Now;
                }

                Unit.RepRotoxHouse.Update(existedItems);

                UpdateOrderStateIfNeed(existedItems);
            }

        }

        public void UpdateOrderStateIfNeed(int idorder)
        {
            var param = new SqlParameter("@idorders", idorder.ToString());
            Unit.ExecuteStoredProcedure("dbo.pg_check_complete", param);
        }

        public void UpdateOrderStateIfNeed(List<rotoxhouse> items)
        {
            foreach (int idOrder in items.Select(rh => rh.idorder).Distinct())
            {
                UpdateOrderStateIfNeed(idOrder);
            }
        }

        public void Delete(rotoxhouse rh)
        {
            if (rh != null && rh.idrotoxhouse != 0)
            {
                Unit.RepRotoxHouse.Delete(rh);
            }
        }

        public RotoxHouse ShipItem(string barcode, int idDelivDoc)
        {
            RotoxHouse rotoxHouse = Scan(barcode);
            if(rotoxHouse.State == (int)RotoxHouseStateEnum.Left)
                throw new Exception("Данное изделие уже отгружено!");

            bool existsInCurrentDelivDoc = Unit.RepDelivDocPos.Set()
                .Any(ddp => ddp.iddelivdoc == idDelivDoc && ddp.deleted == null
                    && (ddp.idorderitem == rotoxHouse.IdOrderItem && ddp.orderitemnum == rotoxHouse.OrderItemNum
                        || rotoxHouse.IdStoreDoc!=null && ddp.idstoredoc == rotoxHouse.IdStoreDoc));
            if (!existsInCurrentDelivDoc)
                throw new Exception("Данное изделие не входит в рейс!");

            ClearItems(new List<int>() { rotoxHouse.IdRotoxHouse } );
            rotoxHouse.State = (int)RotoxHouseStateEnum.Left;

            UpdateOrderStateIfNeed(rotoxHouse.IdOrder);

            return rotoxHouse;
        }

        public List<RotoxHouse> GetByOrder(int id)
        {
            string sql = $@"
SELECT
     cnt.cntwithcell AS mfCntOnSgp
     ,cnt.cntall AS mfCntAll
    ,oi.idorder
    ,oi.name
    ,oi.numpos
    ,dd.name AS delivDocName
    ,od.plandate AS logistDate
    ,mdp.idorderitem
    ,mdp.idmanufactdoc
    ,mdp.idmanufactdocpos
    ,mdp.orderitemnum
    ,rh.IdRotoxHouse
    ,ss2.row
    ,ss2.cell
    ,oi.name ItemName
    ,md.name ManufactDocName
    ,o.name AS OrderName
    ,rh.state
    ,oi.weight
    ,d.name AS destanationName
    ,sd2.name AS storedepart
    ,ss.row as ZoneRow
    ,ss.cell as ZoneCell
    ,sd.name as ZoneStoreDepart
    ,sd3.name as RemoteStore
    ,null as idstoredoc
    ,rh.dtout
	,isnull(md_p.name, iif(oi.idconstructiontype = 9, 'Склад СП', '') ) as parentManufactDocName
	,md_p.idmanufactdoc as parentIdManufactDoc
FROM 
  orders o
  JOIN orderitem oi ON o.idorder = oi.idorder
  JOIN manufactdocpos mdp ON mdp.idorderitem = oi.idorderitem
  JOIN manufactdoc md ON md.idmanufactdoc = mdp.idmanufactdoc
  outer apply (select top 1 md_p.idmanufactdoc, md_p.name from orderitem oi_p
					join manufactdocpos mdp_p on mdp_p.idorderitem = oi_p.idorderitem
					join manufactdoc md_p on md_p.idmanufactdoc = mdp_p.idmanufactdoc
				where oi_p.idorderitem = oi.parentid) md_p
  JOIN destanation d 
    ON o.iddestanation = d.iddestanation
    LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder and od.idorderitem = mdp.idorderitem and od.orderitemnum = mdp.orderitemnum
  LEFT JOIN delivdocpos ddp
    ON ddp.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid
  LEFT JOIN rotoxhouse rh ON rh.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN storagespace ss ON rh.idstoragespace = ss.idstoragespace
  LEFT JOIN storedepart sd ON ss.idstoredepart = sd.idstoredepart
  LEFT JOIN storagespace ss2 ON rh.idstoragespace2 = ss2.idstoragespace
  LEFT JOIN storedepart sd2 ON ss2.idstoredepart = sd2.idstoredepart
  LEFT JOIN storedepart sd3 ON rh.idstoredepart = sd3.idstoredepart
  OUTER APPLY (SELECT COUNT(mdp2.idmanufactdocpos) AS cntall, COUNT(rh.idrotoxhouse) cntwithcell FROM manufactdocpos mdp2 
      LEFT JOIN rotoxhouse rh ON mdp2.idmanufactdocpos = rh.idmanufactdocpos
        WHERE mdp2.idmanufactdoc = md.idmanufactdoc and rh.idstoredepart is null ) AS cnt
WHERE o.idorder = @id
";
            var param = new SqlParameter("@id", id);
            var res = Unit.SqlQuery<RotoxHouse>(sql, param);

            return res;
        }
    }
}
