using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface ITestModel1Service
    {

        TestModel1 Add(TestModel1 testModel1);

        TestModel1 Get(int id);

        IEnumerable<TestModel1> Get();

        void Delete(int id);
    }
}
