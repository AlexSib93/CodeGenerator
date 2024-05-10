using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IDebugUnitService
    {

        DebugUnit Add(DebugUnit debugUnit);

        DebugUnit Get(int id);

        IEnumerable<DebugUnit> Get();

        void Delete(int id);
    }
}
