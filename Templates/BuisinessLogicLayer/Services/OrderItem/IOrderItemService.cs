using System.Collections.Generic;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IOrderItemService
    {         
        orderitem Create(orderitem orderitem);
        orderitem Get(int id);
    }
}