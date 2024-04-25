using BuisinessLogicLayer.Enum;
using System;

namespace BuisinessLogicLayer.ViewModels
{
    public class RotoxHouse
    {
        public int IdRotoxHouse { get; set; }
        public string StoreDepart { get; set; }
        public string Row { get; set; }
        public string Cell { get; set; }        
        public string ZoneStoreDepart { get; set; }
        public string ZoneRow { get; set; }
        public string ZoneCell { get; set; }
        public string RemoteStore { get; set; }
        public string ItemName { get; set; }
        public int? IdManufactDoc { get; set; }
        public int? IdManufactDocPos { get; set; }
        public int? IdStoreDoc { get; set; }
        public string ManufactDocName { get; set; }
        public string OrderName { get; set; }
        public int State { get; set; }
        public RotoxHouseStateEnum StateEnum => (RotoxHouseStateEnum)State; 
        public decimal? Weight { get; set; }
        public DateTime? LogistDate { get; set; }
        public string DestanationName { get; set; }
        public int? IdOrderItem { get; set; }
        public int? OrderItemNum { get; set; }
        public int? NumPos { get; set; }
        public int MfCntOnSgp { get; set; }
        public int MfCntAll{ get; set; }
        public int IdOrder { get; set; }
        public DateTime? DtOut { get; set; }
        public string ParentManufactDocName { get; set; }
        public int? ParentIdManufactDoc { get; set; }

    }
}
