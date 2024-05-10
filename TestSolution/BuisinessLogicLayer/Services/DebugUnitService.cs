using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class DebugUnitService : BaseService, IDebugUnitService
    {
        public DebugUnitService(IUnitOfWork unit) : base(unit)
        {
        }

        public DebugUnit Add(DebugUnit debugUnit)
        {
            Unit.RepDebugUnit.Add(debugUnit);

            return debugUnit;
        }

        public DebugUnit Get(int id)
        {
            DebugUnit t = Unit.RepDebugUnit.GetById(id);

            return t;
        }

        public IEnumerable<DebugUnit> Get()
        {
            IEnumerable<DebugUnit> debugUnits = Unit.RepDebugUnit.GetAll();

            return debugUnits;
        }

        public void Delete(int id)
        {
            Unit.RepDebugUnit.Delete(id);
        }
    }
}
