using BuisinessLogicLayer.Enum;
using BuisinessLogicLayer.Models;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogicLayer.Services.Domain
{
    public class TerminalService: BaseService, ITerminalService
    {

        public TerminalService(IGenUoW unit) : base(unit)
        {

        }

        public OrderItemViewModel GetGpStorageInfo(string barcode)
        {
            BarcodeInfo info = BarcodeService.GetBarcodeInfo(barcode);

            if (info.Type != BarcodeTypeEnum.ManufactDocPos)
            {
                throw new Exception("Баркод должен начинаться с 1");
            }

            string sql = $@"
SELECT
  mdp.idorderitem
 ,mdp.idmanufactdoc
 ,mdp.orderitemnum
 ,mdp.weight
 ,'' AS storageing
 ,0 AS mfItemsOnSgp
 ,oi.idorder
 ,o.name AS orderName
 ,oi.name
 ,dd.name AS delivDocName
 ,od.plandate AS logistDate

FROM manufactdocpos mdp
  JOIN orderitem oi
    ON mdp.idorderitem = oi.idorderitem
  JOIN orders o
    ON o.idorder = oi.idorder
  LEFT JOIN delivdocpos ddp
    ON ddp.idmanufactdocpos = mdp.idmanufactdocpos
  LEFT JOIN delivdoc dd_r
    ON ddp.iddelivdoc = dd_r.iddelivdoc
  LEFT JOIN delivdoc dd
    ON dd.iddelivdoc = dd_r.parentid  
LEFT JOIN orderdiraction od on od.iddiraction = 3 and od.idorder = o.idorder
    ON dd.iddelivdoc = dd_r.parentid
WHERE mdp.barcode = @barcode
";
            var param = new SqlParameter("@barcode", barcode);
            var res =  Unit.SqlQuery<OrderItemViewModel>(sql, param).FirstOrDefault();

            return res;
        }
    }
}
