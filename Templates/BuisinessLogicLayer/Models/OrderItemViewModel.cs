using System;

namespace BuisinessLogicLayer.Models
{
    public class OrderItemViewModel
    {
        public int IdOrderItem { get; set; }
        public string Storage { get; set; }
        public int IdManufactDoc { get; set; }
        public int MfItemsOnSgp { get; set; }
        public int Weight { get; set; }
        public int OrderItemNum { get; set; }
        public int IdOrder { get; set; }
        public string OrderName { get; set; }
        public string Name { get; set; }
        public string DelivDocName { get; set; }
        public DateTime LogistDate { get; set; }
    }
}
