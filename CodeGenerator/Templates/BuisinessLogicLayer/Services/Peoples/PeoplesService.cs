using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer.Services
{
    public class PeoplesService : BaseService, IPeoplesService
    {
        public PeoplesService(IGenUoW unit) : base(unit)
        {

        }

        public people Get(int id)
        {
            people result = Unit.RepPeople.Set().FirstOrDefault(p => p.idpeople == id);

            return result;
        }

        public List<people> GetAll()
        {
            List<people> result = Unit.RepPeople.GetAll();

            return result;
        }
        public people GetByBarcode(string barcode)
        {
            people result = Unit.RepPeople.Set().FirstOrDefault(p => p.barcode == barcode);

            return result;
        }

        public people GetByLogin(string login)
        {
            people result = Unit.RepPeople.Set().FirstOrDefault(p => p.userlogin == login);

            return result;
        }

        public List<people> Search(string subString)
        {
            subString = subString.ToLower();
            List<people> result = (string.IsNullOrEmpty(subString))
                ? Unit.RepPeople.Set()
                    .ToList()
                : Unit.RepPeople.Set()
                    .Where(p => p.name.ToLower().Contains(subString) || p.lastname.ToLower().Contains(subString) || p.middlename.ToLower().Contains(subString))
                    .ToList();

            return result;
        }
    }
}
