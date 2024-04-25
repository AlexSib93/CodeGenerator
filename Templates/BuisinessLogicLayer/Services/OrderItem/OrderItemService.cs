using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class OrderItemService : BaseService, IOrderItemService
    {
        public OrderItemService(IGenUoW unit) : base(unit)
        {
        }

        public orderitem Create(orderitem orderitem)
        {
            Unit.RepOrderItem.Create(orderitem);

            return orderitem;
        }

        public orderitem Get(int id)
        {
            orderitem res = Unit.RepOrderItem.Get(oi => oi.idorderitem == id);
            
            return res;
        }
    }
}