using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IGenUoW unit) : base(unit)
        {
        }

        public orders Create(orders order)
        {
            Unit.RepOrder.Create(order);

            return order;
        }

        public orders Get(int id)
        {
            orders res = Unit.RepOrder.Get(oi => oi.idorder == id, dd => dd.iddocstateNavigation);
            
            return res;
        }
    }
}