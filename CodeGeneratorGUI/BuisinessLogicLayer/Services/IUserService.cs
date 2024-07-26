using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IUserService
    {

        User Add(User modelMetadata);

        User Get(int id);

        User GetByLogin(string login);

        User GetByBarcode(string barcode);

        IEnumerable<User> Get();

        void Delete(int id);
    }
}
