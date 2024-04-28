using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.Services
{
    public interface IPeoplesService
    {
        List<people> GetAll();
        people Get(int id);
        people GetByBarcode(string barcode);
        people GetByLogin(string login);
        List<people> Search( string subString);
    }
}
