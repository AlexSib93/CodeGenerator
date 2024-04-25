using System.Collections.Generic;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IDelivDocService
    {
        delivdoc Create(delivdoc delivdoc);
        delivdoc Get(int id);
    }
}