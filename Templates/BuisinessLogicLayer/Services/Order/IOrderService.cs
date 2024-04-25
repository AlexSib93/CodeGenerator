using System.Collections.Generic;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IOrderService
    {         
        orders Create(orders order);
        orders Get(int id);
    }
}